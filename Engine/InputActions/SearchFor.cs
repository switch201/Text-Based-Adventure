using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Based_Adventure.Engine.InputActions
{
    class SearchFor : InputAction
    {
        public override List<string> keyWord => new List<string>() { "search", "look", };

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directoObject = seperatedWords.Last();

            if(directoObject == "exits" || directoObject == "exit")
            {
                controller.roomController.SearchForExits();
            }
            else if(directoObject == "items")
            {
                controller.roomController.SearchForItems();
            }
            else {
                Util.wl("Search for what now??");
            }
        }
    }
}
