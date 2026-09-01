using GridGame.Constants.Treatment;
using GridGame.HealthEffects;
using GridGame.HealthEffects.HealthEffectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.RecoveryMethods.RecoveryMethodClasses {
    public class RestRecoveryMethod : AbstractRecoveryMethod {

        public RestRecoveryMethod() {
            recoveryMethod = RecoveryMethod.REST;
            IntendedHealthEffects = new List<IHealthEffect>() {
                new RestedEffect(HealthEffectStats.RESTED_STRENGTH),
            };
            SideEffects = new List<IHealthEffect>() {
                new DrowsyEffect(HealthEffectStats.DROWSY_STRENGTH),
            };
        }

        public override bool CanPerformOtherActions() {
            return false;
        }

    }
}
