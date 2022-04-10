using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.Player.Stats
{
    public enum Stat
    {
        LockPicking,
        FireArms,
        Cooking,
    }
    public class StatsSet : Dictionary<Stat, int>
    {
        public StatsSet()
        {
            foreach (Stat stat in Enum.GetValues(typeof(Stat)))
            {
                this.Add(stat, 5);
            }
        }

        public void setStat(Stat stat, int value)
        {
            this.Remove(stat);
            this.Add(stat, value);
        }

        public int getStat(Stat stat)
        {
            return this.GetValueOrDefault(stat);
        }
    }
}
