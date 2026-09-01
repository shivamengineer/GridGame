using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.HealthEffectClasses {
    public class ReduceHungerEffect : AbstractHealthEffect {

        public ReduceHungerEffect(float strength) {
            Effect = HealthEffectType.REDUCE_HUNGER;
            Strength = strength;
        }

    }
}
