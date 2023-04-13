using System;
using Text_Based_Adventure.Engine;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.Factories;
using Text_Based_Adventure.Engine.GameVerbs;
using Text_Based_Adventure.Engine.Games;
using Text_Based_Adventure.Engine.Levels;
using Text_Based_Adventure.Engine.MenuTrees;
using Text_Based_Adventure.Engine.GameActions;
using OpenAI_API;
using System.Threading.Tasks;

namespace Text_Based_Adventure
{
    class MainGameLoop
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Text Based Adventure";

            Level testLevel = LevelFactory.MakeLevel("TestLevel2");


            GameController gameController = new GameController();
            Game testGame = new Game(testLevel);
            gameController.LoadGame(testGame);

            while (gameController.CurrentState != GameState.Exit)
            {

                GameAction currentAction = gameController.GetNextInGameAction();

                gameController.PerfomInGameAction(currentAction);


                if(gameController.CurrentState == GameState.Dialog)
                {
                    Util.wl($"What do you want to say to {gameController.OpenAIManager.currentNPC.Name}? (Type 'goodbye' to leave dialog)'");
                    var userInput = Util.rl();

                    while (userInput != "goodbye")
                    {
                        Util.wl(await gameController.OpenAIManager.TalkToNPC(userInput));
                        userInput = Util.rl();
                    }
                    gameController.CurrentState = GameState.Overworld;
                }


                //while (currentAction.HasNext == true)
                //{
                //    var previousAction = currentAction;
                //    currentAction = gameController.AttemptToPerformAction(currentAction);
                //    if (currentAction.ActionCanceled)
                //    {
                //        currentAction = previousAction;
                //    }

                //}
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
