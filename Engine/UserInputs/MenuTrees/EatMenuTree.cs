using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.Engine.UserInputs.GameActions;
using System.Linq;

namespace Text_Based_Adventure.Engine.UserInputs.MenuTrees
{
    public class EatMenuTree : MenuTree
    {
        // TODO add Room as well?
        public EatMenuTree(PlayerObject player) : base()
        {
            MenuStartText = "What do you want to eat?";
            var inventoryGroups = player.Inventory.GroupBy(x => x.Name);
            foreach (var inventoryGroup in inventoryGroups)
            {
                var item = inventoryGroup.First();
                var option = new MenuOption();
                var action = new Eat();
                option.PreSelectionText = $"{item.Name} ({inventoryGroup.Count()})";
                action.directObjectString = item.Name;
                option.Action = action;
                MenuOptions.Add(option);
            }
        }
    }
}
