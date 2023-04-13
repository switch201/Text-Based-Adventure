using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Games;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Actors;
using Text_Based_Adventure.Engine.MenuTrees;
using Text_Based_Adventure.Engine.GameVerbs;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameActions;

namespace Text_Based_Adventure.Engine.Controllers
{
    public enum GameState
    {
        Overworld,
        Container,
        Combat,
        Dialog,
        Exit
    }

    // The Game Controller holds The entire in memory game state in the form of the Game Object (not GameObject).
    // The Game Controller holds other controllers as well as its own game wide accessor methods to change the state
    // of the game as needed
    internal class GameController
    {
        public RoomController RoomController = new RoomController();

        public PlayerController PlayerController = new PlayerController();

        public GameLogger GameLogger = new GameLogger();

        public GameState CurrentState;

        public OpenAIManager OpenAIManager = new OpenAIManager();

        public GameAction GetNextInGameAction()
        {
            GameObject directObject = new CancelObject();
            GameVerb overWorldAction = new ExitGame();
            while(directObject is CancelObject)
            {
                overWorldAction = new OverWorldMenuTree().PickSelection().Selection;
                if (overWorldAction is ExitGame)
                {
                    // Check if sure
                    // save game
                    // Change Game State
                    return new GameAction(overWorldAction, directObject);
                }
                directObject = overWorldAction.SelectDirectObject(this);
            }
            return new GameAction(overWorldAction, directObject);
        }

        public void PerfomInGameAction(GameAction action)
        {
            action.PreformAction(this);
        }



        public void LoadGame(Game game)
        {
            RoomController.SetCurrentRoom(game.Levels.First().Rooms.First());
            PlayerController.LoadPlayer(new Player());
            OpenAIManager.LoadGameData(game.Levels.First());
            CurrentState = GameState.Overworld;
        }

        //public MenuTreeResult RunOverWorld()
        //{
        //    var tree = new OverWorldMenuTree();
        //    return tree.StartMenuTree(this);
        //}

        //public void RunContainer()
        //{
        //    //var tree = new ObjectFirstMenuTree();
        //    //var results = tree.StartMenuTree(this);
        //}

        //public MenuTreeResult AttemptToPerformAction(MenuTreeResult result)
        //{
        //    return result.PlayerAction.PerformAction(this, result);
        //}

        //public MenuTreeResult GetNextAction(MenuTreeResult currentAction)
        //{
        //    if(currentAction.PlayerAction is Interact)
        //    {

        //    }
        //    return null;
        //}
    }
}
