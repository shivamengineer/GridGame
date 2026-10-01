using GridGame.SafetyMeasure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.VirusProbabilities.Infect {
    public abstract class AbstractInfectProbability : IInfectProbability {

        public float Probability = 1f;
        public Dictionary<SafetyMeasureType, float> SafetyMeasureProbabilities;
        public HashSet<SafetyMeasureType> ResearchedTechnologies;

        public float GetProbability() {
            return Probability;
        }

        public void ResearchTechnology(SafetyMeasureType safetyMeasure) {
            if(SafetyMeasureProbabilities.ContainsKey(safetyMeasure)) {
                ResearchedTechnologies.Add(safetyMeasure);
                Probability *= SafetyMeasureProbabilities[safetyMeasure];
            }
            //UpdateProbability();
        }


        public void UpdateProbability() {
            Probability = 1f;
            foreach(SafetyMeasureType type in ResearchedTechnologies) {
                Probability *= SafetyMeasureProbabilities[type];
            }
        }

    }
}
