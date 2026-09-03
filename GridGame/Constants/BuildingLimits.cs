using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants {
    public static class BuildingLimits {

        public static readonly int BANK_MAX_PEOPLE = 2;
        public static readonly int CITY_CENTER_MAX_PEOPLE = 6;
        public static readonly int FACTORY_MAX_PEOPLE = 4;
        public static readonly int FARM_MAX_PEOPLE = 3;
        public static readonly int HOSPITAL_MAX_PEOPLE = 5;
        public static readonly int LABORATORY_MAX_PEOPLE = 3;
        public static readonly int EMPTY_MAX_PEOPLE = 0;
        public static readonly int NIL_MAX_PEOPLE = 1;

        public static readonly int BUILDING_RADIUS_FROM_PLAYER = 1;
        public static readonly int BUILDING_RADIUS_FROM_CITY = 3;

    }
}
