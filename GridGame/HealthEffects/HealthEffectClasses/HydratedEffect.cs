using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.HealthEffectClasses {
    public class HydratedEffect : AbstractHealthEffect {

        public HydratedEffect(float strength) {
            Effect = HealthEffectType.HYDRATED;
            Strength = strength;
        }

    }
}
