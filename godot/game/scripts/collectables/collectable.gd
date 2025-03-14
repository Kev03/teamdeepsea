extends Area2D

@export var ui_icon: CompressedTexture2D

signal collected

func _on_body_entered(body: Node2D) -> void:
	if multiplayer.is_server() and body.is_in_group("divers"):
		collect.rpc()

@rpc("call_local")
func collect():
	collected.emit()
	queue_free()
