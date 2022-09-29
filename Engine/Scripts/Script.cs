using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.InputActions;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.Scripts
{
    public abstract class Script
    {
        /// <summary>
        /// When implemented, Upddates the attached game object every game loop
        /// </summary>
        /// <param name="self"></param>
        public abstract void Update(GameObject self);

        /// <summary>
        /// When an action is taken on this game object react in some way
        /// </summary>
        /// <param name="self"></param>
        /// <param name="Action"></param>
        /// <returns>true if reaction should short circuit the given action</returns>
        public abstract bool React(GameObject self, Verb Action);

        public abstract void onMessage(GameObject self, string messageId, string message, GameObject sender);
    }
}
