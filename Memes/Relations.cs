using System.Text;
using System.Text.Json;

namespace Memes;

public class Relations
{
    private readonly List<Node> _nodes;
    private int[,] _acceptanceMatrix;
    private List<Friendship> _friendships;

    internal Relations(List<Node> nodes)
    {
        this._nodes = nodes;

        _acceptanceMatrix = new int[nodes.Count, nodes.Count];
        BuildMatrix();

        _friendships = new List<Friendship>();
        BuildFriendships();
    }

    private void BuildMatrix()
    {
        for (int i = 0; i < _nodes.Count; i++)
            for (int j = 0; j < _nodes.Count; j++)
                if (i != j) // A node does not compare to itself
                {
                    _acceptanceMatrix[i, j] = _nodes[j].Listen(_nodes[i].Share());
                }
                else
                {
                    _acceptanceMatrix[i, j] = 0; // No self-comparison
                }
    }

    private void BuildFriendships()
    {
        // Populate the list with friendships (i.e., non-zero grades)
        for (int i = 0; i < _nodes.Count; i++)
        for (int j = 0; j < _nodes.Count; j++)
            if (i < j && _acceptanceMatrix[i, j] > 0)
            {
                // Find shared statements between the two nodes
                var sharedStatements = _nodes[i].Share().Intersect(_nodes[j].Share()).ToList();

                // Add the friendship along with the shared statements
                _friendships.Add(new Friendship(i, j, _acceptanceMatrix[i, j], sharedStatements));
            }

        // Sort the list by grade in descending order
        _friendships.Sort((a, b) => b.Grade.CompareTo(a.Grade));
    }

    public void PrintMatrix(bool showZero = false)
    {
        Console.Write("   "); // Adjust spacing for row labels

        for (int j = 0; j < _nodes.Count; j++)
            Console.Write($"{j + 1,3}"); // Adjust the format for potentially larger numbers
        
        Console.WriteLine();

        for (int i = 0; i < _nodes.Count; i++)
        {
            Console.Write($"{i + 1,2}:");
            for (int j = 0; j < _nodes.Count; j++)
            {
                if (_acceptanceMatrix[i, j] != 0 || showZero)
                {
                    Console.Write($"{_acceptanceMatrix[i, j],3}"); // Adjust the format for potentially larger numbers
                }
                else if (!showZero)
                {
                    Console.Write("   "); // Blank space for zero values
                }
            }
            Console.WriteLine();
        }
    }

