using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Doors;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure
{
    class GameActions
    {
        public void Examine(GameObject g)
        {
            g.Describe();
        }

        public void Inspect(GameObject g)
        {
            g.Inspect();
        }

        public void Open(Door d) //TODO change this to be anything that can be opened not just doors
        {
            d.Open();
        }
    }
}
