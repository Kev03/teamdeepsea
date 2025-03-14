extends CanvasLayer

@export_group("References")
@export var HostButton: BaseButton
@export var JoinButton: BaseButton
@export var CancelButton: BaseButton
@export var ErrorOutput: AcceptDialog

func _ready() -> void:
	HostButton.pressed.connect(func ():
		Network.host()
		hide_buttons()
	)
	
	JoinButton.pressed.connect(func ():
		Network.join()
		hide_buttons()
	)
	
	CancelButton.pressed.connect(func ():
		Network.reset()
		show_buttons()
	)
	
	Network.match_ended.connect(show_buttons)
	
	Network.client_error.connect(func (msg: String):
		ErrorOutput.dialog_text = msg
		ErrorOutput.show()
		show_buttons()
	)

func show_buttons():
	HostButton.show()
	JoinButton.show()
	CancelButton.hide()

func hide_buttons():
	HostButton.hide()
	JoinButton.hide()
	CancelButton.show()
