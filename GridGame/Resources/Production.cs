using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Resources {
    public class Production : AbstractResource {

        public override ResourceType GetResourceType() {
            return ResourceType.Production;
        }

    }
}
