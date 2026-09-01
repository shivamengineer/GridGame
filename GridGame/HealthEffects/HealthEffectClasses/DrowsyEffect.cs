using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.HealthEffects.HealthEffectClasses {
    public class DrowsyEffect : AbstractHealthEffect {

        public DrowsyEffect(float strength) {
            Effect = HealthEffectType.DROWSY;
            Strength = strength;
        }

    }
}
