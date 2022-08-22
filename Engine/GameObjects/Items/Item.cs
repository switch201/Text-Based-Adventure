using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Containers;
using Text_Based_Adventure.Engine.GameObjects.Items.Equipables;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.GameObjects.Items
{

    // TODO need class for any Item, Creature etc. that can exist inside a room.
    public class Item : GameObject
    {

        public string DiscoverText;

        public string GrabText;

        public string QuallityText;

        public int hiddenModifier = 0;

        public int Cost; //TODO UOM

        public int Weight; //TODO UOM



        public void Discover()
        {
            Util.wl(this.DiscoverText);
        }

        public bool HasDiscoverText()
        {
            return this.DiscoverText == "";
        }

        public void getQuality()
        {
            Util.wl(this.QuallityText);
        }

        public void Grab()
        {
            Util.wl(this.GrabText);
        }

        public bool IsConsumable()
        {
            return this is Consumable;
        }

        public bool IsEquipable()
        {
            return this is Equipable;
        }

        public bool IsContainer()
        {
            return this is Container;
        }
    }
}
