using GridGame.HealthEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.SafetyMeasure {
    public abstract class AbstractSafetyMeasure : ISafetyMeasure {

        public SafetyMeasureType SafetyMeasure;

        public List<IHealthEffect> IntendedHealthEffects;
        public List<IHealthEffect> SideEffects;

    }
}
