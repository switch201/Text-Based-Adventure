using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameStates;
using Text_Based_Adventure.Engine.InputActions;
using System.Linq;
using Text_Based_Adventure.Engine.InputActions.BattleActions;

namespace Text_Based_Adventure.Engine
{
    public class UserInput
    {
        List<InputAction> gameActions;
        private List<BattleAction> battleActions;

        public UserInput()
        {
            gameActions = new List<InputAction>()
            {
                new Go(),
                new Exit(),
                new Inspect(),
                new SearchFor(),
                new Take(),
                new Drop(),
                new TalkTo(),
                new Attack(),
            };

            battleActions = new List<BattleAction>()
            {
                new Punch(),
                new RunAway()
            };
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
                    }
                }
            }
            else
            {
                foreach (InputAction action in gameActions)
                {
                    if (action.keyWord.Contains(seperatedInputWords.First()))
                    {
                        action.RespondToInput(gameController, seperatedInputWords);
                    }
                }
            }
        }

    }
}
