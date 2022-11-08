extends Node


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func disableDoors(one, two, three, four):
	if(one):
		$Door.queue_free();
	if(two):
		$Door2.queue_free();
	if(three):
		$Door3.queue_free();
	if(four):
		$Door4.queue_free();
	
