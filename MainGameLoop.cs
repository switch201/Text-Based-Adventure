using System;
using Text_Based_Adventure.Engine;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.Factories;
using Text_Based_Adventure.Engine.GameActions;
using Text_Based_Adventure.Engine.Games;
using Text_Based_Adventure.Engine.Levels;
using Text_Based_Adventure.Engine.MenuTrees;

namespace Text_Based_Adventure
{
    class MainGameLoop
    {
        static void Main(string[] args)
        {
            Console.Title = "Text Based Adventure";

            Level testLevel = LevelFactory.MakeLevel("TestLevel2");


            GameController gameController = new GameController();
            Game testGame = new Game(testLevel);
            gameController.LoadGame(testGame);

            while (gameController.CurrentState != GameState.Exit)
            {

                var currentAction = gameController.RunOverWorld();

                //TODO Scripts listen here for player action, and check validity/react
                // Maybe they do that in the function bellow...
                currentAction.HasNext = true;

                while (currentAction.HasNext == true)
                {
                    var previousAction = currentAction;
                    currentAction = gameController.AttemptToPerformAction(currentAction);
                    if (currentAction.ActionCanceled)
                    {
                        currentAction = previousAction;
                    }

                }
                // interact with chest ^

                // open, break, pick, leave
                
                // open
                    //You See these Items in the chest What do you want to do with them?
                    // sword, sheild , take all, equip all

                    // sword
                        // What do you want to do with the sword?
                        // Take, Equip

                        //Take
                // break
                    // Skill Check, Items then spill on flooe

                //if(gameController.CurrentState == GameState.Container)
                //{
                //    gameController.RunContainer();
                //}
                // Use Menu Tree grab an Action + Direct Object

                //        // Direct Object scripts listen for action to take place

                //        // Room Object scripts listen for action to take place and react
                //        // Combat possibly Starts
                //        // Global scripts listen for acion to take place and react
                //        // GameTime is incremented
            }

        }
    }
}
