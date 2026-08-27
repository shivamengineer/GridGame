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

        public VirusController() {
            viruses = new Dictionary<VirusNames, IVirus>();
            virusesImmune = new HashSet<VirusNames>();
        }

        public void Update(GameTime gameTime) {
            foreach(var virus in viruses.Values) {
                if(!virus.AttackCitizen.IsRecovered()) virus.Update(gameTime);
            }
        }

    }
}
