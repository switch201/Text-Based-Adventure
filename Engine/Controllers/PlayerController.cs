using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.Player;

namespace Text_Based_Adventure.Engine.Controllers
{
    public class PlayerController
    {
        public PlayerObject player;

        //Attempt here is for player based checks of can this item be taken
        public void AttemptToTakeItem(Item item)
        {
            player.inventory.addItem(item);
            Util.wl($"You take the {item.Name}");
        }

        public Item DropItem(string itemName)
        {
            Item item = player.inventory.getItem(itemName);
            if(item == null)
            {
                Util.wl($"You aren't carrying a {itemName}");
                return null;
            }
            Util.wl($"You drop the {item.Name}");
            return player.inventory.removeItem(itemName);
        }
    }
}
