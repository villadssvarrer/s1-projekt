class Game {
    static World world = new World();
    static Context context = new Context(world.GetEntry());

    static void Main(string[] args) {
        Console.WriteLine("Welcome to the World of Calorie!");

        context.GetCurrent().Welcome();
        context.GetCurrent().ShowExits();

        while (context.IsDone() == false) {
            Console.Write("> ");

            string? line = Console.ReadLine();

            if (line == null) {
                continue;
            }

            // parse line
            string[] elements = line.Split(" ");
            string command = elements[0];
            string[] parameters = GetParameters(elements);

            switch (command) {
            case "exit":
                context.MakeDone();
                break;
            case "go":
                if (parameters.Length == 0) {
                    Console.WriteLine("I don't seem to know where that is");
                }
                else {
                    context.Transition(string.Join(" ", parameters));
                }
                break;
            case "help":
                Console.WriteLine(" - exit  Exit the program");
                Console.WriteLine(" - go    Follow an exit");
                Console.WriteLine(" - help  Display a help message");
                break;
            default:
                Console.WriteLine("Unknown command: '" + command + "'");
                break;
            }
        }

        Console.WriteLine("Game Over");
    }

    private static string[] GetParameters(string[] input) {
        string[] output = new string[input.Length - 1];

        for (int i = 0; i < output.Length; i++) {
            output[i] = input[i + 1];
        }

        return output;
    }
}