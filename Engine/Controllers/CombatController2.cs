using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using System.Linq;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.Engine.InputActions.BattleActions;

namespace Text_Based_Adventure.Engine.Controllers
{

    
    public class CombatController2
    {

        public static List<BattleAction> battleActions = new List<BattleAction>()
            {
                new Punch(),
                new RunAway(),
                new AttackWith(),
                //new BattleEquip(),
                //new BattleInspect(),
                //new GetClose(),
            };

        private static BattleAction? GetBattleActtion(string keyWord)
        {
            foreach (BattleAction action in battleActions)
            {
                if (action.keyWord.Contains(keyWord))
                {
                    return action;
                }
            }
            return null;
        }

        public static List<string> getBattleActionWords()
        {
            var list = new List<string>();
            foreach (BattleAction action in battleActions)
            {
                list.Add(action.keyWord.First());
            }
            return list;
        }



        public Queue<Creature> Combatants = new Queue<Creature>();

        public void AddCombatants(List<Creature> creatures)
        {
            creatures.OrderBy(x => x.attributes.getAttribute(Attribute.Dexterity));
            creatures.ForEach(x => Combatants.Enqueue(x));
        }

        private PlayerObject GetPlayer()
        {
            return (PlayerObject)Combatants.Single(x => x is PlayerObject);
        }

        private bool IsCombatOver()
        {
            return !Combatants.Any(x => !x.IsFriendly);
        }

        public void CombatLoop()
        {
            while (!IsCombatOver())
            {
                var currentCreature = Combatants.Dequeue();
                if (currentCreature is PlayerObject)
                {
                    Util.fourthWall("It is now your turn.");
                    currentCreature.CloseCreatures.ForEach(x =>
                    {
                        Util.fourthWall($"There is a {x.Name} close to you");
                    });
                    Combatants.Where(x => currentCreature.CloseCreatures.Contains(x)).ToList().ForEach(y =>
                    {
                        Util.fourthWall($"There is a {y.Name} off a little ways");
                    });
                    Util.fourthWall("What do you want to do. There are your options");
                    // Disnage/Runaway
                    // CloseDistance
                        //  
                    // Attack
                        //
                    // Inventory
                    AcceptStringInput(Util.rl());
                }
                else
                {
                    // DO some AI Bae
                }
                Combatants.Enqueue(currentCreature);
            }
        }

        public void AcceptStringInput(string userInput)
        {
            userInput = userInput.ToLower();

            

            List<string> seperatedInputWords = new List<string>(userInput.Split(' '));

                BattleAction validAction = GetBattleActtion(seperatedInputWords.First());
                if (validAction == null)
                {
                    Util.wl("That is not a valid action. Type 'help action' to see a list of valid actions");
                }
                else
                {
                    validAction.RespondToInput(gameController, seperatedInputWords);
                    gameController.gameState.adjustGameClock(validAction.duration);
                }
            }
        }
    }
}
