using GridGame.Constants.Viruses.Covid;
using GridGame.Hexagons;
using GridGame.Hexagons.Managers;
using GridGame.Hexagons.StaticClasses;
using GridGame.Units.UnitClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.InfectComponents {
    public class AirborneInfect : IInfect {

        private HexagonMap hexagonMap;
        private Citizen citizen;
        private VirusNames virusName;
        private IVirus virus;

        public AirborneInfect(HexagonMap hexagonMap, Citizen citizen, IVirus virus) {
            this.hexagonMap = hexagonMap;
            this.citizen = citizen;
            this.virus = virus;
        }

        public void Spread() {
            HashSet<Citizen> citizensInRange = new HashSet<Citizen>();
            foreach(var citizen in hexagonMap.citizenManager.Citizens) {
                if(this.citizen.transform.Coords != citizen.transform.Coords
                    && !citizen.virusController.viruses.ContainsKey(virusName)) {
                    int distance = DiscoverTiles.DistanceBetweenTiles(this.citizen.transform.Coords, citizen.transform.Coords);
                    if(distance <= CovidStats.SPREAD_RANGE) citizensInRange.Add(citizen);
                }
            }
            TrySpread(citizensInRange);
        }

        private void TrySpread(HashSet<Citizen> citizens) {
            foreach(var citizen in citizens) {
                Random random = new Random();
                float spreads = (float)random.NextDouble();
                if(spreads <= CovidStats.SPREAD_CHANCE) {
                    citizen.virusController.viruses.Add(virusName, virus.NewInstance(citizen));
                }
            }
        }

    }
}
