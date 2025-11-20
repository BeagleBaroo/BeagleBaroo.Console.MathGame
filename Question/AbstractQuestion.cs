namespace BeagleBaroo.MathGame;

public abstract class AbstractQuestion : IQuestion
{
    public AbstractQuestion(Random random, int minimumValue, int maximumValue)
    {
        Random = random;
        MinimumValue = minimumValue;
        MaximumValue = maximumValue;
    }

    protected Random Random;
    protected int MinimumValue;
    protected int MaximumValue;

    public string? Operand { get; set; }
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
    public int? GivenAnswer { get; set; }
    public int ActualAnswer { get; set; }
    public bool AnsweredCorrectly { get; set; }
    public void SetAnsweredCorrectly()
    {
        if (GivenAnswer is null)
        {
            AnsweredCorrectly = false;
        }
        else
        {
            AnsweredCorrectly = GivenAnswer.Equals(ActualAnswer);
        }
    }

    public string GetDescription()
    {
        return $"{FirstNumber} {Operand} {SecondNumber}";
    }

    public abstract void SetActualAnswer();

    public virtual void SetNumbers()
    {
        FirstNumber = Random.Next(MinimumValue, MaximumValue);
        SecondNumber = Random.Next(MinimumValue, MaximumValue);
    }
}
