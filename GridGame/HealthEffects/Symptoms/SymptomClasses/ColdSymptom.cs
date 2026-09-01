using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.Symptoms.SymptomClasses {
    public class ColdSymptom : AbstractSymptom {

        public ColdSymptom(float strength) {
            Effect = HealthEffectType.COLD;
            Strength = strength;
        }

    }
}
