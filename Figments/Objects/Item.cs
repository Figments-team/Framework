using System;
using Godot;

namespace Figments.Objects
{
    public class Item
    {
        private string id;
        public string ID { get => id; }
        private string name;
        public string Name { get => name; }

        private Figments.Objects.BehaviourData itemBehaviour;
        public Figments.Objects.BehaviourData ItemBehaviour { get => itemBehaviour; }

        public static explicit operator Item(object objectToCast)
        {
            
            return new Item();
        }
    }
}