using GridGame.RecoveryMethods;
using GridGame.SafetyMeasure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.VirusProbabilities.AttackCitizen {
    public abstract class AbstractAttackCitizenProbability : IAttackCitizenProbability {

        public float Probability = 1f;
        public Dictionary<RecoveryMethod, float> SafetyMeasureProbabilities;
        public HashSet<RecoveryMethod> ResearchedTechnologies;

        public float GetProbability() {
            return Probability;
        }

        public void ResearchTechnology(RecoveryMethod recoveryMethod) {
            if(SafetyMeasureProbabilities.ContainsKey(recoveryMethod)) {
                ResearchedTechnologies.Add(recoveryMethod);
                Probability *= SafetyMeasureProbabilities[recoveryMethod];
            }
            //UpdateProbability();
        }
        

        public void UpdateProbability() {
            Probability = 1f;
            foreach(RecoveryMethod type in ResearchedTechnologies) {
                Probability *= SafetyMeasureProbabilities[type];
            }
        }

    }
}
