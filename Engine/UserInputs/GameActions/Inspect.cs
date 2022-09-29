using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using Text_Based_Adventure.Engine.Scripts;

namespace Text_Based_Adventure.Engine.InputActions
{
    class Inspect : GameAction
    {
        public override List<string> keyWord => new List<string>() { "inspect", "examine" };

        public override int duration => 0;

        public override string HelpText()
        {
            throw new NotImplementedException();
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directObjectString = seperatedWords.Last();
            if (directObjectString == "room")
            {
                controller.roomController.InspectRoom();
            }
            else if (directObjectString == "self")
            {
                controller.playerController.player.InspectSelf();
            }
            else if (directObjectString == "inventory")
            {
                controller.playerController.player.InspectInventory();
            }
            else
            {
                var directObject = controller.roomController.TryGetGameObject(directObjectString);
                if(directObject != null)
                {

                }
                directObject.Script.React(directObject, this);
                directObject.Inspect();
            }
            
        }
    }
}
