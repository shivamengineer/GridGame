using GridGame.Constants;
using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons.StaticClasses {
    public static class BuildingPrices {

        public static Dictionary<BuildingType, int> GetPriceDictionary() {
            return new Dictionary<BuildingType, int> {
                [BuildingType.Bank] = BuildingCosts.BANK_GOLD_COST,
                [BuildingType.CityCenter] = BuildingCosts.CITY_CENTER_GOLD_COST,
                [BuildingType.Factory] = BuildingCosts.FACTORY_GOLD_COST,
                [BuildingType.Farm] = BuildingCosts.FARM_GOLD_COST,
                [BuildingType.Hospital] = BuildingCosts.HOSPITAL_GOLD_COST,
                [BuildingType.Laboratory] = BuildingCosts.LABORATORY_GOLD_COST,
            };
        }

    }
}
