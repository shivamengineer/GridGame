using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.Symptoms.SymptomClasses {
    public class CoughSymptom : AbstractSymptom {

        public CoughSymptom(float strength) {
            Effect = HealthEffectType.COUGH;
            Strength = strength;
        }

    }
}
