using System.Text;
using CommandLine;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.ResetColor();
Console.Clear();

Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.WriteLine("╒═══════════════════════════════════════════════════╕");
Console.WriteLine("│ Welcome to the GameEngine interactive console app │");
Console.WriteLine("╘═══════════════════════════════════════════════════╛");
Console.ResetColor();
Console.WriteLine();
Console.WriteLine("Type 'help' for help. Type 'exit' or Ctrl-C to exit.");
Console.WriteLine("");

new Runtime();

class Runtime {
    GameEngine game = new GameEngine();

    static private List<String> splitter(string str) {
        // https://stackoverflow.com/a/14655199/246887
        return str.Split('"')
            .Select((element, index) => index % 2 == 0  // If even index
                    ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  // Split the item
                    : new string[] { element })  // Keep the entire item
            .SelectMany(element => element).ToList();
    }

    public Runtime() {
        game.SetSize(23);

        while (true) {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("GameEngine> ");
            Console.ResetColor();
            var input = Console.ReadLine();
            if (input == null) {
                continue;
            }
            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)) {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Have a great day. \u263A");
                Console.ResetColor();
                break;
            } else {
                var result = Parser.Default.ParseArguments<Inspect>(splitter(input))
                    .MapResult(
                        (Inspect o) => {
                            switch (o.noun!) {
                                case "size": {
                                        return $"{game.Size}";
                                    }
                                default:
                                    return "unknown inspect noun.";
                            }
                        },
                        errors => "error");
                Console.WriteLine(result);
            }
        }
    }

    [Verb("inspect", HelpText = "inspect an object")]
    public class Inspect {
        [Value(0, HelpText = "'size'", Required = true)]
        public string? noun { get; set; }
    }
};