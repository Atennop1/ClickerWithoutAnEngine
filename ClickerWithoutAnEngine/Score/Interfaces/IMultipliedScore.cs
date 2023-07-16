namespace ClickerWithoutAnEngine.Score
{
    public interface IMultipliedScore : IScore, IReadOnlyMultipliedScore
    {
        void IncreaseCoefficient(float value);
        void DecreaseCoefficient(float value);
    }
}