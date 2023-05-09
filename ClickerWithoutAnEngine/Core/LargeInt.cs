using System.Numerics;
#pragma warning disable CS0660, CS0661

namespace ClickerWithoutAnEngine.Core
{
    public sealed class LargeInt : ILargeInt
    {
        public BigInteger Numerator { get; private set; }
        public BigInteger Denominator { get; private set; }

        /*CONSTRUCTORS BLOCK*/
        
        public LargeInt()
        {
            Numerator = BigInteger.Zero;
            Denominator = BigInteger.One;
        }
        
        public LargeInt(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            
            value = value.Replace(",", "");
            var pos = value.IndexOf('.');
            value = value.Replace(".", "");

            LargeInt largeInt;
            if (pos < 0)
            {
                var numerator = BigInteger.Parse(value);
                largeInt = new LargeInt(numerator).Factor();
            }
            else
            {
                var numerator = BigInteger.Parse(value);
                var denominator = BigInteger.Pow(10, value.Length - pos);

                largeInt = new LargeInt(numerator, denominator).Factor();
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

        /*OPERATIONS BLOCK*/
        
        private ILargeInt Add(ILargeInt other)
        {
            if (Equals(other, null))
                throw new ArgumentNullException(nameof(other));

            Numerator = Numerator * other.Denominator + other.Numerator * Denominator;
            Denominator *= other.Denominator;
            return this;
        }

        private ILargeInt Subtract(ILargeInt other)
        {
            if (Equals(other, null))
                throw new ArgumentNullException(nameof(other));

            Numerator = Numerator * other.Denominator - other.Numerator * Denominator;
            Denominator *= other.Denominator;
            return this;
        }

        private ILargeInt Multiply(ILargeInt other)
        {
            if (Equals(other, null))
                throw new ArgumentNullException(nameof(other));

            Numerator *= other.Numerator;
            Denominator *= other.Denominator;
            return this;
        }

        private ILargeInt Divide(ILargeInt other)
        {
            if (Equals(other, null))
                throw new ArgumentNullException(nameof(other));
            
            if (other.Numerator == 0)
                throw new DivideByZeroException();

            Numerator *= other.Denominator;
            Denominator *= other.Numerator;
            return this;
        }

        private ILargeInt Remainder(LargeInt other)
        {
            if (Equals(other, null))
                throw new ArgumentNullException(nameof(other));

            var result = this - Floor(this / other) * other;

            Numerator = result.Numerator;
            Denominator = result.Denominator;
            return this;
        }

        private ILargeInt Pow(int exponent)
        {
            if (Numerator.IsZero) 
                return this;
            
            if (exponent < 0)
            {
                var savedNumerator = Numerator;
                Numerator = BigInteger.Pow(Denominator, -exponent);
                Denominator = BigInteger.Pow(savedNumerator, -exponent);
            }
            else
            {
                Numerator = BigInteger.Pow(Numerator, exponent);
                Denominator = BigInteger.Pow(Denominator, exponent);
            }

            return this;
        }

        private ILargeInt Abs()
        {
            Numerator = BigInteger.Abs(Numerator);
            return this;
        }

        private ILargeInt Negate()
        {
            Numerator = BigInteger.Negate(Numerator);
            return this;
        }

        private ILargeInt Inverse()
        {
            (Numerator, Denominator) = (Denominator, Numerator);
            return this;
        }

        private LargeInt Increment()
        {
            Numerator += Denominator;
            return this;
        }

        private LargeInt Decrement()
        {
            Numerator -= Denominator;
            return this;
        }

        private ILargeInt Floor(ILargeInt value)
        {
            Numerator -= BigInteger.Remainder(value.Numerator, value.Denominator);
            
            if (Numerator < 0)
                Numerator += Denominator;

            Factor();
            return this;
        }
        
        private LargeInt Factor()
        {
            if (Denominator == 1)
                return this;
            
            var factor = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= factor;
            Denominator /= factor;
            return this;
        }

        private ILargeInt ShiftDecimalLeft(int shift)
        {
            if (shift < 0)
                return ShiftDecimalRight(-shift);

            Numerator *= BigInteger.Pow(10, shift);
            return this;
        }

        private ILargeInt ShiftDecimalRight(int shift)
        {
            if (shift < 0)
                return ShiftDecimalLeft(-shift);
            
            Denominator *= BigInteger.Pow(10, shift);
            return this;
        }

        /*OPERATORS BLOCK*/
        
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

            return Numerator == other.Numerator && Denominator == other.Denominator;
        }
        
        public static ILargeInt operator -(LargeInt value) 
            => new LargeInt(value).Negate();

        public static ILargeInt operator -(LargeInt left, ILargeInt right) 
            => new LargeInt(left).Subtract(right);

        public static LargeInt operator --(LargeInt value) 
            => value.Decrement();

        public static ILargeInt operator +(LargeInt left, ILargeInt right) 
            => new LargeInt(left).Add(right);

        public static ILargeInt operator +(LargeInt value) 
            => new LargeInt(value).Abs();

        public static LargeInt operator ++(LargeInt value) 
            => value.Increment();

        public static ILargeInt operator %(LargeInt left, LargeInt right) 
            => new LargeInt(left).Remainder(right);

        public static ILargeInt operator *(ILargeInt left, LargeInt right) 
            => new LargeInt(left).Multiply(right);

        public static ILargeInt operator /(LargeInt left, ILargeInt right) 
            => new LargeInt(left).Divide(right);

        public static ILargeInt operator >>(LargeInt value, int shift) 
            => new LargeInt(value).ShiftDecimalRight(shift);

        public static ILargeInt operator <<(LargeInt value, int shift) 
            => new LargeInt(value).ShiftDecimalLeft(shift);

        public static ILargeInt operator ^(LargeInt left, int right) 
            => new LargeInt(left).Pow(right);

        public static ILargeInt operator ~(LargeInt value) 
            => new LargeInt(value).Inverse();

        public static bool operator !=(LargeInt left, LargeInt right) 
            => Compare(left, right) != 0;

        public static bool operator ==(LargeInt left, LargeInt right)
            => Compare(left, right) == 0;

        public static bool operator <(LargeInt left, LargeInt right) 
            => Compare(left, right) < 0;

        public static bool operator <=(LargeInt left, LargeInt right) 
            => Compare(left, right) <= 0;

        public static bool operator >(LargeInt left, LargeInt right) 
            => Compare(left, right) > 0;

        public static bool operator >=(LargeInt left, LargeInt right) 
            => Compare(left, right) >= 0;

        public static bool operator true(LargeInt value) 
            => value != 0;

        public static bool operator false(LargeInt value) 
            => value == 0;

        /*CASTS BLOCK*/
        
        public static explicit operator int(LargeInt value)
        {
            if (int.MinValue > value)
                throw new OverflowException("Value is less than System.int.MinValue.");
            if (int.MaxValue < value)
                throw new OverflowException("Value is greater than System.int.MaxValue.");

            return (int)value.Numerator / (int)value.Denominator;
        }

        public static explicit operator uint(LargeInt value)
        {
            if (uint.MinValue > value)
                throw new OverflowException("Value is less than System.uint.MinValue.");
            
            if (uint.MaxValue < value)
                throw new OverflowException("Value is greater than System.uint.MaxValue.");

            return (uint)value.Numerator / (uint)value.Denominator;
        }
        
        public static implicit operator LargeInt(byte value) 
            => new((uint)value);

        public static implicit operator LargeInt(sbyte value) 
            => new(value);

        public static implicit operator LargeInt(short value) 
            => new(value);

        public static implicit operator LargeInt(ushort value) 
            => new((uint)value);

        public static implicit operator LargeInt(int value) 
            => new(value);

        public static implicit operator LargeInt(long value) 
            => new(value);

        public static implicit operator LargeInt(uint value) 
            => new(value);

        public static implicit operator LargeInt(ulong value) 
            => new(value);

        public static implicit operator LargeInt(BigInteger value) 
            => new(value);
    }
}