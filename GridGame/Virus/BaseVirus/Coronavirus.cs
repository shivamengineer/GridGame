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

        private string virusID;
        private VirusNames virusName;

        public Coronavirus(HexagonMap hexagonMap, Citizen citizen, float strength, string virusID) {
            this.citizen = citizen;
            this.hexagonMap = hexagonMap;

            spreadChance = CovidStats.SPREAD_CHANCE;
            virusStrength = strength;
            limitCitizenPercent = 1f - strength;

            TimeToSpread = CovidStats.TIME_TO_SPREAD;
            BaseDuration = CovidStats.VIRUS_BASE_DURATION;
            AsymptomaticTime = BaseDuration / 3;

            this.virusID = virusID;
            virusName = VirusNames.Coronavirus;
        }


        public override void UpdateEvent() {
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

        public override void OnVirusDurationEnd() {
            Random random = new Random();
            float rand = (float)random.NextDouble();
            if(rand <= CovidStats.MORTALITY_RATE) {
                hexagonMap.citizenManager.ToRemoveCitizens.Push(citizen);
            } else {
                citizen.virusController.virusesImmune.Add(VirusNames.Coronavirus);
                recovered = true;
            }
        }

        private void TrySpread(HashSet<Citizen> citizens) {
            foreach(var citizen in citizens) {
                Random random = new Random();
                float spreads = (float)random.NextDouble();
                if(spreads <= spreadChance) {
                    citizen.virusController.viruses.Add(virusName, new Coronavirus(hexagonMap, citizen, virusStrength, virusID));
                }
            }
        }

    }
}
