using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Engine_CLI
{
    public static class utils
    {

        //return a random number within a range
        private static Random random;
        private static void Init()
        {
            if (random == null) random = new Random();
        }

        public static int getRandomInt(int min, int max)
        {
            Init();
            return random.Next(min, max);
        }

        //return a uniformally distributed variable
        public static double getRandomDouble()
        {
            Init();
            return random.NextDouble();
        }

        public static double getRandomDouble(double min, double max)
        {
            Init();
            return random.NextDouble() * (max - min) + min;
        }

        //Return a float between 0 and 1, assuming min <= input <= max
        public static double normalize(double input, double min, double max)
        {
            return (input - min) / (max - min);
        }

        //More specifically, undoes minmax scaling for fractional values

        //again, this only "undoes" values that are between 0 and 1.
        //giving this a number outside of that range will yield garbage.
        //see utils.rescale is that is what you want to do
        public static double inverseNormalize(double input, double min, double max)
        {
            return ((max - min) * input) + min;
        }

        //for non-fractional values that you want to normalize, this changes the range while maintaining the ratio.
        //it is not necessary for fractional values because they are inherently between 0 and 1. see utils.inverseNormalize
        public static double rescale(double input, (double oldMin, double oldMax) oldRange, (double newMin, double newMax) newRange)
        {
            return (((input - oldRange.oldMin) * (newRange.newMax - newRange.newMin)) / (oldRange.oldMax - oldRange.oldMin)) + newRange.newMin;
        }



        //Given an upper bound and an array of weights for each probability, selects a biased random number within the range
        public static int generateInverseDistro(int factorsUpperBound, double[] orderedWeights)
        {
            bool valueSelected = false;
            double uniformValue;

            if (factorsUpperBound != orderedWeights.Length)
            {
                throw new System.Exception("Upper bound and weights must match.");
            }

            while (!(valueSelected))
            {
                //uniformValue = getRandomDouble();
                for (int i = 1; i < factorsUpperBound + 1; i++)
                {
                    uniformValue = getRandomDouble();
                    if (uniformValue <= orderedWeights[i - 1])
                    {
                        return i;
                    }
                }
            }

            //error!
            return 0;

        }

        //C# doesn't have a built in clamp method lol
        public static T Clamp<T>(T value, T min, T max)
            where T : System.IComparable<T>
        {
            T result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
        }

        public static double Average(this int[] arr)
        {
            if (arr.Length > 0)
            {
                int sum = 0;
                foreach (int i in arr)
                {
                    sum += i;
                }
                return (double)sum / arr.Length;
            }
            else
            {
                return 0;
            }
        }

        public static double Average(this double[] arr)
        {
            if (arr.Length > 0)
            {
                double sum = 0;
                foreach (double i in arr)
                {
                    sum += i;
                }
                return sum / arr.Length;
            }
            else
            {
                return 0.0;
            }
        }

        public static int Sum(this int[] arr)
        {
            if (arr.Length > 0)
            {
                int sum = 0;
                foreach (int i in arr)
                {
                    sum += i;
                }
                return sum;
            }
            else
            {
                return 0;
            }
        }

        public static double Sum(this double[] arr)
        {
            if (arr.Length > 0)
            {
                double sum = 0;
                foreach (double i in arr)
                {
                    sum += i;
                }
                return sum;
            }
            else
            {
                return 0.0;
            }
        }

        //fun boolean magic
        //works with everything that is comparable (int, double, char, etc)
        //but only intended for numbers!
        public static bool Between<T>(this T num, T lower, T upper, bool inclusive) where T : System.IComparable<T>
        {
            return inclusive
                ? lower.CompareTo(num) <= 0 && upper.CompareTo(num) >= 0
                : lower.CompareTo(num) < 0 && upper.CompareTo(num) > 0;

        }

        //don't ask why, but Pell numbers reared their head!
        //returns nth pell digit
        public static int pell(int n)
        {
            if (n <= 2)
                return n;
            int a = 1;
            int b = 2;
            int c;
            for (int i = 3; i <= n; i++)
            {
                c = 2 * b + a;
                a = b;
                b = c;
            }
            return b;
        }

        //returns array of pell digits up to n
        public static int[] pellSequence(int n)
        {
            int[] sequence = new int[n];

            for (int i = 0; i < n; i++)
            {
                sequence[i] = pell(i + 1);
            }

            return sequence;
        }

        //returns sum of pell digits up to n
        //and multiplies it by two 
        public static int pellSum(int n)
        {

            return (Sum(pellSequence(n)) * 2);
        }

    }
}
