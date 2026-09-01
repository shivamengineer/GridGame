using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.Symptoms.SymptomClasses {
    public class FeverSymptom : AbstractSymptom {

        public FeverSymptom(float strength) {
            Effect = HealthEffectType.FEVER;
            Strength = strength;
        }

    }
}
