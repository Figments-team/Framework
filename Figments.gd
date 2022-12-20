class_name Figments

const VERSION = "0.1 alpha"

class IO:
	static func get_scene_path(scene_name: String, game_name: String = "") -> String:
		if(game_name != ""):
			return "res://" + game_name + "/" + scene_name + ".tscn"
		else:
			return "res://" + scene_name + ".tscn"

	static func search_scene_path(scene_name: String) -> String:
		var current_dir : DirAccess = DirAccess.open("res://")
		var scene_index : int = current_dir.get_files().find(scene_name)
		var dirs_to_explore: Array
		
		while scene_index == -1:
			for dir in current_dir.get_directories():
				dirs_to_explore.append(current_dir.get_current_dir() + "/" + dir)
			if(dirs_to_explore.size() > 0):
				current_dir.change_dir(dirs_to_explore.pop_back())
			scene_index = current_dir.get_files().find(scene_name)
		
		if scene_index:
			return current_dir.get_current_dir() + "/" + scene_name + ".tscn"
		else:
			return ""
