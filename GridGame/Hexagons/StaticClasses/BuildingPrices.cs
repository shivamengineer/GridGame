using GridGame.Constants;
using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons.StaticClasses {
    public static class BuildingPrices {

        public static Dictionary<BuildingType, int> GetPriceDictionary(ConstantsController Constants) {
            Dictionary<ConstGameInt, int> gameInts = Constants.GetGameInts(); 
            return new Dictionary<BuildingType, int> {
                [BuildingType.Bank] = gameInts[ConstGameInt.BankGoldCost],
                [BuildingType.CityCenter] = gameInts[ConstGameInt.CityCenterGoldCost],
                [BuildingType.Factory] = gameInts[ConstGameInt.FactoryGoldCost],
                [BuildingType.Farm] = gameInts[ConstGameInt.FarmGoldCost],
                [BuildingType.Hospital] = gameInts[ConstGameInt.HospitalGoldCost],
                [BuildingType.Laboratory] = gameInts[ConstGameInt.LaboratoryGoldCost],
            };
        }

    }
}
