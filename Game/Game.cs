
namespace BeagleBaroo.Console.MathGame
{
    using System;

    public class Game
    {
        const int NumberOfQuestions = 5;
        const int MinimumValue = 0;
        const int MaximumValue = 101;
        private Random _random;
        public Game()
        {
            GamePlayedAt = DateTime.Now.ToString("ddd dd MMM yyyy HH:mm");
            GameQuestions = new List<AbstractQuestion>();
            _random = new Random();
        }

        public List<AbstractQuestion> GameQuestions { get; set; }
        public string GamePlayedAt { get; set; }

        public void GenerateQuestions()
        {
            AbstractQuestion? abstractQuestion = null;

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                int randomInt = _random.Next(1, 5);
                switch (randomInt)
                {
                    case 1:
                        abstractQuestion = new AdditionQuestion(_random, MinimumValue, MaximumValue);
                        break;
                    case 2:
                        abstractQuestion = new SubtractionQuestion(_random, MinimumValue, MaximumValue);
                        break;
                    case 3:
                        abstractQuestion = new MultiplicationQuestion(_random, MinimumValue, MaximumValue);
                        break;
                    case 4:
                        abstractQuestion = new DivisionQuestion(_random, MinimumValue, MaximumValue);
                        break;
                }

                if (abstractQuestion is not null)
                {
                    GameQuestions.Add(abstractQuestion);
                }
            }
        }

        public void AnswerQuestions()
        {
            for (int i = 0; i < GameQuestions.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: What is {GameQuestions[i].GetDescription()}. Please type your answer followed by pressing enter");
                string enteredAnswer = Console.ReadLine() ?? "";

                bool validAnswer = int.TryParse(enteredAnswer, out int iEnteredAnswer);
                if (validAnswer is false)
                {
                    GameQuestions[i].AnsweredCorrectly = false;
                    continue;
                }
                else
                {
                    GameQuestions[i].GivenAnswer = iEnteredAnswer;
                    GameQuestions[i].SetActualAnswer();
                    GameQuestions[i].SetAnsweredCorrectly();
                }

                Console.WriteLine($"Your answer was: {GameQuestions[i]?.GivenAnswer?.ToString() ?? "Unanswered"}.");
                if (GameQuestions[i].AnsweredCorrectly is true)
                {
                    Console.WriteLine($"Well done, this was the correct answer!");
                }
                else
                {
                    Console.WriteLine($"This was not correct.");
                }
            }
        }
    }
}