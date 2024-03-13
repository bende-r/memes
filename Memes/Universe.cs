using System.Text.Json.Serialization;
using System.Text.Json;

namespace Memes;

public class Universe
{
    [JsonPropertyName("entities")]
    public List<string> Entities { get; set; } = new List<string>();

    [JsonPropertyName("relation_types")]
    public List<string> RelationTypes { get; set; } = new List<string>();

    [JsonPropertyName("attributes")]
    public List<string> Attributes { get; set; } = new List<string>();

    [JsonPropertyName("operation")]
    public List<string> Operations { get; set; } = new List<string>();

    [JsonPropertyName("statements")]
    public Dictionary<string, Relationship> Statements { get; set; } = new Dictionary<string, Relationship>();

    public static Universe FromJson(string json)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true
        };

        var result = JsonSerializer.Deserialize<Universe>(json, options);
        if (result == null)
            throw new InvalidOperationException("Failed to deserialize the universe JSON into the Universe object.");
        
        return result;
    }

    public static Universe MergeUniverses(List<string> jsonUniverseStrings)
    {
        var mergedUniverse = new Universe();

        foreach (var json in jsonUniverseStrings)
        {
            Universe universe = FromJson(json);
            mergedUniverse.Entities.AddRange(universe.Entities);
            mergedUniverse.RelationTypes.AddRange(universe.RelationTypes);
            mergedUniverse.Attributes.AddRange(universe.Attributes);
            mergedUniverse.Operations.AddRange(universe.Operations);
            foreach (var statement in universe.Statements)
                if (!mergedUniverse.Statements.ContainsKey(statement.Key))
                {
                    mergedUniverse.Statements[statement.Key] = statement.Value;
                }
                else
                {
                    // Merge the relationships if the key already exists
                    Relationship existingRelation = mergedUniverse.Statements[statement.Key];
                    existingRelation.Is = existingRelation.Is ?? new List<string>();
                    existingRelation.Can = existingRelation.Can ?? new List<string>();
                    existingRelation.Are = existingRelation.Are ?? new List<string>();

                    if (statement.Value.Is != null) existingRelation.Is.AddRange(statement.Value.Is);
                    if (statement.Value.Can != null) existingRelation.Can.AddRange(statement.Value.Can);
                    if (statement.Value.Are != null) existingRelation.Are.AddRange(statement.Value.Are);
                }
        }

        // Removing duplicates
        mergedUniverse.Entities = mergedUniverse.Entities.Distinct().ToList();
        mergedUniverse.RelationTypes = mergedUniverse.RelationTypes.Distinct().ToList();
        mergedUniverse.Attributes = mergedUniverse.Attributes.Distinct().ToList();
        mergedUniverse.Operations = mergedUniverse.Operations.Distinct().ToList();

        return mergedUniverse;
    }

    // Assuming allStatements should be a combination of all entities and their attributes and operations
    public List<string> GetAllStatements()
    {
        List<string> allStatements = new List<string>();
        if (Statements == null)
            throw new InvalidOperationException("Statements are empty");
        
        foreach (var statement in Statements)
        {
            string entity = statement.Key;
            var relations = statement.Value;
            if (relations.Is != null)
                allStatements.AddRange(relations.Is.Select(attr => $"{entity} is {attr}"));

            if (relations.Can != null)
                allStatements.AddRange(relations.Can.Select(action => $"{entity} can {action}"));
            
            if (relations.Are != null)
                allStatements.AddRange(relations.Are.Select(attr => $"{entity} are {attr}"));
            
        }
        return allStatements;
    }
}