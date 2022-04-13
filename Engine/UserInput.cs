using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameStates;
using Text_Based_Adventure.Engine.InputActions;
using System.Linq;

namespace Text_Based_Adventure.Engine
{
    public class UserInput
    {
        List<InputAction> gameActions;

        public UserInput()
        {
            gameActions = new List<InputAction>()
            {
                new Go(),
                new Exit(),
                new Inspect(),
                new SearchFor(),
                new Take(),
                new Drop()
            };
        }

        public void AcceptStringInput(string userInput, GameController gameController)
        {
            userInput = userInput.ToLower();

            string userOutput;

            List<string> seperatedInputWords = new List<string>(userInput.Split(' '));

            foreach(InputAction action in gameActions)
            {
                if (action.keyWord.Contains(seperatedInputWords.First()))
                {
                    action.RespondToInput(gameController, seperatedInputWords);
                }
            }
        }

    }
}
