using System.Numerics;
using System.Text;

#pragma warning disable CS0660, CS0661

namespace ClickerWithoutAnEngine.Core
{
    public sealed class LargeInt : ILargeInt
    {
        public BigInteger Numerator { get; }
        public BigInteger Denominator { get; }

        #region Constructors

        public LargeInt(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            
            value = value.Trim().Replace(",", "");
            var pos = value.IndexOf('.');
            value = value.Replace(".", "");

            ILargeInt largeInt;
            if (pos < 0)
            {
                var numerator = BigInteger.Parse(value);
                largeInt = new LargeInt(numerator).Simplify();
            }
            else
            {
                var numerator = BigInteger.Parse(value);
                var denominator = BigInteger.Pow(10, value.Length - pos);
                largeInt = new LargeInt(numerator, denominator).Simplify();
            }
            
            Numerator = largeInt.Numerator;
            Denominator = largeInt.Denominator;
        }

        public LargeInt(BigInteger numerator, BigInteger denominator)
        {
            Numerator = numerator;
            
            if (denominator == 0)
                throw new ArgumentException("Denominator equals 0");
            
            Denominator = BigInteger.Abs(denominator);
        }

        public LargeInt(BigInteger value)
        {
            Numerator = value;
            Denominator = BigInteger.One;
        }

        public LargeInt(ILargeInt value)
        {
            if (Equals(value, null))
                throw new ArgumentNullException(nameof(value));
            
            Numerator = value.Numerator;
            Denominator = value.Denominator;
        }

        public LargeInt(ulong value)
        {
            Numerator = new BigInteger(value);
            Denominator = BigInteger.One;
        }

        public LargeInt(long value)
        {
            Numerator = new BigInteger(value);
            Denominator = BigInteger.One;
        }

        public LargeInt(uint value)
        {
            Numerator = new BigInteger(value);
            Denominator = BigInteger.One;
        }

        public LargeInt(int value)
        {
            Numerator = new BigInteger(value);
            Denominator = BigInteger.One;
        }
        
        #endregion

        #region Operations

        private static int Compare(ILargeInt left, ILargeInt right)
        {
            if (Equals(left, null))
                throw new ArgumentNullException(nameof(left));
            
            if (Equals(right, null))
                throw new ArgumentNullException(nameof(right));
            
            var first = left.Numerator;
            var second = right.Numerator;
            
            first *= right.Denominator;
            second *= left.Denominator;

            return BigInteger.Compare(first, second);
        }
        
        public int CompareTo(ILargeInt? other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            
            return Compare(this, other);
        }

        public int CompareTo(object? other)
        {
            if (other is not LargeInt largeInt)
                throw new InvalidOperationException();
            
            return Compare(this, largeInt);
        }

        public bool Equals(ILargeInt? other)
        {
            if (other == null || GetType() != other.GetType())
                return false;

            return CompareTo(other) == 0;
        }
        
        public override string ToString()
        {
            var precision = 12;
            this.Simplify();

            var result = BigInteger.DivRem(Numerator, Denominator, out var remainder);

            if (remainder == 0)
                return result.ToString();
            
            var decimals = Numerator * BigInteger.Pow(10, precision) / Denominator;

            if (decimals == 0)
                return result.ToString();

            var stringBuilder = new StringBuilder();

            while (precision-- > 0 && decimals > 0)
            {
                stringBuilder.Append(decimals%10);
                decimals /= 10;
            }
            
            return result + "." + new string(stringBuilder.ToString().Reverse().ToArray()).TrimEnd(new[] { '0' });
        }

        #endregion
    }
}