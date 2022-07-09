using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Doors;
using Text_Based_Adventure.Engine.Factories;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Containers;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
using Text_Based_Adventure.Engine.GameObjects.Items.Weapons;
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Rooms;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;

namespace Text_Based_Adventure.Content
{
    class TreasureRoom : Room
    {
        public TreasureRoom(string roomName) : base(roomName)
        {
            Consumable item = ItemFactory.MakeConsumable("pumpkinpie");
            Weapon shortSword = ItemFactory.MakeWeapon("shortsword");
            Container container = ItemFactory.MakeContainer("treasurechest");
            this.addItem(item);
            this.addItem(shortSword);
            this.addItem(container);
        }
    }
}
