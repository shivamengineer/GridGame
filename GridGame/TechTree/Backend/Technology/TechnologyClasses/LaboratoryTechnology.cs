using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology.TechnologyClasses {
    public class LaboratoryTechnology : AbstractTechnology {

        public LaboratoryTechnology() {
            Research = ResearchType.BUILDING;
            Building = BuildingType.Laboratory;
            TechType = TechnologyTypes.LABORATORY;
        }

        public override ITechnology NewInstance() {
            return new LaboratoryTechnology();
        }

    }
}
