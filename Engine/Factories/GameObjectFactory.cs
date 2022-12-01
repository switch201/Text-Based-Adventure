using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Factories.Converters;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Rooms;

namespace Text_Based_Adventure.Engine.Factories
{
    internal static class GameObjectFactory
    {
        private static string baseLevelPath = "Content/TestLevel2"; // TODO make this based on the level selected in levelFactory

        private static GameObjectConverter gameObjectConverter = new GameObjectConverter();

        private static RoomConverter roomConverter = new RoomConverter();

        //private static ItemConverter itemConverter = new ItemConverter();

        //private static CreatureConverter creatureConverter = new CreatureConverter();
        public static Room? CreateRoom(string objectName)
        {
            var obj = JsonConvert.DeserializeObject<Room>(Util.Readfile($"{baseLevelPath}/Rooms/{objectName}.json"), roomConverter);
            obj.Name = objectName;
            return obj;
        }

        public static T CreateGameObject<T>(string objectName) where T : GameObject
        {
            var obj = JsonConvert.DeserializeObject<T>(Util.Readfile($"{baseLevelPath}/GameObjects/{objectName}.json"), gameObjectConverter);
            return obj;
        }

        //public static Item CreateItem(string objectName)
        //{
        //    var obj = JsonConvert.DeserializeObject<Item>(Util.Readfile($"{baseLevelPath}/Items/{objectName}.json"), itemConverter);
        //    obj.Name = objectName;
        //    return obj;
        //}
        
        //public static Consumable CreateConsumable(string objectName)
        //{
        //    var obj = JsonConvert.DeserializeObject<Consumable>(Util.Readfile($"{baseLevelPath}/Items/{objectName}.json"), itemConverter);
        //    obj.Name = objectName;
        //    return obj;
        //}

        //public static Weapon CreateWeapon(string objectName)
        //{
        //    var obj = JsonConvert.DeserializeObject<Weapon>(Util.Readfile($"{baseLevelPath}/Items/{objectName}.json"), itemConverter);
        //    obj.Name = objectName;
        //    return obj;
        //}

        //public static Container CreateContainer(string objectName)
        //{
        //    var obj = JsonConvert.DeserializeObject<Container>(Util.Readfile($"{baseLevelPath}/Items/{objectName}.json"), itemConverter);
        //    obj.Name = objectName;
        //    return obj;
        //}

        //public static Creature CreateCreature(string objectName)
        //{
        //    return JsonConvert.DeserializeObject<Creature>(Util.Readfile($"{baseLevelPath}/Creatures/{objectName}.json"), creatureConverter);
        //}

        //public static NPC CreateNPC(string objectName)
        //{
        //    return JsonConvert.DeserializeObject<NPC>(Util.Readfile($"{baseLevelPath}/Creatures/{objectName}.json"));
        //}

        //public static NPCAction CreateNPCAction(string objectName)
        //{
        //    return JsonConvert.DeserializeObject<NPCAction>(Util.Readfile($"{baseLevelPath}/MonsterActions/{objectName}.json"));
        //}
    }
}
