using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Language_Engine_CLI.Settings.Dictionaries;

namespace Language_Engine_CLI.Abstractions
{
    public abstract class Container
    {
        public abstract int getContainerSize();
        public abstract distributionModes getDistributionMode();
        public abstract void setDistributionMode(distributionModes mode);

    }
}
