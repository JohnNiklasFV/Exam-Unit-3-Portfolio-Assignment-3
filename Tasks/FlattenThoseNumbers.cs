using System.IO;
using System.Text.Json;
namespace FlattenThoseNumbers;

public class Task2
{
    public void Execute()
        {
            string jsonString = File.ReadAllText("arrays.json");
            JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(jsonString);
            List<int> flattenedArray = FlattenJsonArray(jsonElement);
            Console.WriteLine("[{0}]", string.Join(",", flattenedArray));
        }

        private static List<int> FlattenJsonArray(JsonElement jsonArray)
        {
            var flattenedList = new List<int>();

            foreach (var item in jsonArray.EnumerateArray())
            {
                if (item.ValueKind == JsonValueKind.Array)
                {
                    flattenedList.AddRange(FlattenJsonArray(item));
                }
                else if (item.ValueKind == JsonValueKind.Number)
                {
                    flattenedList.Add(item.GetInt32());
                }
                
            }

            return flattenedList;
        }

}
