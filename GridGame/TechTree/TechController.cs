using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree {
    public class TechController {

        private HashSet<ITechnology> ResearchedTech;
        private HashSet<ITechnology> ResearchableTech;

        public TechController() {
            ResearchedTech = new HashSet<ITechnology>();
            ResearchableTech = new HashSet<ITechnology>();
        }

        public bool HasTechs(HashSet<ITechnology> techs) {
            foreach(ITechnology tech in techs) {
                if(!ResearchedTech.Contains(tech)) {
                    return false;
                }
            }
            return true;
        }

    }
}
