extends Node

var floor = preload("res://Scenes/Floor/Floor.tscn")
var floorSection = preload("res://Scenes/MazeGenerator/ExampleSection.tscn")
const GridHelpers = preload("res://Scenes/MazeGenerator/GridHelpers.gd")
var walls = preload("res://Scenes/MazeGenerator/Walls.tscn")
var door = preload("res://Scenes/Door/door.tscn")
var doors = preload("res://Scenes/MazeGenerator/Doors.tscn")
var player =  preload("res://Scenes/Player/player.tscn")

var height = 27;
var width = 27;

var maze = GridHelpers.createMultiCheckpointMaze(height, width);
var floorGrid = maze.grid;
var startPosition = maze.startPosition;

func existsWithinBlock(y, x):
	for i in range(0, 3):
		for j in range(0, 3):
			if(floorGrid[y+i][x+j] == 1):
				return true;
	return false;

func withinGridBounds(x, y):
	if(x < 0 or x >= width or y < 0 or y >= height):
		return false;
	return true;

func spawnFloorSection(x, y):
	var floorInst = floorSection.instantiate()
	floorInst.position.x = x*24;
	floorInst.position.y = 0;
	floorInst.position.z = y*24;
	self.add_child(floorInst);
	
func spawnWalls(x, y):
	var wallsInst = walls.instantiate()
	wallsInst.position.x = x*24;
	wallsInst.position.y = 0;
	wallsInst.position.z = y*24;
	self.add_child(wallsInst);
	
func spawnDoors(x, y):
	var doorsInst = doors.instantiate()
	doorsInst.position.x = x*24;
	doorsInst.position.y = 0;
	doorsInst.position.z = y*24;
	self.add_child(doorsInst);
	var one = !withinGridBounds(x, y+1) or floorGrid[y+1][x] == 1;
	var two = !withinGridBounds(x+1, y) or floorGrid[y][x+1] == 1;
	var three = !withinGridBounds(x, y-1) or floorGrid[y-1][x] == 1;
	var four = !withinGridBounds(x-1, y) or floorGrid[y][x-1] == 1;
	doorsInst.disableDoors(one, two, three, four)
	

# Called when the node enters the scene tree for the first time.
func _ready():
	var playerInst = player.instantiate()
	playerInst.position = Vector3(24*startPosition.x + 12, 1, 24*startPosition.y + 12);
	self.add_child(playerInst);		
	for x in range(width):
		for y in range(height):
			if(floorGrid[y][x] == 1):
				spawnFloorSection(x, y);
				spawnWalls(x, y);
				spawnDoors(x, y);


