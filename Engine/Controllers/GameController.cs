using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameStates;
using Text_Based_Adventure.Engine.Games;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.Engine.Controllers;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using Text_Based_Adventure.Engine.GameClasses;

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

        public GameController(GameState initialState)
        {
            roomController = new RoomController();
            levelController = new LevelController();
            gameState = initialState;
            userInput = new UserInput();
            playerController = new PlayerController();
            combatController = new CombatController();
        }

        public void setGame(Game game)
        {
            this.game = game;
        }


        // Does all the things the constructor does to reset the game
        public void clearGame()
        {
            roomController = new RoomController();
            levelController = new LevelController();
            gameState = new GameState();
            userInput = new UserInput();
            playerController = new PlayerController();
            combatController = new CombatController();
            this.game = null;
        }

        public void StartGame()
        {
            this.roomController.currentRoom = game.Levels[0].Rooms[0].Enter();
        }

        public void StartCombat()
        {
            this.gameState.Combat();
            this.combatController.setPlayer(playerController.player);
            this.combatController.setEnemies(this.roomController.currentRoom.getNPCs()); // TODO filter out friendly NPCs

            Util.wl($"You Start Combat against a");
            this.roomController.currentRoom.getNPCs().ForEach(x => Util.wl(Util.RandomIdentifier(x)));
        }

        private void checkTimedEvents()
        {
            var currentTime = this.gameState.getGameTime();
            this.playerController.CheckConsumableTime(currentTime);
        }

        private void checkForCombatEnd()
        {
            CombatResult result = this.combatController.GetResult();
            //Based on the results "Kill" the dead people
            if (!result.moreEnemies)
            {
                if (result.gameWon) //Final Bosds Dead
                {
                    this.gameState.WinGame();
                    this.clearGame();
                }
                else
                {
                    WinCombat();
                }
                
            }
            else if (result.playerKilled)
            {
                this.gameState.LoseGame();
                this.clearGame();
            }
        }

        private void WinCombat()
        {
            this.roomController.RemoveNPCs(); //TODO FIx this too
            EndCombat();
            Util.wl("You Win");
        }

        private void EndCombat()
        {
            this.gameState.RunGame();
            this.combatController.setPlayer(null);
            this.combatController.RemoveEnemies();
        }

        public void RunAway()
        {
            var runModifier = this.roomController.currentRoom.runModifier;
            Util.log($"Room Run Modifier: {runModifier}");
            if (this.combatController.getCombatRunChance() - this.roomController.currentRoom.runModifier > 0)
            {
                EndCombat();
                Util.wl("You Run Away"); // TODO replace with custom room Text
            }
            else
            {
                NPC randomEnemy = Util.RandomFromList(this.combatController.GetEnemies());
                Util.wl($"You try to run, But {randomEnemy.Name} stops you!");
                // A Random Enemy gets an extra Attack on you!
                this.combatController.ResolveEnemyAttack(randomEnemy);
            }
        }

        public void TakeUserInputForClass(bool debug = false)
        {
            string name = debug ? "testman" : Util.rl();
            GameClass selectedClass = null;
            while(selectedClass == null)
            {
                Util.wl("Select one of the following Classes:");
                Util.writeList(this.game.AvailableGameClasses.Select(x => x.Name).ToList());
                string userInput = debug ? "barbarian" : Util.rl().ToLower();
                selectedClass = this.game.AvailableGameClasses.Where(x => x.Name.ToLower() == userInput).SingleOrDefault();
                if(selectedClass == null)
                {
                    Util.wl("You gotta pick one...");
                }
            }
            var attributeSet = new AttributeSet();
            foreach (Attribute attribute in Enum.GetValues(typeof(Attribute)))
            {
                Util.wl($"Lets roll for your {attribute} value");
                List<int> diceSet = new List<int>();
                for(int x = 0; x < 4; x++)
                {
                    int roll = Util.d(6);
                    Util.wl($"You rolled a {roll}");
                    diceSet.Add(roll);
                }
                
                diceSet = diceSet.OrderByDescending(x => x).Take(diceSet.Count() - 1).ToList(); // Remove the lowest of the 4 dice
                int sum  = diceSet.Sum();
                Util.log($"attribute sum: {sum}");

                attributeSet.setAttribute(attribute, sum);
            }
            List<Skill> selectedSkills = new List<Skill>() { };
            List<Skill> availableSkills = selectedClass.SkillChoices;
            while (selectedSkills.Count < selectedClass.SkillCount)
            {
                var debugSkillList = new List<string>() { "nature", "perception" };
                Util.wl($"Pick {selectedClass.SkillCount - selectedSkills.Count} skils from the following list of skills to be good at");
                Util.writeList(selectedClass.SkillChoices.Select(x => x.ToString()).ToList());
                string userInput = debug ? debugSkillList[selectedSkills.Count] : Util.rl().ToLower();
                var selectedSkill = availableSkills.SingleOrDefault(x => x.ToString().ToLower() == userInput);
                if(selectedSkill != Skill.None)
                {
                    selectedSkills.Add(selectedSkill);
                    availableSkills.Remove(selectedSkill);
                }
                else
                {
                    Util.wl("You gott pick em");
                }

            }



            this.playerController.player = new PlayerObject(name, attributeSet, selectedClass, selectedSkills);
            this.gameState.RunGame();
        }

        public void TakeUserInputAndRespond()
        {
            string input = Util.rl();
            userInput.AcceptStringInput(input, this);
            checkTimedEvents();
            if(gameState.currentGameState == States.Combat)
            {
                checkForCombatEnd();
            }
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
