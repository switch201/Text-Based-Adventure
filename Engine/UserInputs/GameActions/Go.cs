using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Engine.InputActions
{
    public class Go : GameAction
    {
        public override List<string> keyWord => new List<string>() {"go"};

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            controller.roomController.AttemptToChangeRooms(seperatedWords[1]);
        }
    }
}
