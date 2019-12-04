using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.RepresentationModel;

using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using lb5.entity;

namespace lb5.utils
{
    abstract class Reader
    {
        public static Object ReadData()
        {



            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,".\\user-data\\store.yml");
            string inputString = System.IO.File.ReadAllText(path);
           
            var input =new StringReader(inputString);
            Console.WriteLine(inputString);
            Console.WriteLine(path);
         
            var deserializer = new DeserializerBuilder()
               .WithNamingConvention(new CamelCaseNamingConvention())
               .Build();

            var list = deserializer.Deserialize<StoreRoom>(input);

            return "";
        }
    }

    class Store
    {
       public string name { get; set; }
       public Contain contain { get; set; }
    }
    class Contain
    {
        [YamlMember(Alias = "security", ApplyNamingConventions = false)]
        public string security { get; set; }

        [YamlMember(Alias = "alchohol", ApplyNamingConventions = false)]
        public bool alchohol { get; set; }
    }
}
