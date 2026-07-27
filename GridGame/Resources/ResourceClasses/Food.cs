using GridGame.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Resources.ResourceClasses {
    public class Food : AbstractResource {

        public Food() {
            Count = StartingResources.STARTING_FOOD;
        }

        public override ResourceType GetResourceType() {
            return ResourceType.Food;
        }

    }
}
