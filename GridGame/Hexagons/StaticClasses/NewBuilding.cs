using GridGame.TextureLoading.TextureEnums;
using GridGame.TextureLoading;
using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons.StaticClasses {
    public static class NewBuilding {

        public static IBuilding GetNewBuilding(Dictionary<BuildingType, IBuilding> buildings, BuildingType type, ContentLoader content) {
            IBuilding building = buildings[type].newInstance();
            building.SetContent(content);
            building.IsBuilding();
            return building;
        }

    }
}
