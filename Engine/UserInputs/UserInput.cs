﻿using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameStates;
using System.Linq;
using Text_Based_Adventure.Engine.UserInputs.GameActions;
using Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions;
using Text_Based_Adventure.Engine.UserInputs.Actions;

namespace Text_Based_Adventure.Engine
{
    public class UserInput
    {
        public static List<SkillAction> skillActions = new List<SkillAction>()
        {
            new Break(),
            new PickLock()
        };

        public static List<string> GetSkillActionWords()
        {
            return skillActions.Select(x => x.keyWord.First()).ToList();
        }
        //public static List<string> getGameActionWords()
        //{
        //    return gameActions.Select(x => x.keyWord.First()).ToList();
        //}

        public static GameAction? GetGameAction(string keyWord)
        {
            //foreach (GameAction action in gameActions)
            //{
            //    if (action.keyWord.Contains(keyWord))
            //    {
            //        return action;
            //    }
            //}
            return null;
        }

        public static SkillAction? GetSkillAction(string keyWord)
        {
            foreach (SkillAction action in skillActions)
            {
                if (action.keyWord.Contains(keyWord))
                {
                    return action;
                }
            }
            return null;
        }


        //public void AcceptStringInput(string userInput, GameController gameController)
        //{
        //    userInput = userInput.ToLower();

        //    string userOutput;

        //    List<string> seperatedInputWords = new List<string>(userInput.Split(' '));

        //    if(gameController.gameState.currentGameState == States.Combat)
        //    {
        //        BattleAction validAction = GetBattleActtion(seperatedInputWords.First());
        //        if (validAction == null)
        //        {
        //            Util.wl("That is not a valid action. Type 'help action' to see a list of valid actions");
        //        }
        //        else
        //        {
        //            validAction.RespondToInput(gameController, seperatedInputWords);
        //            gameController.gameState.adjustGameClock(validAction.duration);
        //        }
        //    }
        //    else
        //    {
        //        GameAction validAction = GetGameAction(seperatedInputWords.First()) ?? GetSkillAction(seperatedInputWords.First());
        //        if(validAction == null)
        //        {
        //            Util.wl("That is not a valid action. Type 'help action' to see a list of valid actions");
        //        }
        //        else{

        //            validAction.RespondToInput(gameController, seperatedInputWords);
        //            gameController.gameState.adjustGameClock(validAction.duration);
        //        }
        //    }
        //}

    }
}
