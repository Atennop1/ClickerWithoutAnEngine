using System.Numerics;

namespace ClickerWithoutAnEngine.Core;

public interface ILargeInt : IComparable, IComparable<ILargeInt>, IEquatable<ILargeInt>
{
    BigInteger Numerator { get; }
    BigInteger Denominator { get; }
}