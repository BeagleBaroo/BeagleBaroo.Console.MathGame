namespace BeagleBaroo.MathGame;

public class SubtractionQuestion : AbstractQuestion
{
    public SubtractionQuestion(Random random, int minimumValue, int maximumValue)
        : base(random, minimumValue, maximumValue)
    {
        SetNumbers();
        Operand = "-";
    }

    public override void SetActualAnswer()
    {
        ActualAnswer = FirstNumber - SecondNumber;
    }
}
