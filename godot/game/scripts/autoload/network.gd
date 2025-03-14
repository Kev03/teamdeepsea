extends Node

var enet_peer = ENetMultiplayerPeer.new()

# This should always be 1,
# but we may use a dedicated server,
# so this may change
var submarine_id: int = 1
var diver_id: int

var match_running: bool = false

signal match_started(msg: String)
signal match_ended(msg: String)

signal client_error(msg: String)

# Connect client signals
func _ready() -> void:
	multiplayer.connected_to_server.connect(
		func ():
			diver_id = multiplayer.get_unique_id()
	)
	
	multiplayer.connection_failed.connect(
		func ():
			show_error("Connection failed!")
			reset()
	)
	
	multiplayer.server_disconnected.connect(
		func ():
			if match_running:
				show_error("Connection lost!")
				_end_match()
			reset()
	)

# Setup and host a local server
func host():
	enet_peer.create_server(3000)
	multiplayer.multiplayer_peer = enet_peer
	
	# Handle joining peers
	enet_peer.peer_connected.connect(
		func(peer_id):
			# Disconnect peer if a diver is already connected
			if diver_id:
				send_err_msg.rpc_id(peer_id, "This game is already full!")
				enet_peer.get_peer(peer_id).peer_disconnect_later()
				return
			
			# Setup the diver and start the game
			diver_id = peer_id
			broadcast_start_match.rpc()
	)
	
	# End the match if player disconnects mid-game
	enet_peer.peer_disconnected.connect(
		func (peer_id):
			if match_running and peer_id == diver_id:
				broadcast_end_match.rpc()
				show_error("Connection lost!")
	)

# Join a hosted server
func join():
	enet_peer.create_client("localhost", 3000)
	multiplayer.multiplayer_peer = enet_peer

# Reset the networking instance
func reset():
	# Disconnect all client peers
	if is_active() && is_multiplayer_authority():
		await _disconnect_clients()
	
	# end match if already/still running
	if match_running:
		_end_match()

	# Stop networking
	multiplayer.multiplayer_peer = null
	enet_peer.close()
	
	# Reset peer_ids
	submarine_id = 1
	diver_id = 0
	
	# Reset local peer
	enet_peer = ENetMultiplayerPeer.new()

# Disconnect all clients from server
func _disconnect_clients():
	if is_active() && is_multiplayer_authority():
		for peer_id in multiplayer.get_peers():
			enet_peer.get_peer(peer_id).peer_disconnect_later()
			await enet_peer.peer_disconnected

@rpc("call_local")
func broadcast_start_match():
	if !match_running:
		match_running = true
		match_started.emit()

@rpc("call_local")
func broadcast_end_match():
	_end_match()
	reset()

func _end_match():
	if match_running:
		match_running = false
		match_ended.emit()

func show_error(message):
	client_error.emit.call_deferred(message)

func is_active():
	return enet_peer.get_connection_status() == MultiplayerPeer.CONNECTION_CONNECTED

@rpc
func send_err_msg(message):
	show_error(message)
