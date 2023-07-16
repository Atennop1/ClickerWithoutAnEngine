namespace ClickerWithoutAnEngine.Score
{
    public interface IMultipliedScore : IReadOnlyMultipliedScore, IScore
    {
        void Increase(float value);
        void Decrease(float value);
    }
}