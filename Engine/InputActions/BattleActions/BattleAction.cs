﻿using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;

namespace Text_Based_Adventure.Engine.InputActions.BattleActions
{
    public abstract class BattleAction : InputAction
    {

        protected static Random r = new Random();
        public abstract void RespondToInput(CombatController controller, List<string> seperatedWords);
    }
}
