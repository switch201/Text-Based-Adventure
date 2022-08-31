using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.GameObjects.SkillChecks
{
    public abstract class SkillCheckOutcome
    {
        public abstract void BestOutcome(GameController? gameController, GameObject? directObject);

        public abstract void GoodOutcome(GameController? gameController, GameObject? directObject);

        public abstract void BadOutcome(GameController? gameController, GameObject? directObject);

        public abstract void WorstOutcome(GameController? gameController, GameObject? directObject);
    }
}
