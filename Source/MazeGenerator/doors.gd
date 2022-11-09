extends Node

@export var northDoor : Node ;
@export var southDoor : Node ;
@export var eastDoor : Node ;
@export var westDoor : Node ;

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func disableDoors(north, south, east, west):
	if(north):
		northDoor.queue_free();
	if(south):
		southDoor.queue_free();
	if(east):
		eastDoor.queue_free();
	if(west):
		westDoor.queue_free();
	
