namespace ClickerWithoutAnEngine.Core
{
    public sealed class IdleNumber : IIdleNumber
    {
        private float _number;

        public float Number
        {
            get => _number;
            
            private set
            {
                while (value > 10)
                {
                    value /= 10f;
                    Exponent++;
                }
                
                while (value < 10)
                {
                    value *= 10f;
                    Exponent--;
                }

                _number = value;
            }
        }
        
        public int Exponent { get; private set; }

        public IdleNumber(float number = 0f, int exponent = 0)
        {
            Exponent = exponent;
            Number = number;
        }

        public IdleNumber(IIdleNumber idleNumber)
        {
            Exponent = idleNumber.Exponent;
            Number = idleNumber.Number;
        }
        
        //Comparison operators
        //Greater than >
        public static bool operator >(IdleNumber n1, IdleNumber n2)
        {
            if (n1.GetScale() >= n2.GetScale())
            {
                if (n1.GetScale() == n2.GetScale())
                {
                    return n1.GetNumber() > n2.GetNumber();
                }

                return true;
            }

            return false;
        }

        public static bool operator >(IdleNumber n1, float f)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), f);
            return n1 > n2;
        }

        public static bool operator >(IdleNumber n1, int i)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), (float)i);
            return n1 > n2;
        }

        //Smaller than <
        public static bool operator <(IdleNumber n1, IdleNumber n2)
        {
            if (n1.GetScale() <= n2.GetScale())
            {
                if (n1.GetScale() == n2.GetScale())
                {
                    return n1.GetNumber() < n2.GetNumber();
                }

                return true;
            }

            return false;
        }

        public static bool operator <(IdleNumber n1, float f)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), f);
            return n1 < n2;
        }

        public static bool operator <(IdleNumber n1, int i)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), (float)i);
            return n1 < n2;
        }

        //Greater than or equal to >=
        public static bool operator >=(IdleNumber n1, IdleNumber n2)
        {
            return !(n1 < n2);
        }

        public static bool operator >=(IdleNumber n1, float f)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), f);
            return n1 >= n2;
        }

        public static bool operator >=(IdleNumber n1, int i)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), (float)i);
            return n1 >= n2;
        }

        //Smaller than or equal to <=
        public static bool operator <=(IdleNumber n1, IdleNumber n2)
        {
            return !(n1 > n2);
        }

        public static bool operator <=(IdleNumber n1, float f)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), f);
            return n1 <= n2;
        }

        public static bool operator <=(IdleNumber n1, int i)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), (float)i);
            return n1 <= n2;
        }

        //Equal to
        public static bool operator ==(IdleNumber n1, IdleNumber n2)
        {
            return n1.GetScale() == n2.GetScale() && System.Math.Abs(n1.GetNumber() - n2.GetNumber()) < float.Epsilon;
        }

        public static bool operator ==(IdleNumber n1, float f)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), f);
            return n1 == n2;
        }

        public static bool operator ==(IdleNumber n1, int i)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), (float)i);
            return n1 == n2;
        }

        //Not equal to
        public static bool operator !=(IdleNumber n1, IdleNumber n2)
        {
            return !(n1 == n2);
        }

        public static bool operator !=(IdleNumber n1, float f)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), f);
            return n1 != n2;
        }

        public static bool operator !=(IdleNumber n1, int i)
        {
            IdleNumber n2 = new IdleNumber(n1.GetDisplayResolution(), n1.GetDisplayResolution(), (float)i);
            return n1 != n2;
        }

        //Serves up a readable string
        public string GetAsString()
        {
            float tNumber = Number;
            int mille = -1 + Exponent;
            int displayCrop = 0;

            while (tNumber >= 1000f)
            {
                tNumber /= 1000f;
                mille++;
            }

            //Correction to assure total amount of digits displayed
            float tNumber2 = tNumber;
            while (tNumber2 >= 10f)
            {
                tNumber2 /= 10f;
                displayCrop++;
            }

            if (mille == -1)
                return tNumber.ToString("f" + (displayResolution - displayCrop - 1));
            else if (mille < suffixes.Length)
                return tNumber.ToString("f" + (displayResolution - displayCrop - 1)) + " " + suffixes[mille];
            else
                return tNumber.ToString("f" + (displayResolution - displayCrop - 1)) + " e" + (mille + 1) * 3;
        }
    }
}