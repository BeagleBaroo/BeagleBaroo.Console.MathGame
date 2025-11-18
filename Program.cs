
namespace BeagleBaroo.Console.MathGame
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Text;

    class Program
    {
        static int NumberOfQuestions = 5;
        static int MinimumValue = 0;
        static int MaximumValue = 100;
        static List<string> ValidMenuOptions = new List<string> { "new", "view", "exit" };

        static void Main(string[] args)
        {
            List<Game> games = new List<Game>();
            MainMenu(games);
        }

        static void MainMenu(List<Game> games)
        {
            Console.WriteLine("Welcome to MathGame!");
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Type 'new' and then press enter for a new game");
            Console.WriteLine("2. Type 'view' and then press enter to view a list of previous games");
            Console.WriteLine("3. Type 'exit' and then press enter to close MathGame");
            string userMenuChoice = Console.ReadLine()?.ToLowerInvariant() ?? "";

            while (ValidMenuOptions.Contains(userMenuChoice) is false)
            {
                Console.WriteLine("Oops! It looks as though that was not a valid choice, please try again: ");
                userMenuChoice = Console.ReadLine() ?? "";
            }

            switch (userMenuChoice)
            {
                case "new":
                    games.Add(NewGame());
                    MainMenu(games);
                    break;
                case "view":
                    HistoryMenu(games);
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
            for (int i = 0; i < NumberOfQuestions; i++)
            {

            }

            return newGame;
        }

        static void HistoryMenu(List<Game> games)
        {

        }

        private class Game
        {
            public Game()
            {
                GameQuestions = new List<GameQuestion>();
            }
            public List<GameQuestion> GameQuestions { get; set; }
        }

        private class GameQuestion
        {
            public string? GameId { get; set; }
            public int FirstNumber { get; set; }
            public int SecondNumber { get; set; }
            string? OperationType { get; set; }
            public int GivenAnswer { get; set; }
            public int ActualAnswer { get; set; }
            public bool AnsweredCorrectly { get; set; }
        }

    }
}