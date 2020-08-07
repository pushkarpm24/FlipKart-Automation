using Newtonsoft.Json;
using System;
using System.IO;

namespace FlipKart.JsonFile
{
    public class Credentials
    {
        public string phone = "";
        public string password = "";
        public string json = "";

        public Credentials()
        {
            using (StreamReader r = new StreamReader("C://Users//HP//source//repos//FlipKart//FlipKart//JsonFile//cred.json"))
            {
                json = r.ReadToEnd();
            }

            dynamic array = JsonConvert.DeserializeObject(json);
            Console.WriteLine("Array::::" + array["phone"]);
            phone = array["phone"];
            password = array["password"];
        }
    }
}
