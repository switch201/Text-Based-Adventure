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
        public string name;

        public string DescriptionText;

        public string InspectionText;


        public GameObject(string objectName)
        {
            if(objectName != "void")
            {
                GameObject temp = JsonConvert.DeserializeObject<GameObject>(Readfile($"Content/TestLevel/JsonContent/GameObjects/{objectName}Text.json"));
                foreach (var property in GetType().GetProperties())
                {
                    property.SetValue(this, property.GetValue(temp, null), null);
                }
            }
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
