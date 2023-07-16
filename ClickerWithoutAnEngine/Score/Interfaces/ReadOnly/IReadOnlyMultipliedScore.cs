namespace ClickerWithoutAnEngine.Score
{
    public interface IReadOnlyMultipliedScore
    {
        float MultiplicationCoefficient { get; }
        
        bool CanIncrease(float value);
        bool CanDecrease(float value);
    }
}