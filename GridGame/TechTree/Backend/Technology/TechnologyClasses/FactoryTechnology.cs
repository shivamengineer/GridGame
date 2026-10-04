using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology.TechnologyClasses {
    public class FactoryTechnology : AbstractTechnology {

        public FactoryTechnology() {
            Research = ResearchType.BUILDING;
            Building = BuildingType.Factory;
            TechType = TechnologyTypes.FACTORY;
        }

        public override ITechnology NewInstance() {
            return new FactoryTechnology();
        }

    }
}
