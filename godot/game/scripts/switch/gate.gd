extends Node2D

enum OpenDirections {
	UP,
	DOWN
}

@export_group("Options")
@export var open_direction: OpenDirections

@export_group("References")
@export var timer: Timer
@export var sprite: Sprite2D
@export var pivot: StaticBody2D

const max_rotation = 90
@onready var init_rotation = rotation

var tween: Tween

func set_gate_state(state: bool):
	if state:
		_open()
	else:
		_close()

func _reset_tween():
	if tween != null:
		tween.kill()
	tween = get_tree().create_tween()

func _reset_timer():
	timer.start(1-timer.time_left)

func _open():
	_reset_tween()
	
	pivot.set_collision_layer_value(1,0)
	
	match open_direction:
		OpenDirections.UP:
			scale.y = abs(scale.y)
			sprite.flip_v = false
			tween.tween_property(pivot,"rotation",deg_to_rad(max_rotation),1-timer.time_left)
		OpenDirections.DOWN:
			scale.y = -abs(scale.y)
			sprite.flip_v = true
			tween.tween_property(pivot,"rotation",deg_to_rad(max_rotation),1-timer.time_left)

	_reset_timer()

func _close():
	print("test")
	if tween != null:
		tween.kill()
	tween=get_tree().create_tween()
	
	tween.tween_property(pivot,"rotation",init_rotation,1-timer.time_left)
	tween.tween_callback(_restore_collision)
	timer.start(1-timer.time_left)

func _restore_collision():
	pivot.set_collision_layer_value(1,1)
	return true
