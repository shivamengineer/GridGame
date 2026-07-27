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
            resources = new Dictionary<ResourceType, IResource>();
            resources.Add(ResourceType.Food, new Food());
            resources.Add(ResourceType.Gold, new Gold());
            resources.Add(ResourceType.Production, new Production());
            resources.Add(ResourceType.Science, new Science());
            resources.Add(ResourceType.Morale, new Morale());
        }

    }
}
