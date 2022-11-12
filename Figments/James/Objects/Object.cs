using System;
using Godot;

namespace Figments.James.Objects
{
    public abstract class Object : Area2D
    {
        public abstract string Interact();

        public override string ToString()
        {
            return "[JamesObject]";
        }
    }
}