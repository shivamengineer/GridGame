using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.HealthEffectClasses {
    public class RestedEffect : AbstractHealthEffect {

        public RestedEffect(float strength) {
            Effect = HealthEffectType.RESTED;
            Strength = strength;
        }

    }
}
