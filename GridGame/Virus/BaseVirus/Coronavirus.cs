using GridGame.Constants.Viruses.Covid;
using GridGame.Hexagons;
using GridGame.Hexagons.Managers;
using GridGame.Hexagons.StaticClasses;
using GridGame.Units.UnitClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus {
    public class Coronavirus : AbstractVirus {

        private Citizen citizen;
        private HexagonMap hexagonMap;

        private float spreadChance;
        public float strength;


        public Coronavirus(HexagonMap hexagonMap, Citizen citizen, float strength) {
            this.citizen = citizen;
            this.hexagonMap = hexagonMap;

            spreadChance = CovidStats.SPREAD_CHANCE;
            this.strength = strength;
            limitCitizenPercent = 1f - strength;
        }


        public override void UpdateEvent(GameTime gameTime) {
            HashSet<Citizen> citizensInRange = new HashSet<Citizen>();
            foreach(var citizen in hexagonMap.citizenManager.Citizens) {
                if(this.citizen.Coords != citizen.Coords && !citizen.viruses.ContainsKey(InfectType.CITIZEN_INFECT)) {
                    int distance = DiscoverTiles.DistanceBetweenTiles(this.citizen.Coords, citizen.Coords);
                    if(distance <= CovidStats.SPREAD_RANGE) citizensInRange.Add(citizen);
                }
            }
            TrySpread(citizensInRange);
        }

        private void TrySpread(HashSet<Citizen> citizens) {
            foreach(var citizen in citizens) {
                Random random = new Random();
                float spreads = (float)random.NextDouble();
                if(spreads <= spreadChance) {
                    citizen.viruses.Add(InfectType.CITIZEN_INFECT, new Coronavirus(hexagonMap, citizen, strength));
                }
            }
        }

    }
}
