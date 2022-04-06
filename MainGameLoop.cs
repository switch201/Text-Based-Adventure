using System;

namespace Text_Based_Adventure
{
    class MainGameLoop
    {
        static void Main(string[] args)
        {
            Util.wl(Figgle.FiggleFonts.Epic.Render("Welcome"));

            Util.wl(Figgle.FiggleFonts.Ghoulish.Render("To Your"));

            Util.wl(Figgle.FiggleFonts.Gothic.Render("DOOM!!"));

            Util.rl();

            MainMenu.Start();
        }
    }
}
