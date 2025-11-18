namespace BeagleBaroo.Console.MathGame
{
    public class DivisionQuestion : AbstractQuestion
    {
        public DivisionQuestion(Random random, int minimumValue, int maximumValue)
            : base(random, minimumValue, maximumValue)
        {
            SetNumbers();
            Operand = "/";
        }

        public override int SetActualAnswer()
        {
            ActualAnswer = FirstNumber / SecondNumber;
        }

        public override void SetNumbers()
        {
            FirstNumber = Random.Next(MinimumValue, MaximumValue);
            SecondNumber = Random.Next(MinimumValue, MaximumValue);

            if (SecondNumber is 0)
            {
                SetNumbers();
            }

            if (FirstNumber % SecondNumber is not 0)
            {
                SetNumbers();
            }
        }
    }
}