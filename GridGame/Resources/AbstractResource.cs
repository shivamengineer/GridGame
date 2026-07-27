using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Resources {
    public abstract class AbstractResource : IResource {

        public int Count;

        public int GetCount() {
            return Count;
        }

        public void AddResource(int amount) {
            Count += amount;
        }

        public void SubtractResource(int amount) {
            Count -= amount;
        }

        public abstract ResourceType GetResourceType();

    }
}
