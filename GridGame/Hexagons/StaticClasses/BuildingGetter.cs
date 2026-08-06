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

        public static Dictionary<BuildingType, IBuilding> GetBuildingGetter() {
            return new Dictionary<BuildingType, IBuilding> {
                [BuildingType.Bank] = new Bank(),
                [BuildingType.CityCenter] = new CityCenter(),
                [BuildingType.Empty] = new Empty(),
                [BuildingType.Factory] = new Factory(),
                [BuildingType.Farm] = new Farm(),
                [BuildingType.Hospital] = new Hospital(),
                [BuildingType.Laboratory] = new Laboratory(),
                [BuildingType.NIL] = new NIL(),
            };
        }

    }
}
