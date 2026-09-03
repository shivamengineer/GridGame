using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.HealthEffectClasses {
    public class AppetiteLossEffect : AbstractHealthEffect {

        public AppetiteLossEffect(float strength) {
            Effect = HealthEffectType.APPETITE_LOSS;
            Strength = strength;
        }

    }
}
