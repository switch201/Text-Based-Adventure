using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameActions;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Actors;
using Text_Based_Adventure.Engine.MenuTrees;

namespace Text_Based_Adventure.Engine.GameVerbs
{
    internal class TalkTo : GameVerb
    {
        public override string KeyWord => throw new NotImplementedException();

        public override void PerformAction(GameController controller, GameAction action)
        {
            controller.OpenAIManager.currentNPC = (NPC)action.DirectObject;
            controller.CurrentState = GameState.Dialog;
        }

        public override GameObject? SelectDirectObject(GameController controller)
        {
            var tree = new GameObjectsMenuTree<NPC>("Who do you want to talk to?", controller.RoomController.CurrentRoom.GetNPCs());
            return tree.PickSelection(true).Selection;
        }
    }
}
