using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology.TechnologyClasses {
    public class HospitalTechnology : AbstractTechnology {

        public HospitalTechnology() {
            TechType = TechnologyTypes.HOSPITAL;
        }

        public override ITechnology NewInstance() {
            return new HospitalTechnology();
        }

    }
}
