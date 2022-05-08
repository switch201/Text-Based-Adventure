using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Based_Adventure.Engine.InputActions
{
    class SearchFor : GameAction
    {
        public override List<string> keyWord => new List<string>() { "search", "look", };

        public override string HelpText()
        {
            throw new NotImplementedException();
        }

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
            else if(directoObject == "people") // TODO need synonyms and also a case for search everything. which is when the direct object is "Search" (and seperatedWords is only 1 long)
            {
                controller.roomController.SearchForCreatures();
            }
            else {
                Util.wl("Search for what now??");
            }
        }
    }
}
