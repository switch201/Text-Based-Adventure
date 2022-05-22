using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.GameObjects.Items
{
    public class Item : GameObject
    {

        public string DiscoverText;

        public string GrabText;

        public string QuallityText;

        public int hiddenModifier = 0;



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
    }
}
