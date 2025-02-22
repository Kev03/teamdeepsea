extends Control

func _ready():
	for map_object in $ScrollContainer/GridContainer.get_children():
		map_object.connect("OnSelection", on_selection)

func on_selection(object):
	for map_object in $ScrollContainer/GridContainer.get_children():
		if(map_object != object):
			map_object.deselect()
