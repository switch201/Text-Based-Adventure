using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.UserInputs.GameActions;
using System.Linq;

namespace Text_Based_Adventure.Engine.UserInputs.MenuTrees
{
    public class MainGameMenuTree : MenuTree
    {
        private static List<GameAction> gameActions = new List<GameAction>()
        {
            new Go(),
            new Exit(),
            new Inspect(),
            new SearchFor(),
            new Take(),
            new Drop(),
            new TalkTo(),
            new Attack(),
            new Help(),
            new Eat(),
            new Equip(),
            new Open()
        };
        public MainGameMenuTree() : base() {
            foreach ( GameAction action in gameActions)
            {
                var option = new MenuOption();
                option.PreSelectionText = action.keyWord.First();
                option.Action = action;
                MenuOptions.Add(option);
            }
        }
    }
}
