extends MultiplayerSpawner

@export_group("References")
@export var menu: CanvasLayer
@export var initial_level: PackedScene

@onready var spawn_node: Node = get_node(spawn_path)

func _ready() -> void:
	Network.match_started.connect(load_level)
	Network.match_ended.connect(unload_level)

func load_level(level: PackedScene = initial_level):
	if is_multiplayer_authority():
		var active_level = level.instantiate()
		spawn_node.add_child(active_level, true)
		
		active_level.level_completed.connect(switch_level)
	
	menu.visible = false

func switch_level(next_level: PackedScene):
	await unload_level()
	
	# Load level or end match/game
	if next_level and next_level.can_instantiate():
		load_level(next_level)
	elif is_multiplayer_authority():
		Network.broadcast_end_match.rpc()

func unload_level():
	if !Network.is_active() || is_multiplayer_authority():
		for child in spawn_node.get_children():
			child.queue_free()
			await child.tree_exited
	
	menu.visible = true
