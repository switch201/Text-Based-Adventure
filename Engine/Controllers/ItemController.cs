using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;

namespace Text_Based_Adventure.Engine.Controllers
{
    public class ItemController
    {
        Dictionary<string, Item> Items;
        ItemController(Dictionary<string, Item> items)
        {
            this.Items = items;
        }
    }
}
