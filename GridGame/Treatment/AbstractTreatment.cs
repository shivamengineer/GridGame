using GridGame.Recovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Treatment {
    public abstract class AbstractTreatment : ITreatment {

        public TreatmentType Treatment;

        public List<IRecoveryMethod> recoveryMethods;

        public TreatmentType GetTreatmentType() {
            return Treatment;
        }

    }
}
