using System.Text.Json;
namespace LeftAndRightUpAndDownAwayWeGo;

public class Task3
{   //Execution--------------------------------------------------------
    public void Execute()
    {
        string jsonString = File.ReadAllText("nodes.json");
        JsonDocument jsonDocument = JsonDocument.Parse(jsonString);

        int sum = TotalSum(jsonDocument.RootElement);
        Console.WriteLine("Sum of values in the tree: " + sum);

        int deepestLevel = FindDeepestLevel(jsonDocument.RootElement);
        Console.WriteLine("Deepest level in the tree: " + deepestLevel);

        int nodeCount = CountNodes(jsonDocument.RootElement);
        Console.WriteLine("Number of nodes in the tree: " + nodeCount);
    }
    //Sum---------------------------------------------------------------
    public int TotalSum(JsonElement jsonElement)
    {
        int sum = 0;

        ActualCalculationSum(jsonElement, ref sum);

        return sum;
    }

    private void ActualCalculationSum(JsonElement jsonElement, ref int sum)
    {
        if (jsonElement.ValueKind == JsonValueKind.Object)
        {
            foreach (JsonProperty property in jsonElement.EnumerateObject())
            {
                if (property.Name == "value")
                {
                    sum += property.Value.GetInt32();
                }
                else if (property.Value.ValueKind == JsonValueKind.Object)
                {
                    ActualCalculationSum(property.Value, ref sum);
                }
            }
        }
    }
    //deepestlevel-------------------------------------------------------
    public int FindDeepestLevel(JsonElement jsonElement, int level = 1)
    {
        int deepest = level;
        if (jsonElement.ValueKind == JsonValueKind.Object)
        {
            foreach (JsonProperty property in jsonElement.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Object)
                {
                    int childLevel = FindDeepestLevel(property.Value, level + 1);
                    deepest = Math.Max(deepest, childLevel);
                }
            }
        }
        return deepest;
    }
    //numberOfNodes-------------------------------------------------------------------
    public int CountNodes(JsonElement jsonElement)
    {
        int count = 1;
        if (jsonElement.ValueKind == JsonValueKind.Object)
        {
            foreach (JsonProperty property in jsonElement.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Object)
                {
                    count += CountNodes(property.Value);
                }
            }
        }
        return count;
    }
}
    //end-------------------------------------------------------------------------------