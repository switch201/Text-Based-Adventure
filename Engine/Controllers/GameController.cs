using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Games;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Actors;
using Text_Based_Adventure.Engine.MenuTrees;
using Text_Based_Adventure.Engine.GameActions;

namespace Text_Based_Adventure.Engine.Controllers
{
    public enum GameState
    {
        Overworld,
        Container,
        Combat,
        Exit
    }

    // The Game Controller holds The entire in memory game state in the form of the Game Object (not GameObject).
    // The Game Controller holds other controllers as well as its own game wide accessor methods to change the state
    // of the game as needed
    internal class GameController
    {
        public RoomController RoomController = new RoomController();

        public PlayerController PlayerController = new PlayerController();

        public GameState CurrentState;

        public void LoadGame(Game game)
        {
            RoomController.SetCurrentRoom(game.Levels.First().Rooms.First());
            PlayerController.LoadPlayer(new Player());
            CurrentState = GameState.Overworld;
        }

        public MenuTreeResult RunOverWorld()
        {
            var tree = new OverWorldMenuTree();
            return tree.StartMenuTree(this);
        }

        public void RunContainer()
        {
            //var tree = new ObjectFirstMenuTree();
            //var results = tree.StartMenuTree(this);
        }

        public MenuTreeResult AttemptToPerformAction(MenuTreeResult result)
        {
            return result.PlayerAction.PerformAction(this, result);
        }

        //public MenuTreeResult GetNextAction(MenuTreeResult currentAction)
        //{
        //    if(currentAction.PlayerAction is Interact)
        //    {

        //    }
        //    return null;
        //}
    }
}
