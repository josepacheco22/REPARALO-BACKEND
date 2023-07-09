//using Google.Protobuf.WellKnownTypes;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Data.REPARALO.Properties;

namespace ApiRestREPARALO.JSON
{
    public class DEFAULT
    {
        //public static string _path = "C:\\Users\\japac\\OneDrive\\Documentos\\PROPIO\\PROYECTOS\\REPARALO\\BACK END\\ApiRestREPARALO\\Data.REPARALO\\JSON\\DEFAULT.json";
        //public static string _path = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), "JSON\\DEFAULT.json");
        public static string _path = Path.Combine(Environment.CurrentDirectory,"JSON\\DEFAULT.json");

        public string basePath = Environment.CurrentDirectory;
        public string relativePath = "./JSON/DEFAULT.xml";
        
        //public string fullPath = Path.Combine(relativePath, basePath);
        //public static string _path345 = Path.Combine(fullPath);


        public DEFAULT() { }
        public  ListBox  Read()
        {
            return System.Text.Json.JsonSerializer.Deserialize<ListBox>(File.ReadAllText(_path))!;
        }
        public void Write(ListBox listBox)
        {
            File.WriteAllText(_path, System.Text.Json.JsonSerializer.Serialize(listBox));
        }
    }
    public class ListBox
    {
        public int? ORDENTYPE { get; set; }
        public int? DOCUMENTTYPE { get; set; }
        public int? COUNTRY { get; set; }
        public int? STATE { get; set; }
        public int? CITY { get; set; }
        public int? TRADEMARK { get; set; }
        public int? EQUIPMENTTYPE { get; set; }
        public int? CLIENT { get; set; }
        public int? REPAIRORDER { get; set; }
        public int? ACCESSORYTYPE { get; set; }
        public int? REPLACEMENTTYPE { get; set; }


    }
}
