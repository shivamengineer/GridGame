using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Viruses.Covid;
using GridGame.Hexagons;
using GridGame.Hexagons.Managers;
using GridGame.Hexagons.StaticClasses;
using GridGame.Units.UnitClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.InfectComponents {
    public class AirborneInfect : IInfect {

        private CitizenManager citizenManager;
        private Citizen citizen;
        private VirusNames virusName;
        private IVirus virus;

        private float elapsedTime = 0f;
        private float TimeToSpread;

        private Dictionary<ConstGameInt, int> GameInts;
        private Dictionary<ConstGameFloat, float> GameFloats;

        public AirborneInfect(CitizenManager citizenManager, Citizen citizen, IVirus virus, ConstantsController Constants) {
            this.citizenManager = citizenManager;
            this.citizen = citizen;
            this.virus = virus;

            GameInts = Constants.GetGameInts();
            GameFloats = Constants.GetGameFloats();

            TimeToSpread = GameFloats[ConstGameFloat.VirusTimeBeforeSpread];
        }

        public void Spread() {
            HashSet<Citizen> citizensInRange = new HashSet<Citizen>();
            foreach(var citizen in citizenManager.Citizens) {
                if(this.citizen.transform.Coords != citizen.transform.Coords
                    && !citizen.virusController.viruses.ContainsKey(virusName)) {
                    int distance = DiscoverTiles.DistanceBetweenTiles(this.citizen.transform.Coords, citizen.transform.Coords);
                    if(distance <= GameInts[ConstGameInt.VirusSpreadRange]) citizensInRange.Add(citizen);
                }
            }
            TrySpread(citizensInRange);
        }

        private void TrySpread(HashSet<Citizen> citizens) {
            foreach(var citizen in citizens) {
                Random random = new Random();
                float spreads = (float)random.NextDouble();
                if(spreads <= GameFloats[ConstGameFloat.VirusSpreadChance]) {
                    citizen.virusController.viruses.Add(virusName, virus.NewInstance(citizen));
                }
            }
        }

        public void Update(GameTime gameTime) {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(elapsedTime >= TimeToSpread) {
                elapsedTime -= TimeToSpread;
                Spread();
            }
        }

    }
}
