using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;

namespace Text_Based_Adventure.GameObjects
{
    public class GameObject
    {

        protected GameObjectDTO dto;

        public GameObject()
        {
            dto = Readfile();
        }


        protected GameObjectDTO Readfile(string fileName = "ObjectText.json")
        {
            using (StreamReader reader = new StreamReader(fileName))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                JsonSerializer ser = new JsonSerializer();
                return ser.Deserialize<GameObjectDTO>(jsonReader);
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
