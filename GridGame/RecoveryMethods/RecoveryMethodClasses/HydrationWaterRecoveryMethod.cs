using GridGame.Constants.Treatment;
using GridGame.HealthEffects;
using GridGame.HealthEffects.HealthEffectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.RecoveryMethods.RecoveryMethodClasses {
    public class HydrationWaterRecoveryMethod : AbstractRecoveryMethod {

        public HydrationWaterRecoveryMethod() {
            recoveryMethod = RecoveryMethod.HYDRATION_WATER;
            IntendedHealthEffects = new List<IHealthEffect>() {
                new HydratedEffect(HealthEffectStats.HYDRATED_WATER_STRENGTH),
            };
            SideEffects = new List<IHealthEffect>() {
                //ADD SIDE EFFECTS
            };
        }

        public override bool CanPerformOtherActions() {
            return false;
        }

    }
}
