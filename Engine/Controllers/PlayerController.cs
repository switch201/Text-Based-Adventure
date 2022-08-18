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
        public void TryTakeItem(Item item)
        {
            player.Inventory.AddItem(item);
            Util.wl($"You take the {item.Name}");
        }



        //TODO need checks for if item is already equiped
        //TODO need to specify right hand left hand etc.
        public void TryEquipItem(string itemName){
            if (player.Inventory.IsItemInInventory(itemName))
            {
                var item = player.Inventory.GetItem(itemName);
                if (item.IsEquipable())
                {
                    this.player.Equip((Equipable)item);
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
                if (item.IsConsumable())
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
