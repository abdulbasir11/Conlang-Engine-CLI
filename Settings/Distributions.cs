using Language_Engine_CLI.Abstractions;
using Language_Engine_CLI.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Language_Engine_CLI.Settings.Dictionaries;

namespace Language_Engine_CLI.Settings
{
    public static class Distributions
    {

        public static double [] getDistributionFromDict(distributionModes d, int s)
        {
            switch (d)
            {
                case distributionModes.Equiprobable:
                    return getEquiprobable(s);
                case distributionModes.Harmonic:
                    return getHarmonic(s);
                case distributionModes.Geometric:
                    return getGeometric(s);
                case distributionModes.Parabolic:
                    return getParabolic(s);
                case distributionModes.Custom:
                    throw new NotImplementedException();
                default:
                    return getEquiprobable(s);
            }
        }

        public static double [] getEquiprobable(int s)
        {
            if (s == 1) { return new double[] { 1.0 }; }

            double[] distribution = new double[s];
            double fract = 1.0 / s;
            for (int i = 0; i < s; i++)
            {
                distribution[i] = fract;
            }
            return distribution;
        }

        public static double [] getHarmonic(int s)
        {
            if (s == 1) { return new double[] { 1.0 }; }

            double[] distribution = new double[s];
            for (int i = 0; i < s; i++)
            {
                distribution[i] = 1.0 / (i + 2.0);
            }

            return distribution;
        }

        public static double[] getGeometric(int s)
        {

            if (s == 1) { return new double[] { 1.0 }; }

            double[] distribution = new double[s];
            for (int i = 0; i < s; i++)
            {
                distribution[i] = 1.0 / Math.Pow(2.0, (i+1));
            }

            return distribution;
        }

        public static double[] getParabolic(int s)
        {

            if (s == 1) { return new double[] { 1.0 }; }

            double[] distribution = new double[s];
            if (s % 2 == 0)
            {
                int[] numerators = utils.pellSequence(s / 2);
                int denominator = utils.pellSum(s / 2);
                double[] back = new double[s / 2];
                double[] front = new double[s / 2];

                for (int i = 0; i < numerators.Length; i++)
                {
                    front[i] = (double) numerators[i] / denominator;
                }

                back = front.Reverse().ToArray();
                distribution = front.Concat(back).ToArray();

                return distribution;

            } else
            {
                double upperLimit = (s - 1.0 ) / 2.0;
                int index = 1;
                double sum = 0.0;
                double topValue = 0.0;
                int divisee = (int) Math.Floor(s / 2.0);
                double[] back = new double[divisee];

                for (int i = index; i < upperLimit + 1; i++)
                {
                    sum += 1.0 / Math.Pow(2.0, i);
                }

                topValue = 1.0 / (1.0 + (sum * 2.0));

                double halvedWeightRight = topValue;
                for (int i = 0; i < divisee; i++)
                {
                    halvedWeightRight /= 2.0;
                    back[i] = halvedWeightRight;

                }
                double[] front = back.Reverse().ToArray();
                front = front.Append(topValue).ToArray();
                distribution = front.Concat(back).ToArray();

            }

            return distribution;
        }

    }
}
