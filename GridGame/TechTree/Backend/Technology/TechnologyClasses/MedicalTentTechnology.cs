using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology.TechnologyClasses {
    public class MedicalTentTechnology : AbstractTechnology {

        public MedicalTentTechnology() {
            TechType = TechnologyTypes.MEDICAL_TENT;
        }

        public override ITechnology NewInstance() {
            return new MedicalTentTechnology();
        }

    }
}
