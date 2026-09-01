using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.Symptoms.SymptomClasses {
    public class HeadacheSymptom : AbstractSymptom {

        public HeadacheSymptom(float strength) {
            Effect = HealthEffectType.HEADACHE;
            Strength = strength;
        }

    }
}
