extends "res://scripts/player/base_player.gd"

@export_group("Movement")
@export var max_speed = 100.0
@export var acceleration = 50.0
@export var deacceleration = 100.0

@export_group("References")
@export var front_light: PointLight2D
@export var ambient_light: PointLight2D
@export var sprite: Sprite2D

signal audio_command_sent(cmd: Globals.AudioCommands)

func _ready() -> void:
	super()
	
	player_input.set_multiplayer_authority(Network.submarine_id)
	
	if Network.enet_peer.get_unique_id() == Network.diver_id:
		front_light.visible=false
		ambient_light.visible=false

func _process(_delta: float) -> void:
	# Flip submarine according to its movement direction 
	if velocity.x > 0:
		sprite.flip_h = true
		front_light.position.x=abs(front_light.position.x)
		front_light.rotation=-abs(front_light.rotation)
	elif velocity.x < 0:
		sprite.flip_h = false
		front_light.position.x=-abs(front_light.position.x)
		front_light.rotation=abs(front_light.rotation)

func _calculate_velocity(direction: Vector2, delta: float):
	return velocity.move_toward(direction * max_speed, (deacceleration if direction == Vector2.ZERO else acceleration) * delta)

@rpc("any_peer", "call_local")
func send_audio_cmd(cmd: Globals.AudioCommands):
	if !multiplayer.is_server() || multiplayer.get_remote_sender_id() != Network.submarine_id:
		return
	
	broadcast_audio_cmd.rpc_id(Network.diver_id, cmd)

@rpc
func broadcast_audio_cmd(cmd: Globals.AudioCommands):
	audio_command_sent.emit(cmd)
