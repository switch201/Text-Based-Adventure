using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Actors;

namespace Text_Based_Adventure.Engine.Controllers
{
    internal class PlayerController
    {
        public Player Player;
        public void LoadPlayer(Player player)
        {
            this.Player = player;
        }
    }
}
