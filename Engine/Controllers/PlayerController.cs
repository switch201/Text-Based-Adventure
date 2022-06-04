using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
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

        public void CheckConsumableTime(int gameTime)
        {
            this.player.CheckConsumableTimeAndRemove(gameTime);
        }

        //TODO What happens when it is not a consumable?
        public void AttemptToEatConsumable(string itemName, int gameTime)
        {
            Consumable item = null;
            try
            {
                item = (Consumable)player.inventory.getItem(itemName);
            }
            catch (InvalidCastException e)
            {
                Util.wl($"You can't eat a {itemName}. It's not good for you.");
                return;
            }
            if (item == null)
            {
                Util.wl($"You aren't carrying a {itemName}");
                return;
            }

            Util.wl($"You eat the {item.Name}");
            player.Eat((Consumable)player.inventory.removeItem(itemName), gameTime);
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
