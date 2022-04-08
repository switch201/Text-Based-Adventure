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
            dto = JsonConvert.DeserializeObject<GameObjectDTO>(Readfile());
        }


        protected string Readfile(string fileName = "Content/JsonContent/GameObjects/ObjectText.json")
        {

            using (StreamReader r = new StreamReader(fileName))
            {
                return r.ReadToEnd();
            }

            //var x = Path.GetFullPath(fileName);
            //using (StreamReader reader = new StreamReader(x)) 
            //using (JsonTextReader jsonReader = new JsonTextReader(reader))
            //{
            //    JsonSerializer ser = new JsonSerializer();
            //    return ser.Deserialize<GameObjectDTO>(jsonReader);
            //}
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
