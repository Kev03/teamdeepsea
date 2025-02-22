extends TextureButton

signal OnSelection(object)

@export var source_id : int

func _on_button_up():
	$SelectionOverlay.show()
	emit_signal("OnSelection", source_id)

func deselect():
	$SelectionOverlay.hide()

func _on_mouse_entered():
	$HoverOverlay.show()

func _on_mouse_exited():
	$HoverOverlay.hide()
