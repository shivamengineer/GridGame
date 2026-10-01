using GridGame.SafetyMeasure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.VirusProbabilities.Infect.InfectProbabilityClasses {
    public class BaseInfectProbability : AbstractInfectProbability {

        public BaseInfectProbability() {
            SafetyMeasureProbabilities = new Dictionary<SafetyMeasureType, float>() {
                [SafetyMeasureType.WASH_HANDS] = 0.95f,
                [SafetyMeasureType.WEAR_MASK] = 0.6f,
                [SafetyMeasureType.ISOLATE] = 0.7f,
            };
        }

    }
}
