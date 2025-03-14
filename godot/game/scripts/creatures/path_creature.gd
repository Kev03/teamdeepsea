extends Path2D

@export var speed: float = 32
@export var flip_h: bool = false

@export var path_follow: PathFollow2D
@export var remote_transform: RemoteTransform2D

func _ready() -> void:
	# Do not process movement on client
	if !is_multiplayer_authority():
		set_physics_process(false)
		return

func _physics_process(delta: float) -> void:
	# If we don't want to flip, there is no need to calculate the delta_pos
	if !flip_h:
		path_follow.progress += speed * delta
		return
	
	var prev_pos = remote_transform.global_position
	path_follow.progress += speed * delta
	var delta_pos = remote_transform.global_position - prev_pos
	
	# If delta_pos is basically zero,
	# it's not possible to determine the rotation
	if is_zero_approx(delta_pos.x):
		return

	# Flip creature according to its movement direction
	if delta_pos.x > 0:
		remote_transform.scale.x = abs(remote_transform.scale.x)
	elif delta_pos.x < 0:
		remote_transform.scale.x = -abs(remote_transform.scale.x)
