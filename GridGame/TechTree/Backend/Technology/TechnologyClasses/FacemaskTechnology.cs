using GridGame.TechTree.Backend.Technology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology.TechnologyClasses {
    public class FacemaskTechnology : AbstractTechnology {

        public FacemaskTechnology() {
            TechType = TechnologyTypes.FACEMASK;
        }

        public override ITechnology NewInstance() {
            return new FacemaskTechnology();
        }

    }
}
