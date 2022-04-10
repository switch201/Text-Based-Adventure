﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Items;

namespace Text_Based_Adventure.Engine.InputActions
{
    class Drop : InputAction
    {
        public override string keyWord => "drop";

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directobject = seperatedWords.Last();
            Item item = controller.playerConttroller.DropItem(directobject);
            if (item != null)
            {
                //TODO need to put item back in room if over carrying capacity
                // no capacity as of now so don't care
                controller.roomController.AddItemToRoom(item);
            }
        }
    }
}
