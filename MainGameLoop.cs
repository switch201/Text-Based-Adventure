using System;
using Text_Based_Adventure.Content;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure
{
    class MainGameLoop
    {
        static void Main(string[] args)
        {
            Util.wl(Figgle.FiggleFonts.Epic.Render("Welcome"));

            Util.wl(Figgle.FiggleFonts.Ghoulish.Render("To Your"));

            Util.wl(Figgle.FiggleFonts.Gothic.Render("DOOM!!"));

            Room room = new TreasureRoom();

            Room room2 = new Room();

            room.Enter();
            room.Exit(room2);
        }
    }
}
