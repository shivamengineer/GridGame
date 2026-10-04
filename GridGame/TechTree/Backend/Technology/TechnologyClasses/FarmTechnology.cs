using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology.TechnologyClasses {
    public class FarmTechnology : AbstractTechnology {

        public FarmTechnology() {
            Research = ResearchType.BUILDING;
            Building = BuildingType.Farm;
            TechType = TechnologyTypes.FARM;
        }

        public override ITechnology NewInstance() {
            return new FarmTechnology();
        }

    }
}
