﻿using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Engine.InputActions
{
    public class Go : InputAction
    {
        public override string keyWord => "go";

        public override void RespondToInput(GameController controller, string[] seperatedWords)
        {
            controller.roomController.AttemptToChangeRooms(seperatedWords[1]);
        }
    }
}
