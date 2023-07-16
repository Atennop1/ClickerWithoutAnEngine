using ClickerWithoutAnEngine.Math;

namespace ClickerWithoutAnEngine.Score
{
    public interface IReadOnlyScore
    {
        IExponentialNumber Value { get; }
        
        bool CanIncrease(IExponentialNumber number);
        bool CanDecrease(IExponentialNumber number);
    }
}