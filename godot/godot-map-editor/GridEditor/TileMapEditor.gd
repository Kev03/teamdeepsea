extends TileMap

var active_cell : int
var grid_size = 4
var dict = {}

func _ready():
	for x in grid_size:
		for y in grid_size:
			dict[str(Vector2(x,y))] = {
				"Type" : "Water",
				"Position" : str(Vector2(x,y))
			}
			set_cell(0,Vector2(x,y), 0, Vector2(0,0), 0)

func _process(delta):
	highlight_cell()
	handle_click()

func handle_click():
	if Input.is_action_just_pressed("mouse_click"):
		var tile = (get_global_mouse_position())
		set_cell(0, tile, 2, Vector2i(0,0), 0)
		dict[str(tile)]["Type"] = "Grass"
	

func highlight_cell():
	for x in grid_size:
		for y in grid_size:
			erase_cell(1, Vector2(x,y))
	
	var tile = local_to_map(get_global_mouse_position())
	
	if dict.has(str(tile)):
		set_cell(1, tile, active_cell, Vector2i(0,0), 0)
	
