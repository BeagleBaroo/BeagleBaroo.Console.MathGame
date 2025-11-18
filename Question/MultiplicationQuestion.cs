namespace BeagleBaroo.Console.MathGame
{
    public class MultiplicationQuestion : AbstractQuestion
    {
        public MultiplicationQuestion(Random random, int minimumValue, int maximumValue)
            : base(random, minimumValue, maximumValue)
        {
            SetNumbers();
            Operand = "*";
        }

        public override void SetActualAnswer()
        {
            ActualAnswer = FirstNumber * SecondNumber;
        }
    }
}