class_name MultiTouchScreenButton extends Button

var touch_index = 0

@export var input_action: Array[StringName]

func _input_in_button(event_pos: Vector2) -> bool:
	return  int(event_pos.x) in range(global_position.x, global_position.x + int(size.x * scale.x)) and \
			int(event_pos.y) in range(global_position.y, global_position.y + int(size.y * scale.y))

func _handle_input(active: bool, index: int):
	for action in input_action:
		var input = InputEventAction.new()
		input.action = action
		input.pressed = active
		Input.parse_input_event(input)
		touch_index = index

func _input(event: InputEvent) -> void:
	if event is InputEventScreenTouch:
		if  (event.is_pressed() and _input_in_button(event.position)) or \
			(event.is_released() and touch_index == event.index):
				_handle_input(event.pressed, event.index)
	if not keep_pressed_outside:
		if event is InputEventScreenDrag and touch_index == event.index:
			if not _input_in_button(event.position):
				_handle_input(false, event.index)
