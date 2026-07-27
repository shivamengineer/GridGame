using GridGame.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Resources.ResourceClasses {
    public class Production : AbstractResource {

        public Production() {
            Count = StartingResources.STARTING_PRODUCTION;
        }

        public override ResourceType GetResourceType() {
            return ResourceType.Production;
        }

    }
}
