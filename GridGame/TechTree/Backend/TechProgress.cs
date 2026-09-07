using GridGame.TechTree.Backend.Technology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend {
    public class TechProgress {

        public HashSet<ITechnology> ResearchedTech;
        public HashSet<ITechnology> ResearchableTech;

        public TechProgress() {
            ResearchedTech = new HashSet<ITechnology>();
            ResearchableTech = new HashSet<ITechnology>();
        }

    }
}
