using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.GameStates
{
    public enum States {
        TitleScreen,
        GamePlay,
        Exit
    }
    public class GameState
    {
        GameActions actions;

        public Dictionary<States, Action> stateActions;

        public States currentGameState;

        public GameState()
        {
            currentGameState = States.GamePlay;
            stateActions = new Dictionary<States, Action>() {
                { States.Exit, Exit },
                { States.GamePlay, RunGame },
                { States.TitleScreen, LoadTitle },
            };
        }

        public void Exit()
        {
            currentGameState = States.Exit;
        }

        public void LoadTitle()
        {
            Util.wl(Figgle.FiggleFonts.Epic.Render("Welcome"));

            Util.wl(Figgle.FiggleFonts.Ghoulish.Render("To Your"));

            Util.wl(Figgle.FiggleFonts.Gothic.Render("DOOM!!"));
        }

        public void RunGame()
        {

        }
    }
}
