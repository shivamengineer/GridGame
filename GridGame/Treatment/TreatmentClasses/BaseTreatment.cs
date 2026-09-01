using GridGame.Recovery;
using GridGame.RecoveryMethods.RecoveryMethodClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Treatment.TreatmentClasses {
    public class BaseTreatment : AbstractTreatment {

        public BaseTreatment() {
            Treatment = TreatmentType.BASE;
            recoveryMethods = new List<IRecoveryMethod>() {
                new RestRecoveryMethod(),
                new HydrationWaterRecoveryMethod()
            };
        }

    }
}
