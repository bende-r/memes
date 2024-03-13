namespace Memes;

public class Graph
{
    public List<string> Nodes { get; set; }
    public List<Tuple<int, int>> Edges { get; set; }
    public int[,] AcceptanceMatrix { get; set; }

    public Graph()
    {
        Nodes = new List<string>();
        Edges = new List<Tuple<int, int>>();
        AcceptanceMatrix = new int[0, 0];
    }

    public Graph(List<string> nodes, int[,] acceptanceMatrix)
    {
        Nodes = nodes;
        AcceptanceMatrix = acceptanceMatrix;
        Edges = new List<Tuple<int, int>>();
    }

    // Helper method for DFS to find the longest path
    private void DFSForLongestPath(int node, bool[] visited, List<int> currentPath, ref List<int> longestPath)
    {
        visited[node] = true;
        currentPath.Add(node);

        foreach (var edge in Edges.Where(e => e.Item1 == node || e.Item2 == node))
        {
            int nextNode = edge.Item1 == node ? edge.Item2 : edge.Item1;
            if (!visited[nextNode])
                DFSForLongestPath(nextNode, visited, currentPath, ref longestPath);
            
        }

        if (currentPath.Count > longestPath.Count)
            longestPath = new List<int>(currentPath);
        
        visited[node] = false;
        currentPath.RemoveAt(currentPath.Count - 1);
    }

    public void PrintLongestPath()
    {
        List<int> longestPath = new List<int>();
        bool[] visited = new bool[Nodes.Count];
        for (int i = 0; i < Nodes.Count; i++)
            DFSForLongestPath(i, visited, new List<int>(), ref longestPath);

        Console.WriteLine("Longest path (in connectivity order):");
        foreach (var node in longestPath)
            Console.Write($"{Nodes[node]} ");
        
        Console.WriteLine();
    }

    // Helper method for DFS to detect cycles
    private bool DFSForCycles(int node, bool[] visited, int parent, List<int> currentPath, List<List<int>> cycles, HashSet<Tuple<int, int>> visitedEdges)
    {
        visited[node] = true;
        currentPath.Add(node);

        foreach (var edge in Edges.Where(e => e.Item1 == node || e.Item2 == node))
        {
            int nextNode = edge.Item1 == node ? edge.Item2 : edge.Item1;
            Tuple<int, int> edgeTuple = new Tuple<int, int>(Math.Min(node, nextNode), Math.Max(node, nextNode));

            if (!visited[nextNode])
            {
                if (!visitedEdges.Contains(edgeTuple))
                {
                    visitedEdges.Add(edgeTuple);
                    if (DFSForCycles(nextNode, visited, node, currentPath, cycles, visitedEdges))
                        return true; // Only return true if you want to stop at the first cycle found

                    visitedEdges.Remove(edgeTuple);
                }
            }
            else if (nextNode != parent && currentPath.Count > 2 && !visitedEdges.Contains(edgeTuple))
            {
                // Found a back edge indicating a cycle
                int cycleStartIndex = currentPath.IndexOf(nextNode);
                if (cycleStartIndex != -1)
                {
                    var cycle = currentPath.GetRange(cycleStartIndex, currentPath.Count - cycleStartIndex);
                    cycle.Add(nextNode); // Complete the cycle
                    cycles.Add(cycle);
                    return true; // Only return true if you want to stop at the first cycle found
                }
            }
        }

        currentPath.RemoveAt(currentPath.Count - 1);
        visited[node] = false;
        return false;
    }

    public void PrintCycles()
    {
        List<List<int>> cycles = new List<List<int>>();
        bool[] visited = new bool[Nodes.Count];
        HashSet<Tuple<int, int>> visitedEdges = new HashSet<Tuple<int, int>>();

        for (int i = 0; i < Nodes.Count; i++)
            if (!visited[i])
                DFSForCycles(i, visited, -1, new List<int>(), cycles, visitedEdges);
            
        

        Console.WriteLine($"The number of cycles: {cycles.Count}");
        Console.WriteLine("The list of cycles:");
        foreach (var cycle in cycles)
            Console.WriteLine("(" + string.Join("<>", cycle.Select(node => Nodes[node])) + ")");
    }

    public void PrintPseudoGraphically()
    {
        // (Implement the pseudo-graphical printing logic here, similar to PrintGraph method above)
    }

    public void PrintStandardWay()
    {
        foreach (var edge in Edges)
            Console.WriteLine($"{Nodes[edge.Item1]} <-> {Nodes[edge.Item2]}");
        
    }

    public void PrintStandardWayWithGrades()
    {
        for (int i = 0; i < Nodes.Count; i++)
            for (int j = i + 1; j < Nodes.Count; j++)
                if (AcceptanceMatrix[i, j] > 0)
                    Console.WriteLine($"{Nodes[i]} <{AcceptanceMatrix[i, j]}> {Nodes[j]}");
        
    }

    public void PrintAsSets()
    {
        Console.WriteLine($"Nodes{{{string.Join(",", Nodes)}}},");
        Console.WriteLine($"Edges{{{string.Join(",", Edges.Select(edge => $"({Nodes[edge.Item1]},{Nodes[edge.Item2]})"))}}}");
    }
}