    // Create a function to format as plain text
    private static string FormatFriendshipsAsPlainText(List<Friendship> friendships)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var friendship in friendships)
        {
            sb.AppendLine($"Node {friendship.NodeA + 1} and Node {friendship.NodeB + 1} has {friendship.Grade} connections");
            sb.AppendLine("their current topics are");
            foreach (var statement in friendship.SharedStatements)
                sb.AppendLine($"\"{statement}\"");
            
            sb.AppendLine(); // Add an extra line for better readability
        }

        return sb.ToString();
    }

    // Create a function to serialize to JSON
    private static string SerializeFriendshipsToJson(List<Friendship> friendships)
    {
        var net = new Dictionary<string, object>();

        for (int i = 0; i < friendships.Count; i++)
        {
            var leg = new Dictionary<string, object>
            {
                ["who"] = new List<string> { $"Node {friendships[i].NodeA + 1}", $"Node {friendships[i].NodeB + 1}" },
                ["connections"] = friendships[i].Grade,
                ["topics"] = friendships[i].SharedStatements
            };
            net[$"leg {i + 1}"] = leg;
        }

        var root = new Dictionary<string, object> { ["net"] = net };
        return JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });
    }

    //TODO: add native yaml
    // Assuming you have installed YamlDotNet and have the required using statements
    // Create a function to serialize to YAML
    /*
        Install-Package YamlDotNet
        using YamlDotNet.Serialization;
        using YamlDotNet.Serialization.NamingConventions;
    */
    //private static string SerializeFriendshipsToYaml(List<Friendship> friendships)
    //{
    //    var serializer = new YamlDotNet.Serialization.Serializer();
    //    var net = new List<Dictionary<string, object>>();
    //    for (int i = 0; i < friendships.Count; i++)
    //    {
    //        var leg = new Dictionary<string, object>
    //        {
    //            ["who"] = new List<string> { $"Node {friendships[i].NodeA + 1}", $"Node {friendships[i].NodeB + 1}" },
    //            ["connections"] = friendships[i].Grade,
    //            ["topics"] = friendships[i].SharedStatements
    //        };
    //        net.Add(leg);
    //    }
    //    var root = new Dictionary<string, object> { ["net"] = net };
    //    return serializer.Serialize(root);
    //}

    // Create a function to format as YAML-like text
    private static string FormatFriendshipsAsYamlLike(List<Friendship> friendships)
    {
        var sb = new StringBuilder();

        sb.AppendLine("net:");

        for (int i = 0; i < friendships.Count; i++)
        {
            sb.AppendLine($" - leg {i + 1}:");
            sb.AppendLine($"     who:");
            sb.AppendLine($"       - \"Node {friendships[i].NodeA + 1}\"");
            sb.AppendLine($"       - \"Node {friendships[i].NodeB + 1}\"");
            sb.AppendLine($"     connections: {friendships[i].Grade}");
            sb.AppendLine($"     topics:");
            foreach (var statement in friendships[i].SharedStatements)
                sb.AppendLine($"        - \"{statement}\"");
        }

        return sb.ToString();
    }

    public void Print()
    {
        // Report the friendships and their shared statements
        Console.WriteLine("Friendship grades and shared statements (sorted):");
        foreach (var friendship in _friendships)
        {
            //Console.WriteLine(friendship.ToString());
            Console.WriteLine(friendship.ToString(OutputFormat.PlainText));
            //Console.WriteLine(friendship.ToString(OutputFormat.Json));
            //Console.WriteLine(friendship.ToString(OutputFormat.YamlLike));
            Console.WriteLine(); // Add an extra line for better readability
        }

        //Console.WriteLine(FormatFriendshipsAsPlainText(friendships));
        Console.WriteLine(SerializeFriendshipsToJson(_friendships));
        Console.WriteLine(FormatFriendshipsAsYamlLike(_friendships));
    }

    private static void Fill(char[] arg, char filler = ' ')
    {
        var runtimeVersion = Environment.Version;
        if (runtimeVersion >= new Version(6, 0) || runtimeVersion <= new Version(7, 0))
        {
            Array.Fill(arg, ' ');
        }
        else
        {
            for (int i = 0; i < arg.Length; i++)
            
                arg[i] = filler;
            
        }
    }
    public void PrintGraph()
    {
        var nodes = Enumerable.Range(1, _acceptanceMatrix.GetLength(0)).Select(n => n.ToString()).ToList();
        int nodeCount = nodes.Count;
        int canvasWidth = nodeCount * 4;
        char[] canvas = new char[canvasWidth];

        // Initialize the canvas with spaces
        Fill(canvas, ' ');

        // Print the connections based on the acceptanceMatrix
        for (int i = 0; i < nodeCount; i++)
            for (int j = i + 1; j < nodeCount; j++)
                if (_acceptanceMatrix[i, j] > 0)
                {
                    int x = i * 4;
                    int y = j * 4;

                    // Place the '+' character at the nodes
                    canvas[x] = '+';
                    canvas[y] = '+';

                    // Draw the horizontal line between nodes
                    for (int k = x + 1; k < y; k++)
                        canvas[k] = '-';

                    // Print the horizontal line
                    Console.WriteLine(new string(canvas));

                    // Reset the canvas except the vertical lines
                    for (int k = x + 1; k < y; k++)
                        canvas[k] = ' ';

                    // Draw the vertical lines
                    for (int k = 0; k < nodeCount; k++)
                        if (canvas[k * 4] == '+')
                            for (int l = 0; l < canvasWidth; l += 4)
                                if (canvas[l] == '+')
                                    canvas[l] = '|';
                }

        // Print the final nodes
        foreach (var node in nodes)
        {
            Console.Write(node.PadRight(4, ' '));
        }
        Console.WriteLine(); // Ensure there's a final newline at the end
    }

    public Graph GenerateGraph()
    {
        var graph = new Graph();
        for (int i = 0; i < _nodes.Count; i++)
        {
            graph.Nodes.Add($"Node {i + 1}");
        }

        for (int i = 0; i < _nodes.Count; i++)
        {
            for (int j = i + 1; j < _nodes.Count; j++)
            {
                if (_acceptanceMatrix[i, j] > 0)
                {
                    graph.Edges.Add(Tuple.Create(i, j));
                }
            }
        }

        return graph;
    }

    public Graph GenerateGraphWithGrades()
    {
        var nodes = Enumerable.Range(1, _acceptanceMatrix.GetLength(0)).Select(n => $"Node {n}").ToList();
        return new Graph(nodes, _acceptanceMatrix);
    }
}