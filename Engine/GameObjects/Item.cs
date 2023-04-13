using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameVerbs;

namespace Text_Based_Adventure.Engine.GameObjects
{
    // An Item is anything that the player can pick up and put in inventory, or things that can go in containers.
    // 
    internal class Item : Interactable
    {
        public Item()
        {
            Interactions.Add(new Take());
        }
        public int Quality { get; set; }
    }
}
