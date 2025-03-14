extends Node2D

@export_group("References")
@export var collectables_container: Container
@export var ui_shader: ShaderMaterial

var collected: int = 0
var collectable_icons: Array[TextureRect] = []

func draw_collectables(collectables: Array[Node]):
	for collectable in collectables:
		if "ui_icon" not in collectable:
			continue
		
		var texture_rect = TextureRect.new()
		texture_rect.texture = collectable.ui_icon
		texture_rect.expand_mode=TextureRect.EXPAND_FIT_WIDTH
		texture_rect.material = ui_shader
		collectable_icons.append(texture_rect)
		collectables_container.add_child(texture_rect)

func collect_collectable():
	if collectable_icons.size()>collected:
		collectable_icons[collected].material=null
	collected += 1
