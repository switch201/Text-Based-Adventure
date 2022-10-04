using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.UserInputs.BattleActions;
using System.Linq;

namespace Text_Based_Adventure.Engine.UserInputs.MenuTrees
{
    public class MainCombatMenuTree : MenuTree
    {
        public static List<BattleAction> battleActions = new List<BattleAction>()
        {
            new Punch(),
            new RunAway(),
            new AttackWith(),
            //new BattleEquip(),
            //new BattleInspect(),
            //new GetClose(),
         };

        public MainCombatMenuTree() : base()
        {
            foreach (BattleAction action in battleActions)
            {
                var option = new MenuOption();
                option.PreSelectionText = action.keyWord.First();
                option.Action = action;
                MenuOptions.Add(option);
            }
        }

    }
}
