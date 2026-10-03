using GridGame.TechTree.Backend.Technology;
using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology.TechnologyClasses {
    public class FacemaskTechnology : AbstractTechnology {

        public FacemaskTechnology() {
            Research = ResearchType.SAFETY_MEASURE;
            Building = BuildingType.NIL;
            TechType = TechnologyTypes.FACEMASK;
        }

        public override ITechnology NewInstance() {
            return new FacemaskTechnology();
        }

    }
}
