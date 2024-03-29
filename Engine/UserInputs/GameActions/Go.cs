﻿using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Rooms;
using System.Linq;

namespace Text_Based_Adventure.Engine.InputActions
{
    public class Go : GameAction
    {
        public override List<string> keyWord => new List<string>() {"go"};

        public override int duration => 1;

        public override string HelpText()
        {
            return "Use Go to move to another room!";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            controller.roomController.TryChangeRooms(seperatedWords.Last());
        }
    }
}
