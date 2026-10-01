using GridGame.RecoveryMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.VirusProbabilities.AttackCitizen.AttackCitizenProbabilityClasses {
    public class BaseAttackCitizenProbability : AbstractAttackCitizenProbability {

        public BaseAttackCitizenProbability() {
            RecoveryMethodProbabilities = new Dictionary<RecoveryMethod, float>() {
                [RecoveryMethod.HYDRATION_WATER] = 0.95f,
                [RecoveryMethod.REST] = 0.8f,
            };
            ResearchedTechnologies = new HashSet<RecoveryMethod>();
        }

    }
}
