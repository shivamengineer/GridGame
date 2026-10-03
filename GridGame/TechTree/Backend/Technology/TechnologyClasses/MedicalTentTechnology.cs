using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology.TechnologyClasses {
    public class MedicalTentTechnology : AbstractTechnology {

        public MedicalTentTechnology() {
            Research = ResearchType.NIL;
            Building = BuildingType.NIL;
            TechType = TechnologyTypes.MEDICAL_TENT;
        }

        public override ITechnology NewInstance() {
            return new MedicalTentTechnology();
        }

    }
}
