namespace ClickerWithoutAnEngine.Score
{
    public interface IReadOnlyMultipliedScore
    {
        float MultiplicationCoefficient { get; }
        
        bool CanIncreaseCoefficient(float value);
        bool CanDecreaseCoefficient(float value);
    }
}