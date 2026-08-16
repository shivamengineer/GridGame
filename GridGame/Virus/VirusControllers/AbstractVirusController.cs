using GridGame.Units;
using GridGame.Virus.BaseVirus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.VirusControllers {
    public abstract class AbstractVirusController : IVirusController {

        public HashSet<(int, int)> infectedTiles;
        public HashSet<IUnit> infectedPeople;

        public abstract void InitialInfect();

        public abstract void Spread();

        public abstract InfectType GetInfectType();

    }
}
