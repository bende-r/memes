namespace Memes;

public class Population
{
    private readonly List<Node> _nodes;

    internal Population(List<Node> nodes)
    {
        this._nodes = nodes ?? new List<Node>();
    }

    public void Show()
    {
        for (int i = 0; i < _nodes.Count; i++)
        {
            Console.WriteLine($"Node {i + 1} statements:");
            _nodes[i].Say();
            Console.WriteLine();
        }
    }
}