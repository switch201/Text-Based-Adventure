using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;

namespace Text_Based_Adventure.GameObjects
{
    public abstract class GameObject
    {
        public string Name;

        public string DescriptionText;

        public string InspectionText;


        public GameObject(string objectName)
        {

        }


        protected string Readfile(string fileName = "Engine/GameObjects/ObjectText.json")
        {
            return Util.Readfile(fileName);
        }

        public void Describe()
        {
            Util.wl(this.DescriptionText);
        }

        public void Inspect()
        {
            Util.wl(this.InspectionText);
        }
    }
}
