namespace BeagleBaroo.MathGame;

public class AdditionQuestion : AbstractQuestion
{
    public AdditionQuestion(Random random, int minimumValue, int maximumValue)
        : base(random, minimumValue, maximumValue)
    {
        SetNumbers();
        Operand = "+";
    }

    public override void SetActualAnswer()
    {
        ActualAnswer = FirstNumber + SecondNumber;
    }
}
