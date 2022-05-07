using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameStates;
using Text_Based_Adventure.Engine.Levels;
using Text_Based_Adventure.Engine.Games;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.Player.Attributes;
using System.Linq;

namespace Text_Based_Adventure.Engine
{
    public class GameController
    {
        public RoomController roomController;
        public LevelController levelController;
        public GameState gameState;
        public string displayText;
        public UserInput userInput;
        public Game game;
        public PlayerController playerController;
        public CombatController combatController;


        List<string> actionLog = new List<string>();

        public GameController(GameState initialState, Game game)
        {
            roomController = new RoomController();
            levelController = new LevelController();
            gameState = initialState;
            userInput = new UserInput();
            playerController = new PlayerController();
            combatController = new CombatController();
            this.game = game;
        }

        public void StartGame()
        {
            this.roomController.currentRoom = game.Levels[0].StartingRoom.Enter();
        }

        public void StartCombat()
        {
            this.gameState.Combat();
            this.combatController.setPlayer(playerController.player);
            this.combatController.setEnemies(this.roomController.currentRoom.getNPCs()); // TODO filter out friendly NPCs
            Util.wl("You Start Combat");
        }

        public void checkForCombatEnd()
        {
            CombatResult result = this.combatController.GetResult();
            //Based on the results "Kill" the dead people
            if (!result.moreEnemies)
            {
                EndCOmbat();
            }
        }

        public void EndCOmbat()
        {
            this.gameState.RunGame();
            this.combatController.setPlayer(null);
            this.combatController.RemoveEnemies();
            this.roomController.RemoveNPC("fred"); //TODO FIx this too
            Util.wl("You Win");
        }

        public void RunAway()
        {
            this.gameState.RunGame();
            this.combatController.setPlayer(null);
            this.combatController.RemoveEnemies();
            Util.wl("You Run Away");
        }

        public void TakeUserInputForCharacter()
        {
            var attributeSet = new AttributeSet();
            string name = Util.rl();
            foreach (Player.Attributes.Attribute attribute in Enum.GetValues(typeof(Player.Attributes.Attribute)))
            {
                Util.wl($"what is your {attribute} value");
                attributeSet.setAttribute(attribute, Convert.ToInt32(Util.rl()));
            }
            this.playerController.player = new PlayerObject(name, attributeSet);
            this.gameState.RunGame();

        }
        public void TakeUserInputAndRespond()
        {
            string input = Util.rl();
            userInput.AcceptStringInput(input, this);
        }

        public void DisplayLoggedText()
        {
            string logAsText = string.Join("\n", actionLog.ToArray());

            displayText = logAsText;


        }

        public void LogString(string stringToAdd)
        {
            actionLog.Add(stringToAdd);
        }

        public void ExitGame()
        {
            gameState.Exit();
        }
    }
}
