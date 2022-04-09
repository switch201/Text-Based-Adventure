﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Based_Adventure.Engine.InputActions
{
    class SearchFor : InputAction
    {
        public override string keyWord => "search";

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directoObject = seperatedWords.Last();

            if(directoObject == "exits")
            {
                controller.roomController.SearchForExits();
            }
            else if(directoObject == "items")
            {

            }
            else {
                Util.wl("Search for what now??");
            }
        }
    }
}
