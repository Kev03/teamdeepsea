extends MultiplayerSynchronizer

var input_direction: Vector2

func _ready() -> void:
	set_visibility_for(1, true)

func _unhandled_input(event: InputEvent) -> void:
	if is_multiplayer_authority():
		var cmd: Globals.AudioCommands
		
		if event.is_action_pressed("audio_up"):
			cmd = Globals.AudioCommands.UP
		elif event.is_action_pressed("audio_down"):
			cmd = Globals.AudioCommands.DOWN
		elif event.is_action_pressed("audio_left"):
			cmd = Globals.AudioCommands.LEFT
		elif event.is_action_pressed("audio_right"):
			cmd = Globals.AudioCommands.RIGHT
		elif event.is_action_pressed("audio_collect"):
			cmd = Globals.AudioCommands.COLLECT
		
		if cmd != Globals.AudioCommands.NONE:
			get_parent().send_audio_cmd.rpc_id(1, cmd)

func _physics_process(_delta: float) -> void:
	if is_multiplayer_authority():
		input_direction = Vector2(Input.get_axis("move_left", "move_right"), Input.get_axis("move_up", "move_down")).normalized()
