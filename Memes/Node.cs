namespace Memes;

class Node
{
    private readonly List<string> _statements;

    public Node(List<string> statements)
    {
        this._statements = statements ?? new List<string>();
    }

    public List<string> Share() => new List<string>(_statements);
    public List<string> Share(int n) => _statements.Take(n).ToList();
    public List<string> Share(int i, int j) => _statements.Skip(i).Take(j - i + 1).ToList();

    public void Say() => Say(Share());
    public void Say(int n) => Say(Share(n));
    public void Say(int i, int j) => Say(Share(i, j));

    private void Say(List<string> sharedStatements)
    {
        foreach (var statement in sharedStatements)
            Console.WriteLine(statement);
        
    }

    protected int Compare(List<string> otherStatements)
    {
        // Using Intersect will give us only the elements that exist in both lists
        return _statements.Intersect(otherStatements).Count();
    }

    public int Listen(List<string> otherStatements)
    {
        // The Listen method now returns the count of matches, as Compare does
        return Compare(otherStatements);
    }
}