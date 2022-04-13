﻿using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Engine
{
    public abstract class InputAction
    {
        public abstract List<string> keyWord { get; }

        public abstract void RespondToInput(GameController controller, List<string> seperatedWords);

    }
}
