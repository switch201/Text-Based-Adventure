using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameTools;

namespace Text_Based_Adventure.Engine.GameClasses
{
    public enum Proficiencies
    {
        LightArmor,
        MediumArmor,
        Shields,
        SimpleWeapons,
        MartialWeapons
    }
    public class GameClass
    {
        int ProficencyBonus; // Current Proficency Bonus
        DiceSet HitDice;
        int Health;
        List<Proficiencies> Proficiencies;
    }
}
