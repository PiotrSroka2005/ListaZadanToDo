using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ListaZadanToDo
{
    public static class JsonConnection
    {
        static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "bazaListy.json");
        public static void WriteToFile(List<TaskModel> list)
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "");
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(path, json);
        }
        public static List<TaskModel> GetFromFile()
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "");
            string text = File.ReadAllText(path);
            if (text != "")
                return JsonSerializer.Deserialize<List<TaskModel>>(text);
            return new List<TaskModel>();
        }
    }
}
