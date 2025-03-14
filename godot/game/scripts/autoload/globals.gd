extends Node

enum AudioCommands {
	NONE,
	UP,
	DOWN,
	LEFT,
	RIGHT,
	COLLECT
}

const AudioCommandPaths = {
	AudioCommands.UP: preload("res://assets/audio/commands/up-sfx.mp3"),
	AudioCommands.DOWN: preload("res://assets/audio/commands/down-sfx.mp3"),
	AudioCommands.LEFT: preload("res://assets/audio/commands/left-sfx.mp3"),
	AudioCommands.RIGHT: preload("res://assets/audio/commands/right-sfx.mp3"),
	AudioCommands.COLLECT: preload("res://assets/audio/commands/collect-sfx.mp3")
}
