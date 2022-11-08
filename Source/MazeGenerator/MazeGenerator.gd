
extends Node

@export var scenes: Array[PackedScene] = []
@export var directionBias : float;
@export var randomness : float;
@export var minLengthRun : int;
@export var maxLengthRun : int;
@export var numberOfExtraPoints : int;
@export var mazeSize : int;

var floorSection = preload("res://Scenes/Sections/Template.tscn")
const GridHelpers = preload("res://Source/MazeGenerator/GridHelpers.gd")
var player =  preload("res://Scenes/Player/player.tscn")

var height = mazeSize;
var width = mazeSize;

var maze;

func withinGridBounds(x, y):
	if(x < 0 or x >= width or y < 0 or y >= height):
		return false;
	return true;

func getRandomScene():
	return scenes[GridHelpers.randomInt(0, scenes.size()-1)];

func spawnFloorSection(x, y):
	var floorInst = getRandomScene().instantiate()
	floorInst.position.x = x*24;
	floorInst.position.y = 0;
	floorInst.position.z = y*24;
	self.add_child(floorInst);
	
#func spawnWalls(x, y):
#	var wallsInst = walls.instantiate()
#	wallsInst.position.x = x*24;
#	wallsInst.position.y = 0;
#	wallsInst.position.z = y*24;
#	self.add_child(wallsInst);
#
#func spawnDoors(x, y):
#	var doorsInst = doors.instantiate()
#	doorsInst.position.x = x*24;
#	doorsInst.position.y = 0;
#	doorsInst.position.z = y*24;
#	self.add_child(doorsInst);
#	var one = !withinGridBounds(x, y+1) or floorGrid[y+1][x] == 1;
#	var two = !withinGridBounds(x+1, y) or floorGrid[y][x+1] == 1;
#	var three = !withinGridBounds(x, y-1) or floorGrid[y-1][x] == 1;
#	var four = !withinGridBounds(x-1, y) or floorGrid[y][x-1] == 1;
#	doorsInst.disableDoors(one, two, three, four)
	

# Called when the node enters the scene tree for the first time.
func _ready():
	maze = GridHelpers.createMultiCheckpointMaze(mazeSize, mazeSize, directionBias, randomness, minLengthRun, maxLengthRun, numberOfExtraPoints);
	height = mazeSize;
	width = mazeSize;
	print(mazeSize)
	var playerInst = player.instantiate()
	playerInst.position = Vector3(24*maze.startPosition.x + 12, 1, 24*maze.startPosition.y + 12);
	self.add_child(playerInst);		
	for x in range(width):
		for y in range(height):
			if(maze.grid[y][x] == 1):
				spawnFloorSection(x, y);
#				spawnWalls(x, y);
#				spawnDoors(x, y);


