using GridGame.Virus.BaseVirus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Viruses.Covid {
    public static class CovidStats {

        public static readonly float MIN_STRENGTH = 0.2f;
        public static readonly float STRENGTH_RANGE = 0.5f;

        public static readonly float VIRUS_BASE_DURATION = 18f; //26f

        public static readonly float VIRUS_CHANCE_TO_SURVIVE = 0.9f;
        public static readonly float VIRUS_SURVIVE_MULTIPLIER = 0.85f;

        public static readonly float SPREAD_CHANCE = 0.75f;
        public static readonly int SPREAD_RANGE = 2;

        public static readonly float TIME_TO_SPREAD = 8f;

        public static readonly float TIME_BEFORE_OUTBREAK = 16f;
        public static readonly float ASYMPTOMATIC_TIME = 10f;

        public static readonly float MORTALITY_RATE = 0.1f;
    }
}
