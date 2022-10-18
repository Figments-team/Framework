using System;
using System.Reflection;
using System.IO;
using Godot;

namespace Figments.IO
{
    public static class SavesFolder
    {
        private static readonly Tuple<PathType, string>[] RequiredStructure =
        {
            Tuple.Create(PathType.Directory, "user://Items"),
            Tuple.Create(PathType.File, "user://inventory.json"),
            Tuple.Create(PathType.File, "user://save.json")
        };
        
        public static bool IsReady
        {
            get
            {
                foreach (Tuple<PathType, string> path in RequiredStructure)
                    if(path.Item1 == PathType.Directory && !System.IO.Directory.Exists(path.Item2))
                        return false;
                    else if(path.Item1 == PathType.File && !System.IO.File.Exists(path.Item2))
                        return false;
                
                return true;
            }
        }

        public static void Prepare(bool force = false)
        {
            if(!IsReady || force)
                foreach (Tuple<PathType, string> path in RequiredStructure)
                    if(path.Item1 == PathType.Directory)
                        System.IO.Directory.CreateDirectory(ProjectSettings.GlobalizePath(path.Item2));
                    else if(path.Item1 == PathType.File)
                        System.IO.File.Create(ProjectSettings.GlobalizePath(path.Item2));
        }
    }
}