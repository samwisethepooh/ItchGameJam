
extends Node

@export var scenes: Array[PackedScene] = []
@export var directionBias : float;
@export var randomness : float;
@export var minLengthRun : int;
@export var maxLengthRun : int;
@export var numberOfExtraPoints : int;
@export var mazeSize : int;
var validRoomShapes = [];
var validRommShapesOrdered = [];
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

func groupGridNumbers(grid):
	var groupedGrid = GridHelpers.createEmptyNullGrid(width, height);
	for roomSize in validRommShapesOrdered:		
		for x in range(width-1):
			for y in range(height-1):
				if(groupedGrid[y][x] == null):
					
						
					var tempX = x+1;
					var lastX = 1;
					var allX = [x];
					while(lastX != roomSize.X && tempX < width && grid[y][tempX] == 1):
						allX.append(tempX)
						lastX += 1;
						tempX += 1;
					
					var tempY = y+1;
					var lastY = 1;
					var allY = [y];
					while(lastY != roomSize.Y && tempY < height && grid[tempY][x] == 1):
						allY.append(tempY)
						lastY += 1;
						tempY += 1;

					if(lastY == roomSize.Y and lastX == roomSize.X):
						var anyGridPartsTaken = false;
						for i in allX:
							for j in allY:	
								if(groupedGrid[j][i]) != null:
									anyGridPartsTaken = true;
						
						if(!anyGridPartsTaken):
							for i in allX:
								for j in allY:
									groupedGrid[j][i] = {"X": lastX, "Y": lastY};
	print(groupedGrid)
	return groupedGrid;
			
func getValidRoomShapes():
	for room in scenes:
		var roomInst = room.instantiate();
		validRoomShapes.append({"X": roomInst.X, "Y": roomInst.Y})
		roomInst.queue_free();
	validRommShapesOrdered = validRoomShapes.duplicate()
	validRommShapesOrdered.sort_custom(Callable(self, "sortRoomSizes"))
	print(validRommShapesOrdered)

func sortRoomSizes(roomSize1, roomSize2):
		return (roomSize1.X + roomSize1.Y) > (roomSize2.X + roomSize2.Y)
		
func getRandomScene(roomSize):
	var randomNumber;
	var foundApplicableRoom = false;
	
	while(!foundApplicableRoom):
		randomNumber = GridHelpers.randomInt(0, scenes.size()-1);
		var roomToMake = scenes[randomNumber];
		var roomShape = validRoomShapes[randomNumber]
		
		if(roomShape.X == roomSize.X and roomShape.Y == roomSize.Y):
			return roomToMake.instantiate()
			

func spawnFloorSection(x, y, roomSize, filledGrid):
	if(roomSize == null):
		return;
	var floorInst = getRandomScene(roomSize)
	floorInst.position.x = x*24;
	floorInst.position.y = 0;
	floorInst.position.z = y*24;
	self.add_child(floorInst);
	fillGridFromBy(filledGrid, x, y, roomSize)
	
func fillGridFromBy(filledGrid, x, y, roomSize):
	if(y == 14 or x == 14):
		return #This is a bug from somewhere that should be fixed really
	filledGrid[y][x] = 1;
	for xOffset in range(roomSize.X):
		for yOffset in range(roomSize.Y):
			filledGrid[y + yOffset][x + xOffset] = 1;
	
func _ready():
	height = mazeSize;
	width = mazeSize;
	getValidRoomShapes();
	maze = GridHelpers.createMultiCheckpointMaze(mazeSize, mazeSize, directionBias, randomness, minLengthRun, maxLengthRun, numberOfExtraPoints);
	var filledGrid = GridHelpers.createEmptyGrid(mazeSize, mazeSize)
	var groupedGrid = groupGridNumbers(maze.grid);
	var playerInst = player.instantiate()
	playerInst.position = Vector3(24*maze.startPosition.x + 12, 1, 24*maze.startPosition.y + 12);
	self.add_child(playerInst);		
	for x in range(width):
		for y in range(height):
			if(maze.grid[y][x] == 1 && filledGrid[y][x] == 0):
				spawnFloorSection(x, y, groupedGrid[y][x], filledGrid);
#				spawnWalls(x, y);
#				spawnDoors(x, y);


