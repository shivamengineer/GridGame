using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.Symptoms {
    public interface ISymptom : IHealthEffect {

        public float Duration { get; set; }

    }
}
