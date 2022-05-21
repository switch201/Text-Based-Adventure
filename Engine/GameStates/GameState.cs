using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.GameStates
{
    public enum States {
        TitleScreen,
        GamePlay,
        Exit,
        CharacterCreation,
        Combat,
        GameOver
    }
    public class GameState
    {

        public GameState()
        {
            currentGameState = States.TitleScreen;
        }

        public States currentGameState;

        public void Exit()
        {
            currentGameState = States.Exit;
        }

        public void Combat()
        {
            currentGameState = States.Combat;
        }

        public void LoadTitle()
        {
            Util.wl(Figgle.FiggleFonts.Epic.Render("Welcome"));

            Util.wl(Figgle.FiggleFonts.Epic.Render("To Your"));

            Util.wl(Figgle.FiggleFonts.Gothic.Render("DOOM!!"));
        }

        public void LoseGame()
        {
            Util.wl(Figgle.FiggleFonts.ScriptSlant.Render("YOU MET YOUR DOOOM!"));
            currentGameState = States.GameOver;
        }

        public void WinGame()
        {
            Util.wl(Figgle.FiggleFonts.Pawp.Render("You Beat The Game"));
            currentGameState = States.GameOver;
        }

        public void RunGame()
        {
            currentGameState = States.GamePlay;
        }
    }
}
