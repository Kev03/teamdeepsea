extends CharacterBody2D

@export_group("References")
@export var player_input: Node
@export var remote_transform: RemoteTransform2D

func _ready() -> void:
	if !is_multiplayer_authority():
		set_physics_process(false)

func _physics_process(delta: float) -> void:
	# Calculate and update the position on the server
	var direction = player_input.input_direction.normalized()
	velocity = _calculate_velocity(direction, delta)
	move_and_slide()

func _calculate_velocity(_direction: Vector2, _delta: float):
	return velocity

func attach_camera(camera: Camera2D):
	remote_transform.remote_path = camera.get_path()
	camera.reset_smoothing()
