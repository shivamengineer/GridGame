using GridGame.HealthEffects;
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
                //ADD HEALTH IMPROVEMENTS
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
