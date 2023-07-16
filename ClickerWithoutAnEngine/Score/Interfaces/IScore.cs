using ClickerWithoutAnEngine.Math;

namespace ClickerWithoutAnEngine.Score
{
    public interface IScore : IReadOnlyScore
    {
        void Increase(IExponentialNumber number);
        void Decrease(IExponentialNumber number);
    }
}