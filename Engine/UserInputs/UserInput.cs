using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameStates;
using Text_Based_Adventure.Engine.InputActions;
using System.Linq;
using Text_Based_Adventure.Engine.InputActions.BattleActions;
using Text_Based_Adventure.Engine.UserInputs.GameActions;
using Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions;

namespace Text_Based_Adventure.Engine
{
    public class UserInput
    {
        public static List<SkillAction> skillActions = new List<SkillAction>()
        {
            new Break()
        };

        public static List<BattleAction> battleActions = new List<BattleAction>()
            {
                new Punch(),
                new RunAway(),
                new AttackWith()
            };

        public static List<GameAction> gameActions = new List<GameAction>()
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

        public static List<string> getGameActionWords()
        {
            var list = new List<string>();
            foreach(GameAction action in gameActions)
            {
                list.Add(action.keyWord.First());
            }
            return list;
        }
        public static List<string> getBattleActionWords()
        {
            var list = new List<string>();
            foreach (BattleAction action in battleActions)
            {
                list.Add(action.keyWord.First());
            }
            return list;
        }

        public static GameAction? GetGameAction(string keyWord)
        {
            foreach (GameAction action in gameActions)
            {
                if (action.keyWord.Contains(keyWord))
                {
                    return action;
                }
            }
            return null;
        }

        public static BattleAction? GetBattleActtion(string keyWord)
        {
            foreach (BattleAction action in battleActions)
            {
                if (action.keyWord.Contains(keyWord))
                {
                    return action;
                }
            }
            return null;
        }

        public static SkillAction? GetSkillAction(string keyWord)
        {
            foreach (SkillAction action in skillActions)
            {
                if (action.keyWord.Contains(keyWord))
                {
                    return action;
                }
            }
            return null;
        }

        public static Verb? GetVerb(string keyWord)
        {
            Verb? verb = GetGameAction(keyWord);
            return verb != null ? verb : GetBattleActtion(keyWord); 

        }


        public void AcceptStringInput(string userInput, GameController gameController)
        {
            userInput = userInput.ToLower();

            string userOutput;

            List<string> seperatedInputWords = new List<string>(userInput.Split(' '));

            if(gameController.gameState.currentGameState == States.Combat)
            {
                BattleAction validAction = GetBattleActtion(seperatedInputWords.First());
                if (validAction == null)
                {
                    Util.wl("That is not a valid action. Type 'help action' to see a list of valid actions");
                }
                else
                {
                    validAction.RespondToInput(gameController, seperatedInputWords);
                    gameController.gameState.adjustGameClock(validAction.duration);
                }
            }
            else
            {
                GameAction validAction = GetGameAction(seperatedInputWords.First());
                if(validAction == null)
                {
                    Util.wl("That is not a valid action. Type 'help action' to see a list of valid actions");
                }
                else{

                    validAction.RespondToInput(gameController, seperatedInputWords);
                    gameController.gameState.adjustGameClock(validAction.duration);
                }
            }
        }

    }
}
