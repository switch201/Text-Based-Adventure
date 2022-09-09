using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.Scripts
{
    public abstract class ActionEvent
    {
        protected GameController controller;
        public abstract void Execute();

        public void SetGameController(GameController controller)
        {
            this.controller = controller;
        }
    }
}
