using GridGame.TechTree.Backend.TechnologyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend {
    public class NewTechnology {

        private Dictionary<TechnologyTypes, ITechnology> TechnologyMap;

        public NewTechnology() {
            TechnologyMap = new Dictionary<TechnologyTypes, ITechnology>() {
                [TechnologyTypes.FACEMASK] = new FacemaskTechnology(),
            };
        }

        public ITechnology GetTechnology(TechnologyTypes type) {
            return TechnologyMap[type].NewInstance();
        }

    }
}
