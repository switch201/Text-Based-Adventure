using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Factories.Converters;
using Text_Based_Adventure.Engine.GameObjects.Containers;
using Text_Based_Adventure.Engine.GameObjects.Creatures;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
using Text_Based_Adventure.Engine.GameObjects.Items.Weapons;
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Engine.Factories
{
    public static class GameObjectFactory
    {
        private static string baseLevelPath = "Content/TestLevel2"; // TODO make this based on the level selected in levelFactory

        private static RoomConverter roomConverter = new RoomConverter();

        private static ItemConverter itemConverter = new ItemConverter();
        public static Room? CreateRoom(string objectName)
        {
            var obj = JsonConvert.DeserializeObject<Room>(Util.Readfile($"{baseLevelPath}/Rooms/{objectName}.json"), roomConverter);
            obj.Name = objectName;
            return obj;
        }

        public static Item CreateItem(string objectName)
        {
            var obj = JsonConvert.DeserializeObject<Item>(Util.Readfile($"{baseLevelPath}/Items/{objectName}.json"), itemConverter);
            obj.Name = objectName;
            return obj;
        }

        public static Consumable CreateConsumable(string objectName)
        {
            var obj = JsonConvert.DeserializeObject<Consumable>(Util.Readfile($"{baseLevelPath}/Items/{objectName}.json"), itemConverter);
            obj.Name = objectName;
            return obj;
        }

        public static Weapon CreateWeapon(string objectName)
        {
            var obj = JsonConvert.DeserializeObject<Weapon>(Util.Readfile($"{baseLevelPath}/Items/{objectName}.json"), itemConverter);
            obj.Name = objectName;
            return obj;
        }

        public static Container CreateContainer(string objectName)
        {
            var obj = JsonConvert.DeserializeObject<Container>(Util.Readfile($"{baseLevelPath}/Items/{objectName}.json"), itemConverter);
            obj.Name = objectName;
            return obj;
        }

        public static Creature CreateCreature(string objectName)
        {

        }
    }
}
