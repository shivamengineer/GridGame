using GridGame.Virus.BaseVirus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units.UnitComponents {
    public class VirusController {

        public Dictionary<InfectType, IVirus> viruses;
        public HashSet<VirusNames> virusesImmune;

        public VirusController() {
            viruses = new Dictionary<InfectType, IVirus>();
            virusesImmune = new HashSet<VirusNames>();
        }

    }
}
