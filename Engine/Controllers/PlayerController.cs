using System.Collections.Generic;
using Text_Based_Adventure.Engine.GameObjects.Creatures;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.GameObjects.Items.Equipables;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
using Text_Based_Adventure.Engine.Player;
using System.Linq;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.Controllers
{
    public class PlayerController
    {
        public PlayerObject player;

        //Attempt here is for player based checks of can this item be taken
        public void TryTakeItem(Item item)
        {
            player.Inventory.AddItem(item);
            Util.wl($"You take the {item.Name}");
        }

        public void TryTakeItems(List<Item> items)
        {
            if (items.Any())
            {
                player.Inventory.AddRange(items);
                Util.wl("You take the items");
            }
        }



        //TODO need checks for if item is already equiped
        //TODO need to specify right hand left hand etc.
        public void TryEquipItem(string itemName){
            if (player.Inventory.IsItemInInventory(itemName))
            {
                var item = player.Inventory.GetItem(itemName);
                if (item is Equipable)
                {
                    this.player.Equip((Equipable)item, WeaponSlot.RightHand);
                    Util.wl($"You equip the {item.Name}");
                }
                else
                {
                    Util.WriteExceptionSentance("you can't equip", itemName);
                }
            }
            else
            {
                ItemNotInInventory(itemName);
            }
            
        }

        public void CheckConsumableTime(int gameTime)
        {
            if(this.player != null)
            {
                this.player.CheckConsumableTimeAndRemove(gameTime);
            }
        }

        //TODO What happens when it is not a consumable?
        public void TryEatConsumable(string itemName, int gameTime)
        {
            if (player.Inventory.IsItemInInventory(itemName))
            {
                var item = player.Inventory.GetItem(itemName);
                if (item is Consumable)
                {
                    player.Eat((Consumable)player.Inventory.RemoveItem(itemName), gameTime); ;
                }
                else
                {
                    Util.WriteExceptionSentance("You can't eat", itemName);
                }
            }
            else
            {
                ItemNotInInventory(itemName);
            }
        }

        public Item? TryDropItem(string itemName)
        {

            if (player.Inventory.IsItemInInventory(itemName))
            {
                Util.wl($"You drop the {itemName}");
                return player.Inventory.RemoveItem(itemName);
            }
            else
            {
                ItemNotInInventory(itemName);
                return null;
            }
        }

        public int AttributeCheck(Attribute attr)
        {
            return player.AttributeCheck(attr);
        }

        private void ItemNotInInventory(string itemName)
        {
            Util.WriteExceptionSentance("You aren't carrying", itemName);
        }
    }
}
