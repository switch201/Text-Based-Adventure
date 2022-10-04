using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.UserInputs.GameActions;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Engine.UserInputs.MenuTrees
{
    public class GoMenuTree : MenuTree
    {
        public GoMenuTree(Room room) : base()
        {
            MenuStartText = "Which way do you want to go";
            foreach (string exit in room.getExits().Keys)
            {
                var option = new MenuOption();
                option.PreSelectionText = exit;
                var go = new Go();
                go.directObjectString = exit;
                option.Action = go;
                MenuOptions.Add(option);
            }
        }
    }
}
