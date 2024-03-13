namespace Memes;

class Program
{
    private static Random _random = new Random();

    static void Main()
    {
        Console.WriteLine(Environment.Version);

        string jsonBasics = """
                            {
                                        "entities": [
                                            "Grass", "Sun", "Love", "Water", "Sky", "Birds", "Snow", "Fire", "Trees", "Mountains", "Star", "Everything"
                                        ],
                                        "relation_types": ["is", "can", "are"],
                                        "attributes": ["bright", "green", "big", "organic", "wet", "blue", "cold", "hot", "tall", "high"],
                                        "operation": ["shine", "grow", "leak", "live", "sing"],
                                        "statements": {
                                            "Grass": { "is": ["green", "organic", "tall"], "can": ["grow"] },
                                            "Sun": { "is": ["bright", "hot", "big"], "can": ["shine"] },
                                            "Love": { "is": ["everything"] },
                                            "Water": { "is": ["wet"] },
                                            "Sky": { "is": ["blue"] },
                                            "Birds": { "can": ["fly", "sing"] },
                                            "Snow": { "is": ["cold"] },
                                            "Fire": { "is": ["hot"] },
                                            "Trees": { "are": ["tall"] },
                                            "Mountains": { "are": ["high"] },
                                            "Star": { "is": ["bright"] },
                                            "Everything": { "is": ["connected"] }
                                        }
                                    }
                            """;

        string jsonProgrammingSafetyByGoogle = """
                                               {
                                                         "entities": [
                                                           "Memory safety vulnerabilities",
                                                           "Secure-by-Design approach",
                                                           "Memory-unsafe languages",
                                                           "Memory corruption vulnerabilities",
                                                           "Safe Coding",
                                                           "Memory-safe languages",
                                                           "Rust",
                                                           "Java",
                                                           "Go",
                                                           "C++",
                                                           "Incremental transition",
                                                           "Hardware security features",
                                                           "Memory-safe ecosystem",
                                                           "Cross-language attacks",
                                                           "XSS attacks",
                                                           "Software security",
                                                           "Developer ecosystems"
                                                         ],
                                                         "relation_types": [
                                                           "is",
                                                           "are",
                                                           "can"
                                                         ],
                                                         "attributes": [
                                                           "widespread",
                                                           "leading causes",
                                                           "high assurance",
                                                           "rigorous",
                                                           "temporal safety",
                                                           "gradual transition",
                                                           "existing codebase",
                                                           "safety improvements",
                                                           "spatial safety",
                                                           "memory usage",
                                                           "inter-procedural calls",
                                                           "better performance",
                                                           "security bug",
                                                           "tooling",
                                                           "consumers of software",
                                                           "security vulnerabilities",
                                                           "responsibility",
                                                           "secure-coding guidelines",
                                                           "security threat",
                                                           "coding error",
                                                           "configuration change",
                                                           "Secure-by-Design approach",
                                                           "developer ecosystems",
                                                           "safety and security",
                                                           "security invariants",
                                                           "vulnerabilities",
                                                           "assurance levels",
                                                           "memory safe languages",
                                                           "external memory-safe ecosystem",
                                                           "Linux Kernel",
                                                           "safe coding",
                                                           "deployment",
                                                           "guidance",
                                                           "frameworks",
                                                           "best practices",
                                                           "digital domain"
                                                         ],
                                                         "operation": [
                                                           "addressing",
                                                           "improving",
                                                           "transitioning",
                                                           "investing",
                                                           "building out",
                                                           "engaging",
                                                           "sharing",
                                                           "partnering",
                                                           "advancing"
                                                         ],
                                                         "statements": {
                                                           "Memory safety vulnerabilities": {
                                                             "is": [
                                                               "the standard for attacking software",
                                                               "how attackers are having success"
                                                             ],
                                                             "are": [
                                                               "widespread",
                                                               "one of the leading causes of vulnerabilities"
                                                             ]
                                                           },
                                                           "Secure-by-Design approach": {
                                                             "is": [
                                                               "centered around comprehensive adoption of languages with rigorous memory safety guarantees"
                                                             ]
                                                           },
                                                           "Memory-unsafe languages": {
                                                             "are": [
                                                               "still commonly exploited"
                                                             ]
                                                           },
                                                           "Memory corruption vulnerabilities": {
                                                             "are": [
                                                               "used in two thirds of 0-day exploits detected in the wild"
                                                             ]
                                                           },
                                                           "Safe Coding": {
                                                             "is": [
                                                               "Google's approach to addressing vulnerabilities"
                                                             ]
                                                           },
                                                           "Memory-safe languages": {
                                                             "are": [
                                                               "Java",
                                                               "Go",
                                                               "Rust",
                                                               "C",
                                                               "C++",
                                                               "Python",
                                                               "C51 ASM",
                                                             ]
                                                           },
                                                           "Rust": {
                                                             "is": [
                                                               "a language that Google is investing in",
                                                               "enhancing interoperability with C++ code",
                                                               "being considered for adoption in existing codebases"
                                                             ]
                                                           },
                                                           "Java": {
                                                             "is": [
                                                               "considered for adoption in existing codebases"
                                                             ]
                                                           },
                                                           "Go": {
                                                             "is": [
                                                               "considered for adoption in existing codebases"
                                                             ]
                                                           },
                                                           "C++": {
                                                             "is": [
                                                               "a language with significant challenges for transitioning to memory safety",
                                                               "being considered for a safer subset with hardware security features"
                                                             ]
                                                           },
                                                           "Incremental transition": {
                                                             "is": [
                                                               "considered for existing C++ codebases"
                                                             ]
                                                           },
                                                           "Hardware security features": {
                                                             "are": [
                                                               "considered for augmenting memory safety in C++"
                                                             ]
                                                           },
                                                           "Memory-safe ecosystem": {
                                                             "is": [
                                                               "being advanced through investments and grants"
                                                             ]
                                                           },
                                                           "Cross-language attacks": {
                                                             "are": [
                                                               "being addressed when mixing Rust and C++"
                                                             ]
                                                           },
                                                           "XSS attacks": {
                                                             "were": [
                                                               "eliminated through tooling"
                                                             ]
                                                           },
                                                           "Software security": {
                                                             "is": [
                                                               "the responsibility of the ecosystem, not just the developer"
                                                             ]
                                                           },
                                                           "Developer ecosystems": {
                                                             "are": [
                                                               "the focus of a Secure-by-Design approach",
                                                               "designed for safety and security",
                                                               "responsible for ensuring security invariants",
                                                               "preventing entire classes of vulnerabilities"
                                                             ]
                                                           }
                                                         }
                                                       }
                                               """;

        string jsonRosesAreRedVialetsAreBlueMemes = """
                                                    {
                                                                "entities": [
                                                                    "Roses", "Violets", "Good morning text", "Screenshots", "Toxic text", "Expectation", "Reality", "Drama", "Drama queen", "Silent treatment", "Evidence", "Manipulation", "Control", "Trust issues", "Therapist", "Red flags", "Toxic love", "Sanctuary", "Referee", "Space", "Battleground", "Emotional warfare", "Unicorn", "Lecture", "Landmine", "Soap opera", "Compromise", "Band-Aid", "Fire"
                                                                ],
                                                                "relation_types": ["comes with", "is a", "feels like", "means", "turns into", "requires", "loses"],
                                                                "attributes": ["demanding", "full-time", "explosive", "dramatic", "manipulative", "controlling", "distrustful", "negotiating", "red-flagged", "surviving", "crying", "volume-speaking", "battle-like", "prison-like", "foreign", "band-aided", "gasoline-like"],
                                                                "operation": ["run", "find peace", "save", "talk", "argue", "love", "retreat"],
                                                                "statements": {
                                                                    "Good morning text": { "comes with": ["demanding"] },
                                                                    "Screenshots": { "is a": ["full-time"] },
                                                                    "Toxic text": { "feels like": ["explosive"] },
                                                                    "Expectation": { "is": ["flowers"] },
                                                                    "Reality": { "is": ["drama"] },
                                                                    "Drama": { "means": ["more drama"] },
                                                                    "Drama queen": { "requires": ["find peace"] },
                                                                    "Silent treatment": { "is": ["volume-speaking"] },
                                                                    "Evidence": { "is": ["screenshots"] },
                                                                    "Manipulation": { "turns into": ["trust issues"] },
                                                                    "Control": { "is a": ["love_language"] },
                                                                    "Trust issues": { "are": ["norm"] },
                                                                    "Therapist": { "feels like": ["hostage_negotiator"] },
                                                                    "Red flags": { "are": ["red-flagged"] },
                                                                    "Toxic love": { "is": ["surviving"] },
                                                                    "Sanctuary": { "loses": ["battle-like"] },
                                                                    "Referee": { "is": ["relationship status"] },
                                                                    "Space": { "means": ["break_from_you"] },
                                                                    "Battleground": { "is": ["heart condition"] },
                                                                    "Emotional warfare": { "requires": ["retreat"] },
                                                                    "Unicorn": { "is": ["unreal"] },
                                                                    "Lecture": { "turns into": ["talk"] },
                                                                    "Landmine": { "is": ["Toxic love"] },
                                                                    "Soap opera": { "feels like": ["relationship"] },
                                                                    "Compromise": { "is": ["foreign word"] },
                                                                    "Band-Aid": { "is": ["sorry saying"] },
                                                                    "Fire": { "is": ["gasoline-like"] }
                                                                }
                                                            }
                                                    """;

        string jsonElectronicsRepearMemes = """
                                            {
                                                        "entities": [
                                                            "Electronics Repair"
                                                        ],
                                                        "relation_types": ["is", "provides", "has"],
                                                        "attributes": [
                                                            "right way",
                                                            "enjoyment",
                                                            "persistence",
                                                            "ultimate experience",
                                                            "long-lasting",
                                                            "trustworthy",
                                                            "passion",
                                                            "seriousness",
                                                            "care",
                                                            "lifetime quality",
                                                            "improvement",
                                                            "ease",
                                                            "reliability",
                                                            "life restoration",
                                                            "versatility",
                                                            "determination",
                                                            "restoration"
                                                        ],
                                                        "operation": [
                                                            "fixing",
                                                            "repairing",
                                                            "upgrading",
                                                            "troubleshooting",
                                                            "restoring"
                                                        ],
                                                        "statements": {
                                                            "Electronics Repair": {
                                                                "is": [
                                                                    "right way",
                                                                    "ultimate experience",
                                                                    "long-lasting",
                                                                    "trustworthy",
                                                                    "seriousness",
                                                                    "care",
                                                                    "lifetime quality",
                                                                    "improvement",
                                                                    "ease",
                                                                    "reliability",
                                                                    "versatility",
                                                                    "determination",
                                                                    "restoration"
                                                                ],
                                                                "provides": [
                                                                    "enjoyment",
                                                                    "passion",
                                                                    "life restoration"
                                                                ],
                                                                "has": [
                                                                    "persistence",
                                                                    "care"
                                                                ]
                                                            }
                                                        }
                                                    }
                                            """;

        //Universe topics = Universe.FromJson(jsonBasics);
        Universe topics = Universe.MergeUniverses(new List<string> {
            jsonBasics,
            jsonProgrammingSafetyByGoogle,
            jsonElectronicsRepearMemes,
            jsonRosesAreRedVialetsAreBlueMemes
        });

        List<Node> nodes = GenerateNodes(10, topics.GetAllStatements(), 4, 6);

        Population society = new Population(nodes);
        society.Show();

        Relations relations = new Relations(nodes);
        relations.PrintMatrix(); //default = false, show 0 = true
        Console.WriteLine();

        relations.PrintGraph();
        Console.WriteLine();

        Graph graph = relations.GenerateGraph();

        Graph graphWithGrades = relations.GenerateGraphWithGrades();
        graphWithGrades.PrintStandardWayWithGrades();

        graph.PrintPseudoGraphically();
        Console.WriteLine();

        //graph.PrintStandardWay();
        //Console.WriteLine();

        graph.PrintAsSets();
        Console.WriteLine();

        graph.PrintLongestPath();
        Console.WriteLine();

        graph.PrintCycles();
        Console.WriteLine();

        relations.Print();
        Console.WriteLine();
    }

    public static List<Node> GenerateNodes(int numberOfNodes = 10, List<string>? statements = null, int minKnowledgeLimit = 2, int maxKnowledgeLimit = 6)
    {
        if (statements == null)
            statements = new List<string>();

        List<Node> nodes = new List<Node>();
        for (int i = 0; i < numberOfNodes; i++)
        {
            var randomStatements = statements.OrderBy(x => _random.Next()).Take(_random.Next(minKnowledgeLimit, maxKnowledgeLimit)).ToList();
            nodes.Add(new Node(randomStatements));
        }
        return nodes;
    }
}