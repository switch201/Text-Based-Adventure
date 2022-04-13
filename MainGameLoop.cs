using System;
using Text_Based_Adventure.Content;
using Text_Based_Adventure.Content.TestLevel;
using Text_Based_Adventure.Engine;
using Text_Based_Adventure.Engine.Games;
using Text_Based_Adventure.Engine.GameStates;
using Text_Based_Adventure.Engine.Levels;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure
{
    class MainGameLoop
    {
        static void Main(string[] args)
        {

            Level testLevel = new TestLevel();

            Game testGame = new Game(testLevel);

            GameState gameState = new GameState();

            gameState.LoadTitle();

            MainMenu.Start();

            Util.wl("Enter your name...");

            GameController gameController = new GameController(gameState, testGame);

            while (gameController.gameState.currentGameState == States.CharacterCreation)
            {
                gameController.TakeUserInputForCharacter();
            }

            gameState.RunGame();

            gameController.StartGame();

            while (gameController.gameState.currentGameState != States.Exit)
            {
                gameController.TakeUserInputAndRespond();
            }

        }
    }
}
