using System;
using Text_Based_Adventure.Engine;
using Text_Based_Adventure.Engine.Factories;
using Text_Based_Adventure.Engine.Games;
using Text_Based_Adventure.Engine.GameStates;
using Text_Based_Adventure.Engine.Levels;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure
{
    class MainGameLoop
    {
        static void Main(string[] args)
        {
            Console.Title = "Text Based Adventure";

            GameState gameState = new GameState();

            GameController gameController = new GameController(gameState);

            while (gameController.gameState.currentGameState != States.Exit)
            {
                Level testLevel = LevelFactory.MakeLevel("TestLevel2");

                Game testGame = new Game(testLevel);

                gameState.LoadTitle();

                Util.wl("Enter your name...");

                gameController.setGame(testGame);

                gameController.TakeUserInputForClass(Util.debugMode);

                //gameController.TakeUserInputForCharacter();

                gameController.StartGame();

                while (gameController.gameState.currentGameState != States.Exit && gameController.gameState.currentGameState != States.GameOver)
                {
                    gameController.TakeUserInputAndRespond();
                    Util.log($"Current GameTime {gameController.gameState.getGameTime()}");
                }
                Util.wl("Type anything to continue");
                Util.rl();
            }

        }
    }
}
