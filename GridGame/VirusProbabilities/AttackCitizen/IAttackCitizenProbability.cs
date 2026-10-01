using GridGame.RecoveryMethods;
using GridGame.SafetyMeasure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.VirusProbabilities.AttackCitizen {
    public interface IAttackCitizenProbability : IVirusProbability {

        public void ResearchTechnology(RecoveryMethod recoveryMethod);

    }
}
