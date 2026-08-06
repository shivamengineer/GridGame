using GridGame.Constants.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Resources.ResourceClasses {
    public class Morale : AbstractResource {

        public Morale() {
            Count = StartingResources.STARTING_MORALE;
        }

        public override ResourceType GetResourceType() {
            return ResourceType.Morale;
        }

    }
}
