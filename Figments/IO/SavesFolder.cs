using System;
using System.Reflection;
using System.IO;
using Godot;

namespace Figments.IO
{
    public static class SavesFolder
    {
        private static Tuple<PathType, string>[]? RequiredStructure = null;

        public static bool IsValid
        {
            get
            {
                if(RequiredStructure != null)
                    return true;
                else
                    return false;
            }
        }
        
        public static bool IsReady
        {
            get
            {
                if(IsValid)
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
            if((!IsReady || force) && IsValid)
                foreach (Tuple<PathType, string> path in RequiredStructure)
                    if(path.Item1 == PathType.Directory)
                        System.IO.Directory.CreateDirectory(ProjectSettings.GlobalizePath(path.Item2));
                    else if(path.Item1 == PathType.File)
                        System.IO.File.Create(ProjectSettings.GlobalizePath(path.Item2));
        }
    }
}