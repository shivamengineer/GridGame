using GridGame.Resources.ResourceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Resources {
    public class PlayerResources {

        private Dictionary<ResourceType, IResource> resources;

        public PlayerResources() {
            InitializeResources();
        }

        private void InitializeResources() {
            resources = new Dictionary<ResourceType, IResource> {
                [ResourceType.Food] = new Food(),
                [ResourceType.Gold] = new Gold(),
                [ResourceType.Production] = new Production(),
                [ResourceType.Science] = new Science(),
                [ResourceType.Morale] = new Morale(),
            };
        }

        public Dictionary<ResourceType, IResource> GetResourceCounts() {
            return resources;
        }

        public int GetResourceAmount(ResourceType resourceType) {
            return resources[resourceType].GetCount();
        }

        public void AddResource(ResourceType resource, int amount) {
            resources[resource].AddResource(amount);
        }

        public void SubtractResource(ResourceType resource, int amount) {
            resources[resource].SubtractResource(amount);
        }

    }
}
