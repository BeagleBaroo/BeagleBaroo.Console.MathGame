
namespace BeagleBaroo.MathGame;

class Program
{
    static List<string> ValidMainMenuOptions = new List<string> { "new", "view", "exit" };

    static void Main(string[] args)
    {
        List<Game> games = new List<Game>();
        MainMenu(games);
    }

    static void MainMenu(List<Game> games)
    {
        Console.Clear();
        Console.WriteLine("Welcome to MathGame!");
        Console.WriteLine("Please select one of the following options:");
        Console.WriteLine("1. Type 'new' and then press enter for a new game");
        Console.WriteLine("2. Type 'view' and then press enter to view a list of previous games");
        Console.WriteLine("3. Type 'exit' and then press enter to close MathGame");
        Console.WriteLine();

        string mainMenuChoice = Console.ReadLine()?.ToLowerInvariant() ?? "";
        while (ValidMainMenuOptions.Contains(mainMenuChoice) is false)
        {
            Console.WriteLine();
            Console.WriteLine("Oops! It looks as though that was not a valid choice, please try again: ");
            mainMenuChoice = Console.ReadLine()?.ToLowerInvariant() ?? "";
        }

        switch (mainMenuChoice)
        {
            case "new":
                games.Add(NewGame());
                MainMenu(games);
                break;
            case "view":
                HistoryMenu(games);
                MainMenu(games);
                break;
            case "exit":
                break;
            default:
                MainMenu(games);
                break;
        }
    }

    static Game NewGame()
    {
        Game newGame = new Game();
        newGame.Play();
        return newGame;
    }

    static void HistoryMenu(List<Game> games)
    {
        Console.Clear();
        if (games.Count == 0)
        {
            Console.WriteLine("No games have been played yet.");
        }
        else
        {
            for (int i = 0; i < games.Count; i++)
            {
                int answeredCorrectly = games[i].GameQuestions.Count(aq => aq.AnsweredCorrectly is true);
                Console.WriteLine($"{i + 1}. {games[i].GamePlayedAt}: {answeredCorrectly} out of 5 questions answered correctly");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to return to the main menu");
        Console.ReadKey();
    }
}
