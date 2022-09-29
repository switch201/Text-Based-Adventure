using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Creatures;

namespace Text_Based_Adventure.Engine.InputActions
{
    public class Attack : GameAction
    {
        public override List<string> keyWord => new List<string>() { "attack" };

        public override int duration => 0;

        public override string HelpText()
        {
            return "Use Attack to Start Combat";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            var directObjectString = seperatedWords.Last();
            var directObject = controller.roomController.TryGetGameObject(directObjectString);
            if (!directObject.Script.React(directObject, this))
            {
                if(directObject is Creature)
                {
                    controller.StartCombat();
                }
                else
                {
                    Util.WriteExceptionSentance("You can't attack", directObjectString);
                }
            }
        }
    }
}
