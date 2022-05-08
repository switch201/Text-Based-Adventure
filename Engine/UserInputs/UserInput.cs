using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameStates;
using Text_Based_Adventure.Engine.InputActions;
using System.Linq;
using Text_Based_Adventure.Engine.InputActions.BattleActions;
using Text_Based_Adventure.Engine.UserInputs.GameActions;

namespace Text_Based_Adventure.Engine
{
    public class UserInput
    {
        public static List<BattleAction> battleActions = new List<BattleAction>()
            {
                new Punch(),
                new RunAway()
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
                new Help()
            };

        public List<string> getKeyWords()
        {
            var list = new List<string>();
            foreach(GameAction action in gameActions)
            {
                list.Add(action.keyWord.First());
            }
            return list;
        }

        public GameAction GetGameAction(string keyWord)
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


        public void AcceptStringInput(string userInput, GameController gameController)
        {
            userInput = userInput.ToLower();

            string userOutput;

            List<string> seperatedInputWords = new List<string>(userInput.Split(' '));

            if(gameController.gameState.currentGameState == States.Combat)
            {
                foreach (BattleAction action in battleActions)
                {
                    if (action.keyWord.Contains(seperatedInputWords.First()))
                    {
                        action.RespondToInput(gameController, seperatedInputWords);
                        gameController.checkForCombatEnd();
                    }
                }
            }
            else
            {
               GetGameAction(seperatedInputWords.First()).RespondToInput(gameController, seperatedInputWords);
            }
        }

    }
}
