@tool
extends Node

var hasRun = false

func _ready():
	print("Hello")

func _process(delta):
	if hasRun:
		return
	#hasRun = true
	#print('hello2')
	var bootstrapper = get_node('../GridMapBootstrapper')
	if (bootstrapper.Generator):
		print(bootstrapper.Generator)
	#	print(bootstrapper)
	#	print(bootstrapper.get_script())
	#	bootstrapper.get_script().run
