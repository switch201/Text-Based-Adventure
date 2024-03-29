﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;

namespace Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables
{
    public class Consumable : SmallItem
    {
        public int HealingValue;

        [JsonIgnore]
        public List<AttributeModifierSet> AttributeModifers; //TODO make this a list and different stuff can have different durations.

        public Consumable()
        {
            AttributeModifers = new List<AttributeModifierSet>();
        }
    }
}
