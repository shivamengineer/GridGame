using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology.TechnologyClasses {
    public class SoapTechnology : AbstractTechnology {

        public SoapTechnology() {
            TechType = TechnologyTypes.SOAP;
        }

        public override ITechnology NewInstance() {
            return new SoapTechnology();
        }

    }
}
