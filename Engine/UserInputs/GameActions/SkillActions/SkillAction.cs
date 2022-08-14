using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;
using System.Linq;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions
{
    public abstract class SkillAction : GameAction
    {
        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directObject = seperatedWords.Last();
            var targetGameObject = controller.roomController.GetGameObject(directObject);
            if (targetGameObject == null)
            {
                Util.wl($"You can't {this.keyWord.First()} that"); //TODO make this generic
            }
            else
            {
                var gameLock = targetGameObject.getActionSkillCheck(this);
                if (gameLock == null || !gameLock.Locked)
                {
                    Util.wl($"no need to {this.keyWord.First()} the {targetGameObject.Name}");
                }
                else if(gameLock.Locked)
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
                    

                    if (gameLock.BestTarget > gameLock.BestTarget)
                    {
                        this.BestOutcome(controller, targetGameObject);
                    }
                    else if (result > gameLock.GoodTarget)
                    {
                        this.GoodOutcome(controller, targetGameObject);
                    }
                    else if (result > gameLock.BadTarget)
                    {
                        this.BadOutcome(controller, targetGameObject);
                    }
                    else
                    {
                        this.WorstOutcome(controller, targetGameObject);
                    }
                }
                else if (gameLock.Broken)
                {
                    var brokenText = gameLock.BrokenText;
                    Util.wl(brokenText ?? $"You can't {this.keyWord.First()} this {targetGameObject.Name}");
                }
            }
        }
        public abstract void BestOutcome(GameController? gameController, GameObject? directObject);

        public abstract void GoodOutcome(GameController? gameController, GameObject? directObject);

        public abstract void BadOutcome(GameController? gameController, GameObject? directObject);

        public abstract void WorstOutcome(GameController? gameController, GameObject? directObject);
    }
}
