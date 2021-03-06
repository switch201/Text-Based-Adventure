using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.GameObjects.Items.Equipables;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
using Text_Based_Adventure.Engine.Player;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.Controllers
{
    public class PlayerController
    {
        public PlayerObject player;

        //Attempt here is for player based checks of can this item be taken
        public void AttemptToTakeItem(Item item)
        {
            player.Inventory.addItem(item);
            Util.wl($"You take the {item.Name}");
        }



        //TODO need checks for if item is already equiped
        //TODO need to specify right hand left hand etc.
        public void AttemptToEquipItem(Equipable item){
            this.player.Equip(item);
            Util.wl($"You equip the {item.Name}");
        }

        public void CheckConsumableTime(int gameTime)
        {
            if(this.player != null)
            {
                this.player.CheckConsumableTimeAndRemove(gameTime);
            }
        }

        //TODO What happens when it is not a consumable?
        public void AttemptToEatConsumable(string itemName, int gameTime)
        {
            Consumable item = null;
            try
            {
                item = (Consumable)player.Inventory.getItem(itemName);
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
            player.Eat((Consumable)player.Inventory.removeItem(itemName), gameTime);
        }

        public Item DropItem(string itemName)
        {
            Item item = player.Inventory.getItem(itemName);
            if(item == null)
            {
                Util.wl($"You aren't carrying a {itemName}");
                return null;
            }
            Util.wl($"You drop the {item.Name}");
            return player.Inventory.removeItem(itemName);
        }

        public int AttributeCheck(Attribute attr)
        {
            return player.AttributeCheck(attr);
        }
    }
}
