using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.GameObjects.Scripts
{
    // Scripts are the brain of a given game object. 
    // Some object like rocks are dumb and won't do much
    // Other objects like people will be more complex

    // A Script is Reactive.
    // A Script defines what things can see and what happens when they see them
    internal abstract class Script
    {
        protected GameObject Self; // The game object this script is attached to.

        public Script(GameObject self)
        {
            this.Self = self;
        }

        //public abstract void React(GameEvent event);
    }
}
