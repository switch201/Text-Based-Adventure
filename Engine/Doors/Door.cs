using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Doors
{
    public class Door : GameObject
    {
        bool IsLocked;

        int Health;

        public Door(bool isLocked = false, int health = 10)
        {
            IsLocked = isLocked;
            Health = health; //should all game objects have health?
        }

        public void Open() {

        }

        public void Close()
        {

        }
    }
}
