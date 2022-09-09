using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.Scripts
{
    public class ActionList : List<ActionEvent>
    {
        public void SetGameController(GameController controller)
        {
            this.ForEach(x => x.SetGameController(controller));
        }
    }
}
