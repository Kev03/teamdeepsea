extends "res://scripts/player/base_player.gd"

@export_group("Movement")
@export var max_speed = 100.0

@export_group("References")
@export var ambient_light: PointLight2D
@export var audio_player: AudioStreamPlayer
@export var sprite: AnimatedSprite2D

func _ready() -> void:
	super()
	
	player_input.set_multiplayer_authority(Network.diver_id)
	
	# Connect to submarine's audio_command_sent signal
	if multiplayer.get_unique_id() == Network.diver_id:
		for submarine in get_tree().get_nodes_in_group("submarines"):
			if submarine.has_signal("audio_command_sent"):
				submarine.audio_command_sent.connect(play_audio)

func _process(_delta: float) -> void:
	# Flip diver according to its movement direction 
	if velocity.x > 0:
		scale.x = abs(scale.x)
		sprite.flip_h = false
	elif velocity.x < 0:
		sprite.flip_h = true

func _calculate_velocity(direction: Vector2, _delta: float):
	return direction * max_speed

func attach_camera(camera: Camera2D):
	camera.position_smoothing_enabled = false
	super(camera)

func play_audio(cmd: Globals.AudioCommands):
	if cmd == Globals.AudioCommands.NONE || audio_player.playing:
		return
	
	audio_player.stream = Globals.AudioCommandPaths.get(cmd)
	audio_player.play()
