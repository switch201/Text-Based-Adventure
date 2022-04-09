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

            Util.wl("Enter your name...");

            Util.rl();

            Util.wl("It means nothing now");

            gameState.RunGame();

            GameController gameController = new GameController(gameState, testGame);

            gameController.StartGame();

            while (gameController.gameState.currentGameState != States.Exit)
            {
                gameController.TakeUserInputAndRespond();
            }

        }
    }
}
