using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.HealthEffectClasses {
    public class HungryEffect : AbstractHealthEffect {

        public HungryEffect(float strength) {
            Effect = HealthEffectType.HUNGRY;
            Strength = strength;
        }

    }
}
