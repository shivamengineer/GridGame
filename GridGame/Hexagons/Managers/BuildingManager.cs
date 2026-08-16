using GridGame.Constants;
using GridGame.Hexagons.StaticClasses;
using GridGame.Resources;
using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons.Managers {
    public class BuildingManager {

        public bool CityBuilt;

        public (int, int) city;
        public HashSet<(int, int)> BuildingTiles;
        public Queue<(int, int)> UnfinishedBuildingTiles;
        public HashSet<(int, int)> CanBuildTiles;

        private HexMap hexMap;

        public BuildingManager(HexMap hexMap) {
            CityBuilt = false;
            BuildingTiles = new HashSet<(int, int)>();
            UnfinishedBuildingTiles = new Queue<(int, int)>();
            CanBuildTiles = new HashSet<(int, int)>();

            this.hexMap = hexMap;
        }

        public bool AddBuilding(BuildingType buildingType, int x, int y) {
            if(!CityBuilt && buildingType == BuildingType.CityCenter) {
                CityBuilt = true;
                city = (x, y);
                CanBuildTiles = DiscoverTiles.TilesInRadius(city, BuildingLimits.BUILDING_RADIUS_FROM_CITY);
            }

            BuildingTiles.Add((x, y));

            if(hexMap.Tiles[(x, y)].IsBuilding()) {
                UnfinishedBuildingTiles.Enqueue((x, y));
            }

            return true;
        }

        public int AddProduction(int production) {
            int extra = hexMap.Tiles[(UnfinishedBuildingTiles.First())].AddProduction(production);
            if(!hexMap.Tiles[(UnfinishedBuildingTiles.First())].IsBuilding()) {
                UnfinishedBuildingTiles.Dequeue();
            }
            return extra;
        }

        public bool BuildingSomething() {
            return UnfinishedBuildingTiles.Count > 0;
        }

        public bool HasBuilding(int x, int y) {
            return BuildingTiles.Contains((x, y));
        }

        public bool InRangeOfCity(int x, int y) {
            return CanBuildTiles.Contains((x, y));
        }

    }
}
