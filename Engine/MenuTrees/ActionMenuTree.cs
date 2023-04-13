using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameVerbs;
using Text_Based_Adventure.Engine.GameObjects;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal class MenuTreeResult
    {
        public GameVerb PlayerAction;
        public GameObject DirectObject;
        public GameObject IndirectObject;
        public bool ActionSuccess;
        public bool HasNext;
        public bool ActionCanceled;
    }
    internal abstract class ActionMenuTree : MenuTree
    {

    }
}
