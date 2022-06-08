using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.Json
{
    public class Zapisz
    {
         public static void SaveXML(List<Wojewodztwo> woj)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Wojewodztwo>));

            string workingDirectory = Environment.CurrentDirectory;
            var path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "/Desktop/integracja-projekt/API/Json/Assets/BazaXML.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, woj);
            file.Close();
        }

        public static void SaveJSON(List<Wojewodztwo> woj)
        {
            string workingDirectory = Environment.CurrentDirectory;
            var path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "/Desktop/integracja-projekt/API/Json/Assets/BazaJSON.json";

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(path, JsonConvert.SerializeObject(woj, Newtonsoft.Json.Formatting.None));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(path))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

                serializer.Serialize(file, woj);
            }

            /*
            string json = JsonSerializer.Serialize(woj);

            string workingDirectory = Environment.CurrentDirectory;
            var path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "/Assets/BazaJSON.xml";
            //System.IO.FileStream file = System.IO.File.Create(path);

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(path, JsonConvert.SerializeObject(woj));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, woj);
            }
            */
        }
    }
}