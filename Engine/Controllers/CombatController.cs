using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.Player;

namespace Text_Based_Adventure.Engine.Controllers
{
    public class CombatController
    {
        private PlayerObject player;
        private List<NPC> enemies;

        public void setPlayer(PlayerObject player)
        {
            this.player = player;
        }
        public void setEnemies(List<NPC> enemies)
        {
            this.enemies = enemies;
        }

        public List<NPC> GetEnemies()
        {
            return this.enemies;
        }

        public PlayerObject GetPlayer()
        {
            return this.player;
        }
    }
}
