using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.Symptoms {
    public abstract class AbstractSymptom : ISymptom {

        public HealthEffectType Effect { get; set; }

        public float Strength { get; set; }

        public float Duration { get; set; }

    }
}
