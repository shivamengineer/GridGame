using GridGame.TextureLoading;
using GridGame.Tiles.Buildings.BuildingClasses;
using GridGame.Units.UnitClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public class PlayerData {

        public bool CityBuilt;
        
        public (int, int) city;
        public HashSet<(int, int)> BuildingTiles;
        public Queue<(int, int)> UnfinishedBuildingTiles;
        public bool SpentGold;

        private ContentLoader content;

        public PlayerData() {
            CityBuilt = false;
            BuildingTiles = new HashSet<(int, int)>();
            UnfinishedBuildingTiles = new Queue<(int, int)>();
            SpentGold = false;
        }

    }
}
