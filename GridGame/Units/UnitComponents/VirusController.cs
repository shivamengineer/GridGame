using GridGame.Virus.BaseVirus;
using GridGame.Virus.VirusControllers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units.UnitComponents {
    public class VirusController {

        public Dictionary<VirusNames, IVirus> viruses;
        public HashSet<VirusNames> virusesImmune;
        public VirusState virusState;

        public VirusController() {
            viruses = new Dictionary<VirusNames, IVirus>();
            virusesImmune = new HashSet<VirusNames>();
            virusState = VirusState.None;
        }

        public void Update(GameTime gameTime) {
            foreach(var virus in viruses.Values) {
                if(!virus.IsRecovered()) virus.Update(gameTime);
            }
        }

    }
}
