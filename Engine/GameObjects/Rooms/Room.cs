using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Actors;

namespace Text_Based_Adventure.Engine.GameObjects.Rooms
{
    // A Room is well, a room. but it can also represent any "area" the player is able to enter.
    // A room represents the local space and can be many sizes
    internal class Room : GameObject
    {
        // This is All things Except the Player that are in a given room.
        //Could be NPCs, could be Scenary that does nothing,
        // Could be items chests We don't know
        [JsonIgnore]
        public List<GameObject> Contents = new List<GameObject>();

        [JsonProperty("contents")]
        private List<GameObject> ReadContents
        {
            get { return Contents; }
        }

        public List<Exit> Exits = new List<Exit>();

        public List<Item> GetItems()
        {
            return Contents.Where(x => x is Item).ToList().ConvertAll(x => (Item)x);
        }

        public List<Interactable> GetInteractables()
        {
            return Contents.Where(x => x is Interactable).ToList().ConvertAll(x => (Interactable)x);
        }

        public List<Container> GetContainers()
        {
            return Contents.Where(x => x is Container).ToList().ConvertAll(x => (Container)x);
        }

        public List<NPC> GetNPCs()
        {
            return Contents.Where(x => x is NPC).ToList().ConvertAll(x => (NPC)x);
        }
    }
}
