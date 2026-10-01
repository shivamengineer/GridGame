using GridGame.RecoveryMethods;
using GridGame.SafetyMeasure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.VirusProbabilities.Infect {
    public interface IInfectProbability : IVirusProbability {

        public void ResearchTechnology(SafetyMeasureType safetyMeasure);

    }
}
