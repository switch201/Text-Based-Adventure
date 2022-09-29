using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Containers;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions
{
    class Open : GameAction
    {
        public override List<string> keyWord => new List<string>() { "open" };

        public override int duration => 1;

        public override string HelpText()
        {
            return "you can open containers by typing 'open <containerName>'";
        }

        //TODO something does't feel right here I think I need to simplify this pattern.
        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directObjectString = seperatedWords.Last();
            var directObject = controller.roomController.TryGetGameObject(directObjectString);
            if(directObject != null)
            {
                directObject.Script.React(directObject, this);
                if (directObject is Container)
                {
                    controller.playerController.TryTakeItems(((Container)directObject).Open());
                }
                else
                {
                    Util.WriteExceptionSentance("You can't open", directObjectString);
                }
            }
            else {
                Util.GameObjectNotInRoom(directObjectString);
            }
        }
    }
}
