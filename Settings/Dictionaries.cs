using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Engine_CLI.Settings
{
    public static class Dictionaries
    {
        public enum distributionModes {
            Equiprobable = 1,
            Harmonic = 2,
            Geometric = 3,
            Parabolic = 4,
            Custom = 5
        }
    }
}
