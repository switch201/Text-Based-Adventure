using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Items;

namespace Text_Based_Adventure.Engine.InputActions
{
    class Take : GameAction
    {
        public override List<string> keyWord => new List<string>() { "take", "grab", };

        public override int duration => 1;

        public override string HelpText()
        {
            throw new NotImplementedException();
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directobject = seperatedWords.Last();
            Item item = controller.roomController.AttemptToTakeItem(directobject);
            if(item != null)
            {
                //TODO need to put item back in room if over carrying capacity
                // no capacity as of now so don't care
                controller.playerController.AttemptToTakeItem(item);
            }
        }
    }
}
