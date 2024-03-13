using System.Text.Json;
using System.Text;

namespace Memes;

public class Friendship
{
    public int NodeA { get; }
    public int NodeB { get; }
    public int Grade { get; }
    public List<string> SharedStatements { get; }

    public Friendship(int nodeA, int nodeB, int grade, List<string> sharedStatements)
    {
        NodeA = nodeA;
        NodeB = nodeB;
        Grade = grade;
        SharedStatements = sharedStatements;
    }

    //public override string ToString()
    //{
    //    return $"(Node {NodeA + 1}, Node {NodeB + 1}): {Grade}\nShared Statements: {string.Join(", ", SharedStatements)}";
    //}
    private string ToPlainText()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Node {NodeA + 1} and Node {NodeB + 1} has {Grade} connections");
        sb.AppendLine("their current topics are");
        foreach (var statement in SharedStatements)
            sb.AppendLine($"\"{statement}\"");
        
        return sb.ToString();
    }

    private string ToJson()
    {
        var netObj = new
        {
            who = new List<string> { $"Node {NodeA + 1}", $"Node {NodeB + 1}" },
            connections = Grade,
            topics = SharedStatements
        };
        return JsonSerializer.Serialize(netObj, new JsonSerializerOptions { WriteIndented = true });
    }

    private string ToYamlLike()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"- who:");
        sb.AppendLine($"    - Node {NodeA + 1}");
        sb.AppendLine($"    - Node {NodeB + 1}");
        sb.AppendLine($"  connections: {Grade}");
        sb.AppendLine($"  topics:");
        foreach (var statement in SharedStatements)
            sb.AppendLine($"    - \"{statement}\"");
        
        return sb.ToString().TrimEnd();
    }

    public string ToString(OutputFormat format)
    {
        return format switch
        {
            OutputFormat.PlainText => ToPlainText(),
            OutputFormat.Json => ToJson(),
            OutputFormat.YamlLike => ToYamlLike(),
            _ => throw new ArgumentException("Invalid output format")
        };
    }

    public override string ToString()
    {
        // Default to plain text if no format is specified.
        return ToPlainText();
    }
}