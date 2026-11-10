class Game {
    static World world = new World();
    static Context context = new Context(world.GetEntry());

    static void DisplayHelpCommand() {
        var commands = new (string cmd, string desc)[] {
            ("afslut", "Afslutter programmet"),
            ("gå", "Følg en vej"),
            ("hjælp", "Vis en hjælp besked"),
        };

        Console.WriteLine();
        Console.WriteLine("[Kommandoer]");

        foreach (var (cmd, desc) in commands) {
            Console.WriteLine($"{cmd}: {desc}");
        }

        Console.WriteLine();
    }

    static void Main(string[] args) {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // enable danish character support (ø, æ, å)
        Console.WriteLine("Velkommen til World of Calorie!");
        DisplayHelpCommand();
        
        context.GetCurrent().Welcome();
        context.GetCurrent().ShowExits();

        while (context.IsActive()) {
            Console.Write("> ");

            string? line = Console.ReadLine();

            if (line == null) {
                continue;
            }

            string[] elements = line.Split(" ");
            string command = elements[0];
            string[] parameters = GetParameters(elements);

            switch (command) {
            case "afslut":
                context.Stop();
                break;
            case "gå":
                if (parameters.Length == 0) {
                    Console.WriteLine("Ukendt rum");
                }
                else {
                    context.Transition(string.Join(" ", parameters));
                }
                break;
            case "hjælp":
                DisplayHelpCommand();
                break;
            default:
                Console.WriteLine($"Ukendt kommando: '{command}'");
                break;
            }
        }

        Console.WriteLine("Spil afsluttet");
    }

    private static string[] GetParameters(string[] input) {
        string[] output = new string[input.Length - 1];

        for (int i = 0; i < output.Length; i++) {
            output[i] = input[i + 1];
        }

        return output;
    }
}