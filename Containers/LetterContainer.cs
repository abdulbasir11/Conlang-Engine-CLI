using Language_Engine_CLI.Abstractions;
using Language_Engine_CLI.Elements;
using Language_Engine_CLI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Language_Engine_CLI.Settings.Dictionaries;

namespace Language_Engine_CLI.Containers
{
    public class LetterContainer : Container
    {
        private char containerName;
        private List<Letter> containerContents;
        private distributionModes distributionMode;
        public LetterContainer(char cn, List<Letter> cc, distributionModes dm = distributionModes.Equiprobable)
        {
            containerName = cn;
            containerContents = cc;
            distributionMode = dm;
            applyDistribution();
        }

        public char getContainerName()
        {
            return containerName;
        }

        public List<Letter> getContainerContents()
        {
            return containerContents;
        }

        public void setContainerName(char n)
        {
            containerName = n;
        }

        public void setContainerContents(List<Letter> c)
        {
            containerContents = c;
        }

        public void addLetter(Letter c)
        {
            containerContents.Add(c);
            containerContents = containerContents.Distinct().ToList();
        }

        public void addLetters(List<Letter> c)
        {
            containerContents.AddRange(c);
            containerContents = containerContents.Distinct().ToList();
        }

        public void addLetters(Letter[] c)
        {
            containerContents.AddRange(c);
            containerContents = containerContents.Distinct().ToList();
        }

        public override int getContainerSize()
        {
            return containerContents.Count;
        }

        public override distributionModes getDistributionMode()
        {
            return distributionMode;
        }

        public override void setDistributionMode(distributionModes dist)
        {
            distributionMode = dist;
            applyDistribution();
        }

        public void applyDistribution()
        {

            double[] dist = Distributions.getDistributionFromDict(getDistributionMode(), getContainerSize());

            for (int i=0; i<dist.Length; i++)
            {
                containerContents[i].setWeight(dist[i]);
            }
        }

    }
}
