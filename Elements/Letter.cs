using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Engine_CLI.Elements
{
    public class Letter
    {
        private char letter;
        private double weight;

        public Letter(char c, double w = 0.0)
        {
            letter = c;
            weight = w;
        }

        public void setLetter(char l)
        {
            letter = l;
        }

        public void setWeight(double w)
        {
            weight = w;
        }

        public char getLetter()
        {
            return letter;
        }
        public double getWeight()
        {
            return weight;
        }
    }
}
