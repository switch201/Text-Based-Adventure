using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;
using System.Linq;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using Text_Based_Adventure.Engine.GameObjects.SkillChecks;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions
{
    public abstract class SkillAction : GameAction
    {
        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directObject = seperatedWords.Last();
            var targetGameObject = controller.roomController.TryGetGameObject(directObject);
            if (targetGameObject == null)
            {
                Util.wl($"You can't {this.keyWord.First()} that");
            }
            else
            {
                var gameLock = targetGameObject.getActionSkillCheck(this);
                if (gameLock == null || !gameLock.Locked)
                {
                    Util.wl($"no need to {this.keyWord.First()} the {targetGameObject.Name}");
                }
                else if(gameLock.Locked && !gameLock.Broken)
                {
                    int result;
                    //TODO Combo attribute + skill rolls?
                    if (gameLock.Attribute != Attribute.None)
                    {
                        result = gameLock.PerformSkillCheck(controller.playerController.player, gameLock.Attribute);
                    }
                    else
                    {
                        result = gameLock.PerformSkillCheck(controller.playerController.player);
                    }
                    

                    if (result > gameLock.BestTarget)
                    {
                        SkillCheckOutcome.BestOutcome(controller, targetGameObject);
                    }
                    else if (result > gameLock.GoodTarget)
                    {
                        SkillCheckOutcome.GoodOutcome(controller, targetGameObject);
                    }
                    else if (result > gameLock.BadTarget)
                    {
                        SkillCheckOutcome.BadOutcome(controller, targetGameObject);
                    }
                    else
                    {
                        SkillCheckOutcome.WorstOutcome(controller, targetGameObject);
                    }
                }
                else if (gameLock.Broken)
                {
                    var brokenText = gameLock.BrokenText;
                    Util.wl(brokenText ?? $"You can't {this.keyWord.First()} this {targetGameObject.Name}");
                }
            }
        }

        public abstract SkillCheckOutcome SkillCheckOutcome { get;}
    }
}
