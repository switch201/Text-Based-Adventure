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
            string itemName = seperatedWords.Last();
            var item = controller.roomController.currentRoom.getItem(itemName);
            if(item == null)
            {
                Util.wl("You don't see that"); // TODO put in a shared place.
            }
            else if (item.isLocked(this))
            {
                var text = item.getLock(this).LockedText;
                Util.wl(text ?? $"The {item.Name} is Locked");
            }
            else if (item is Container)
            {
                controller.playerController.player.Inventory.AddRange(((Container)item).Open());
            }
            else
            {
                Util.wl("You can't open that");
            }
        }
    }
}
