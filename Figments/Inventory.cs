using System;
using System.Collections.Generic;
using Godot;

namespace Figments
{
    public class Inventory
    {
        private List<Figments.Objects.Item> items;
        public List<Figments.Objects.Item> Items { get => items; }

        public void AddItem(Figments.Objects.Item itemToAdd)
        {
            items.Add(itemToAdd);
        }
        
        public void RemoveItem(Figments.Objects.Item itemToRemove)
        {
            items.Remove(itemToRemove);
        }

        public int[] SearchItem(Figments.Objects.Item itemToSearch)
        {
            List<int> foundIndexes = new List<int>();
            for(int i = 0; i < items.Count; i++)
                if(items[i] == itemToSearch)
                    foundIndexes.Add(i);
            return foundIndexes.ToArray();
        }
    }
}