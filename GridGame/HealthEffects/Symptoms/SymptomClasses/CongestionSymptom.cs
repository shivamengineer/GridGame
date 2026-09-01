using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.Symptoms.SymptomClasses {
    public class CongestionSymptom : AbstractSymptom {

        public CongestionSymptom(float strength) {
            Effect = HealthEffectType.CONGESTION;
            Strength = strength;
        }

    }
}
