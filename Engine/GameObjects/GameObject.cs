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

        protected abstract GameObjectDTO dto{ get; set; }

        public string name;


        public GameObject(string objectName)
        {
            if(objectName != "void")
                dto = JsonConvert.DeserializeObject<GameObjectDTO>(Readfile($"Content/TestLevel/JsonContent/GameObjects/{objectName}Text.json"));
        }


        protected string Readfile(string fileName = "Engine/GameObjects/ObjectText.json")
        {

            using (StreamReader r = new StreamReader(fileName))
            {
                return r.ReadToEnd();
            }
        }

        public void Describe()
        {
            Util.wl(dto.DescriptionText);
        }

        public void Inspect()
        {
            Util.wl(dto.InspectionText);
        }
    }
}
