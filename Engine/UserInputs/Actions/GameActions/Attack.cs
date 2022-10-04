using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Creatures;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions
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
            string directObject;
            List<NPC> npcs = controller.roomController.currentRoom.NPCs;

            if (seperatedWords.Count > 1)
            {
                directObject = seperatedWords.Last();
                Creature npc = Util.NameOrIdentifier(npcs, directObject);
                if(npc != null)
                {
                    controller.StartCombat(); // TODO specific person combat
                }
                else
                {
                    Util.wl($"You don't see or can't attack a {directObject}");
                    return;
                }
            }
            //TODO check if there is an NPC that can be attacked
            else if (npcs.Count == 1)
            {
                controller.StartCombat();
            }
            else
            {
                Util.wl("There is no one to attack");
            }
            
            
        }

        public override void RespondToInput(GameController controller, string direcObject)
        {
            throw new NotImplementedException();
        }

        public override void RespondToInput(GameController controller)
        {
            throw new NotImplementedException();
        }
    }
}
