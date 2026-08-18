using GridGame.Constants.Viruses.Covid;
using GridGame.Units;
using GridGame.Virus.BaseVirus;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.VirusControllers {
    public abstract class AbstractVirusController : IVirusController {

        public HashSet<(int, int)> infectedTiles;
        public HashSet<IUnit> infectedPeople;

        private float timeElapsed = 0f;

        public abstract void InitialInfect();

        public abstract void Spread();

        public abstract InfectType GetInfectType();

        public void Update(GameTime gameTime) {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timeElapsed >= CovidStats.TIME_BEFORE_OUTBREAK) {
                timeElapsed -= CovidStats.TIME_BEFORE_OUTBREAK;

                InitialInfect();
            }
        }

    }
}
