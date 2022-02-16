using Language_Engine_CLI.Containers;
using Language_Engine_CLI.Elements;
using Language_Engine_CLI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Engine_CLI.Drivers
{
    public static class Driver{
        static void Main(string[] args)
        {
            TestContainer ts = new TestContainer(5);

            double[] test1 = Distributions.getHarmonic(ts.getContainerSize());
            double[] test2 = Distributions.getEquiprobable(ts.getContainerSize());
            double[] test3 = Distributions.getGeometric(ts.getContainerSize());
            double[] test4 = Distributions.getParabolic(ts.getContainerSize());

            
            List<double[]> tests = new List<double[]>();
            tests.AddRange(new List<double[]>() { test4 });

            foreach(double[] l in tests)
            {
                foreach (double e in l)
                {
                    Console.WriteLine(e);
                }
            }

            Letter b = new Letter('b');
            Letter c = new Letter('c');
            Letter d = new Letter('d');
            Letter t = new Letter('t');
            Letter s = new Letter('s');

            List<Letter> ll = new List<Letter>();
            ll.Add(b); ll.Add(c); ll.Add(d); ll.Add(t); ll.Add(s);

            LetterContainer lc = new LetterContainer('C', ll, Dictionaries.distributionModes.Parabolic);

            foreach (Letter l in lc.getContainerContents())
            {
                Console.WriteLine(l.getLetter().ToString() + ", " + l.getWeight());
            }

            Console.WriteLine("Parabolic Distro:");
            foreach (double n in Distributions.getParabolic(6))
            {
                Console.WriteLine(n);
            }

            Console.ReadLine();
        }
    }


}
