extends Area2D

signal state_changed(state: bool)

@export_group("Configuration")
@export var dead_zone: float = 1.0
@export var initial_state: bool = false

@export_group("References")
@export var sprite: Sprite2D

var state: bool = false

func _ready() -> void:
	if is_multiplayer_authority():
		body_entered.connect(_on_body_entered)
		body_exited.connect(_on_body_exited)
	
	set_physics_process(false)

func _physics_process(_delta: float) -> void:	
	var pressing_left  = 0
	var pressing_right = 0
	
	# Check which side the bodies collided with
	for body in get_overlapping_bodies().filter(func (body: Node2D): return body.is_in_group("submarines") || body.is_in_group("divers")):
		var body_in_local = global_transform.affine_inverse() * body.global_transform.origin
		
		if abs(body_in_local.x) > abs(dead_zone):
			if body_in_local.x < 0:
				pressing_left += 1
			else:
				pressing_right += 1
	
	# At least one actor is pressing a side
	# and one side has more actors pressing it
	if max(pressing_left, pressing_right) > 0 and pressing_left != pressing_right:
		var new_state = pressing_right > pressing_left
		
		if new_state != state:
			state = new_state
			_broadcast_state.rpc(state)

@rpc("call_local")
func _broadcast_state(new_state):
	state = new_state
	state_changed.emit(state)
	sprite.flip_h = !state

func _on_body_entered(body: Node2D) -> void:
	if body.is_in_group("submarines") or body.is_in_group("divers"):
		set_physics_process(true)

func _on_body_exited(_body: Node2D) -> void:
	if get_overlapping_bodies().all(func (body: Node2D): return !body.is_in_group("submarines") && !body.is_in_group("divers")):
		set_physics_process(false)
