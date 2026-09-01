using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.Symptoms.SymptomClasses {
    public class NauseaSymptom : AbstractSymptom {

        public NauseaSymptom(float strength) {
            Effect = HealthEffectType.NAUSEA;
            Strength = strength;
        }

    }
}
