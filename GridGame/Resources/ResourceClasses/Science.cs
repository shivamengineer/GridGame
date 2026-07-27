using GridGame.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Resources.ResourceClasses {
    public class Science : AbstractResource {

        public Science() {
            Count = StartingResources.STARTING_SCIENCE;
        }

        public override ResourceType GetResourceType() {
            return ResourceType.Science;
        }

    }
}
