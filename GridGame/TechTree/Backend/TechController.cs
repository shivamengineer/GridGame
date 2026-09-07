using GridGame.TechTree.Backend.Technology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend {
    public class TechController {

        private HashSet<ITechnology> ResearchedTech;
        private HashSet<ITechnology> ResearchableTech;

        public TechController() {
            ResearchedTech = new HashSet<ITechnology>();
            ResearchableTech = new HashSet<ITechnology>();
        }

    }
}
