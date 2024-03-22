using System.Text.Json;
namespace FlattenThoseNumbers;

public class Task2
{
    public void Execute()
    {
        string jsonString = File.ReadAllText("arrays.json");
        JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(jsonString);
        List<int> flattenedArray = new List<int>();
        FlattenDynamicObject(jsonElement, flattenedArray);
        Console.WriteLine("🌱Flatten those Numbers🌱");
        Console.WriteLine("[{0}]", string.Join(",", flattenedArray));

    }


    private static void FlattenDynamicObject(JsonElement jsonObject, List<int> flattenedList)
    {
        if (jsonObject.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in jsonObject.EnumerateArray())
            {
                FlattenDynamicObject(item, flattenedList);
            }
        }
        else if (jsonObject.ValueKind == JsonValueKind.Number)
        {
            flattenedList.Add(jsonObject.GetInt32());
        }
    }

}

