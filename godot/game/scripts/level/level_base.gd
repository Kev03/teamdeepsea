extends Node2D

signal level_completed(next_level: PackedScene)

@export_group("References")
@export var diver_ui: PackedScene
@export var submarine_ui: PackedScene
@export var camera: Camera2D
@export var next_level: PackedScene

var active_ui: Node

func _ready() -> void:
	setup_ui()
	setup_level()

func setup_ui():
	if multiplayer.get_unique_id() == Network.submarine_id:
		active_ui = submarine_ui.instantiate()
	elif multiplayer.get_unique_id() == Network.diver_id:
		active_ui = diver_ui.instantiate()
	
	if active_ui:
		add_child(active_ui)

func setup_level():
	setup_local_player()
	setup_collectables()

func setup_local_player():
	var active_player: Node2D
	
	if multiplayer.get_unique_id() == Network.submarine_id:
		active_player = get_tree().get_first_node_in_group("submarines")
	elif multiplayer.get_unique_id() == Network.diver_id:
		active_player = get_tree().get_first_node_in_group("divers")
	
	if active_player and active_player.has_method("attach_camera"):
		active_player.attach_camera(camera)
		camera.make_current()

func setup_collectables():
	# We can skip this if the methode is missing
	if active_ui.has_method("draw_collectables"):
		var collectables = get_tree().get_nodes_in_group("collectables")
		
		# We can skip this if the methode is missing
		if active_ui.has_method("collect_collectable"):
			for collectable in collectables:
				if collectable.has_signal("collected"):
					collectable.collected.connect(func ():
						active_ui.collect_collectable()
						collectables.erase(collectable)
						
						if multiplayer.is_server() and collectables.is_empty():
							complete_level.rpc()
					)
		
		active_ui.draw_collectables(collectables)

@rpc("call_local")
func complete_level():
	level_completed.emit(next_level)
