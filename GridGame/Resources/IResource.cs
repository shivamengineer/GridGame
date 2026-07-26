using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Resources {
    public interface IResource {

        public int GetCount();

        public void AddResource(int amount);

        public void SubtractResource(int amount);

        public ResourceType GetResourceType();

    }
}
