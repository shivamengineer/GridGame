using GridGame.Virus.BaseVirus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Viruses.Covid {
    public static class CovidStats {

        public static float MIN_STRENGTH = 0.2f;
        public static float STRENGTH_RANGE = 0.5f;

        public static float VIRUS_BASE_DURATION = 26f;

        public static float VIRUS_CHANCE_TO_SURVIVE = 0.9f;
        public static float VIRUS_SURVIVE_MULTIPLIER = 0.85f;

        public static float SPREAD_CHANCE = 0.75f;
        public static int SPREAD_RANGE = 2;

        public static float TIME_TO_SPREAD = 8f;

        public static float TIME_BEFORE_OUTBREAK = 12f;

        public static float MORTALITY_RATE = 0.1f;
    }
}
