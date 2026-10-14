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

        public static Dictionary<BuildingType, int> GetPriceDictionary(ConstantsController constantsController) {
            Dictionary<ConstGame, int> gameInts = constantsController.ConstantsFiles[ConstantTypes.GAME].GetGameInts(); 
            return new Dictionary<BuildingType, int> {
                [BuildingType.Bank] = gameInts[ConstGame.BankGoldCost],
                [BuildingType.CityCenter] = gameInts[ConstGame.CityCenterGoldCost],
                [BuildingType.Factory] = gameInts[ConstGame.FactoryGoldCost],
                [BuildingType.Farm] = gameInts[ConstGame.FarmGoldCost],
                [BuildingType.Hospital] = gameInts[ConstGame.HospitalGoldCost],
                [BuildingType.Laboratory] = gameInts[ConstGame.LaboratoryGoldCost],
            };
        }

    }
}
