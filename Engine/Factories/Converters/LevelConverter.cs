using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Rooms;
using Text_Based_Adventure.Engine.Levels;

namespace Text_Based_Adventure.Engine.Factories.Converters
{
    internal class LevelConverter : JsonConverter<Level>
    {
        protected string LevelPath;

        public override Level? ReadJson(JsonReader reader, Type objectType, Level? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Level level = new Level();
            JObject obj = JObject.Load(reader);
            foreach (string room in obj["Rooms"])
            {
                level.Rooms.Add(GameObjectFactory.CreateRoom(room));
            }
            //TODO make a connection class/factory
            foreach(var connection in obj["Connections"])
            {
                var room1 = level.Rooms.Single(x => x.Name == (string)connection["Room1"]);
                var room2 = level.Rooms.Single(x => x.Name == (string)connection["Room2"]);
                room1.Exits.Add(new Exit()
                {
                    Direction = connection["ExitDirection"].ToObject<Direction>(),
                    EnteringRoom = room2,
                    Description = connection["ExitDirection"].ToObject<string>()
                });
                room2.Exits.Add(new Exit()
                {
                    Direction = connection["EnterDirection"].ToObject<Direction>(),
                    EnteringRoom = room1,
                    Description = connection["EnterDirection"].ToObject<string>()
                });
            }
            level.WorldBackStory = (string)obj["WorldBackStory"];
            //foreach(string gameClass in obj["GameClasses"])
            //{
            //    level.GameClasses.Add(GameClassFactory.MakeClass(gameClass));
            //}
            return level;
        }

        public override void WriteJson(JsonWriter writer, Level? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
