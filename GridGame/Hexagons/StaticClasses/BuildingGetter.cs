using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using GridGame.Tiles.Buildings;
using GridGame.Tiles.Buildings.BuildingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons.StaticClasses {
    public static class BuildingGetter {

        public static Dictionary<BuildingType, IBuilding> GetBuildingGetter(ConstantsController Constants) {
            return new Dictionary<BuildingType, IBuilding> {
                [BuildingType.Bank] = new Bank(Constants),
                [BuildingType.CityCenter] = new CityCenter(Constants),
                [BuildingType.Empty] = new Empty(Constants),
                [BuildingType.Factory] = new Factory(Constants),
                [BuildingType.Farm] = new Farm(Constants),
                [BuildingType.Hospital] = new Hospital(Constants),
                [BuildingType.Laboratory] = new Laboratory(Constants),
                [BuildingType.NIL] = new NIL(Constants),
            };
        }

    }
}
