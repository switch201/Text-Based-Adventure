using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameVerbs;

namespace Text_Based_Adventure.Engine.GameActions
{
    internal class GameAction
    {
        public GameVerb Verb;
        public GameObject DirectObject;

        public GameAction(GameVerb verb, GameObject directObject)
        {
            Verb = verb;
            DirectObject = directObject;
        }

        public void PreformAction(GameController controller)
        {
            this.Verb.PerformAction(controller, this);
        }

        // Public get Skill checks
        // Gets a list of skill checks which need to be based on the the direction object in question and the verb being done to it.
        // EX: Verb: PickLock, Object: SimpleChest,
        // EX Verb: PickLock, Object: StrongChest,
        // EX Verb: Bash, Object: StrongChest,
        // Game Object sill have a list of locks on it for now they can not be layered.
        // Each Lock has a skill action tied to it and a unlock value
        // When attaempting to peform this game action, if the DirectObject has a Lock on it, you can only do skill Actions on said object otherwise tells you
        // that its locked when trying to perform non skill check actions on object
        // EX: Go west, room is locked, says you can't go.
        // Ex: open chest
        // EX: TalkTo NPC?
    }
}
