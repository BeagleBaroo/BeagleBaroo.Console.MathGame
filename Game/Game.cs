
namespace BeagleBaroo.MathGame
{
    public class Game
    {
        const int NumberOfQuestions = 5;
        const int MinimumValue = 0;
        const int MaximumValue = 101;
        static List<string> ValidOperandOptions = new List<string> { "+", "-", "*", "/" };
        private Random _random;
        public Game()
        {
            GamePlayedAt = DateTime.Now.ToString("ddd dd MMM yyyy HH:mm");
            GameQuestions = new List<AbstractQuestion>();
            _random = new Random();
        }

        public List<AbstractQuestion> GameQuestions { get; set; }
        public string GamePlayedAt { get; set; }

        public void Play()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                string operand = GetOperandFromUser(i + 1);
                AbstractQuestion abstractQuestion = GenerateQuestion(operand);
                if (abstractQuestion is not null)
                {
                    AnswerQuestion(abstractQuestion, i + 1);
                    GameQuestions.Add(abstractQuestion);
                }
            }

        }

        public string GetOperandFromUser(int questionIndex)
        {
            Console.Clear();

            string? operand;
            Console.WriteLine($"For question number {questionIndex}, please choose one of the following:");
            Console.WriteLine($"- Type '+' followed by enter for an addition question");
            Console.WriteLine($"- Type '-' followed by enter for a subtraction question");
            Console.WriteLine($"- Type '*' followed by enter for a multiplication question");
            Console.WriteLine($"- Type '/' followed by enter for a division question");
            Console.WriteLine();
            operand = Console.ReadLine() ?? "";

            while (ValidOperandOptions.Contains(operand) is false)
            {
                Console.WriteLine();
                Console.WriteLine("Oops! It looks as though that was not a valid choice, please try again: ");
                operand = Console.ReadLine() ?? "";
            }

            return operand;
        }

        public AbstractQuestion GenerateQuestion(string operand)
        {
            AbstractQuestion? abstractQuestion = null;

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                int randomInt = _random.Next(1, 5);
                switch (operand)
                {
                    case "+":
                        abstractQuestion = new AdditionQuestion(_random, MinimumValue, MaximumValue);
                        break;
                    case "-":
                        abstractQuestion = new SubtractionQuestion(_random, MinimumValue, MaximumValue);
                        break;
                    case "*":
                        abstractQuestion = new MultiplicationQuestion(_random, MinimumValue, MaximumValue);
                        break;
                    case "/":
                        abstractQuestion = new DivisionQuestion(_random, MinimumValue, MaximumValue);
                        break;
                }
            }

            return abstractQuestion;
        }

        public void AnswerQuestion(AbstractQuestion abstractQuestion, int questionIndex)
        {
            if (abstractQuestion is not null)
            {
                Console.Clear();
                Console.WriteLine($"Question {questionIndex}: What is {abstractQuestion.GetDescription()}. Please type your answer followed by pressing enter");
                Console.WriteLine();
                string enteredAnswer = Console.ReadLine() ?? "";

                bool validAnswer = int.TryParse(enteredAnswer, out int iEnteredAnswer);
                if (validAnswer is false)
                {
                    abstractQuestion.AnsweredCorrectly = false;
                }
                else
                {
                    abstractQuestion.GivenAnswer = iEnteredAnswer;
                    abstractQuestion.SetActualAnswer();
                    abstractQuestion.SetAnsweredCorrectly();
                }

                Console.WriteLine();
                Console.WriteLine($"Your answer was: {abstractQuestion?.GivenAnswer?.ToString() ?? "Unanswered"}.");
                if (abstractQuestion.AnsweredCorrectly is true)
                {
                    Console.WriteLine($"Well done, this was the correct answer!");
                }
                else
                {
                    Console.WriteLine($"This was not correct.");
                }
                Console.WriteLine();

                if (questionIndex.Equals(NumberOfQuestions))
                {
                    Console.WriteLine("Press any key to continue to return to the main menu");
                }
                else
                {
                    Console.WriteLine("Press any key to continue to the next question");
                }
                Console.ReadKey();
            }
        }
    }
}