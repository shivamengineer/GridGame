using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Resources {
    public class Food : AbstractResource {

        public override ResourceType GetResourceType() {
            return ResourceType.Food;
        }

    }
}
