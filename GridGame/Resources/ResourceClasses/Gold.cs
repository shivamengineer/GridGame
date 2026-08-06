using GridGame.Constants.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Resources.ResourceClasses {
    public class Gold : AbstractResource {

        public Gold() {
            Count = StartingResources.STARTING_GOLD;
        }

        public override ResourceType GetResourceType() {
            return ResourceType.Gold;
        }

    }
}
