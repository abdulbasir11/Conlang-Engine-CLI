using Language_Engine_CLI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Language_Engine_CLI.Settings.Dictionaries;

namespace Language_Engine_CLI.Containers
{
    public class TestContainer : Container
    {
        private int containerSize;
        private distributionModes distributionMode;

        public TestContainer(int size, distributionModes dm = distributionModes.Equiprobable)
        {
            containerSize = size;
            distributionMode = dm;
        }

        public void setContainerSize(int size)
        {
            containerSize = size;
        }
        public override int getContainerSize()
        {
            return containerSize;
        }

        public override distributionModes getDistributionMode()
        {
            return distributionMode;
        }

        public override void setDistributionMode(distributionModes dist)
        {
            distributionMode = dist;
        }
    }
}
