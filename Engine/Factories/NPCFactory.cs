using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Items.Equipables;

namespace Text_Based_Adventure.Engine.Factories
{
    class NPCFactory : Factory
    {
        public static NPC MakeNPC(string npcName)
        {
            var npc = JsonConvert.DeserializeObject<NPC>(Util.Readfile($"{basePath}/GameObjects/NPCs/{npcName}Text.json"));
            foreach(string weapon in npc.Weapons)
            {
                npc.Inventory.addItem(ItemFactory.MakeWeapon(weapon));
            }
            npc.Equip((Equipable)Util.RandomFromList(npc.Inventory));
            return npc;
        }
    }
}
