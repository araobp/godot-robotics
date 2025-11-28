extends Node3D

@onready var skeleton: Skeleton3D = $RobotArm/Skeleton3D

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass	

var n = 0
func _on_timer_timeout() -> void:
	var base_bone_idx = skeleton.find_bone("Bone")
	var base_bone_pose = skeleton.get_bone_pose(base_bone_idx)
	var new_rotation := Quaternion(Vector3(0, 1, 0), PI / 4 * n)
	skeleton.set_bone_pose_rotation(base_bone_idx, new_rotation)
	print(n)
	n += 1
