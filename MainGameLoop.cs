using System;
using Text_Based_Adventure.Content;
using Text_Based_Adventure.Engine;
using Text_Based_Adventure.Engine.GameStates;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure
{
    class MainGameLoop
    {
        static void Main(string[] args)
        {
            GameState gameState = new GameState();
            Interpreter i = new Interpreter();

            while (gameState.currentGameState != States.Exit)
            {
                //Take input
                i.Interpret(Util.rl());
                //Interpret
                //give output

            }

            //Room room = new TreasureRoom();

            //Room room2 = new Room();

            //GameActions actions = new GameActions();

            //room.Enter();
            //room.Exit(room2);

            //actions.Examine(room);

        }
    }
}
