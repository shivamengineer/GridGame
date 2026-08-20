using GridGame.Hexagons.Managers;
using GridGame.Hexagons.StaticClasses;
using GridGame.TextureLoading;
using GridGame.Tiles;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public struct HexMap {

        public ContentLoader Content;
        public Dictionary<(int, int), Tile> Tiles;
        public HashSet<(int, int)> DiscoveredTiles;
        public HashSet<(int, int)> LandTiles;
        public HashSet<(int, int)> RiverTiles;
        public (int, int) HoveredTile;
        public HexagonMath HexMath;

        public HexMap(ContentLoader Content, CitizenManager citizens) {
            this.Content = Content;

            Tiles = new Dictionary<(int, int), Tile>();
            DiscoveredTiles = new HashSet<(int, int)>();
            LandTiles = new HashSet<(int, int)>();
            RiverTiles = new HashSet<(int, int)>();
            HexMath = new HexagonMath();
        }

        public void SetCitizens(CitizenManager citizens) {
            HexMath.SetCitizens(citizens);
        }

        public (int, int) Initialize() {
            var twoSets = HexagonMapCSVReader.LoadHexagonMap(Tiles, Content, "Map1.csv");
            LandTiles = twoSets.Item1;
            RiverTiles = twoSets.Item2;
            SetRiverTextures();
            (int, int) StartCoords = DiscoverTiles.GetStartTile(LandTiles);
            DiscoveredTiles = DiscoverTiles.TilesInRadius(StartCoords, 2);
            return StartCoords;
        }

        private void SetRiverTextures() {
            foreach((int, int) coord in RiverTiles) {
                //SET RIVER TILE
            }
        }

        public void UpdateVision((int, int) position, int radius) {
            HashSet<(int, int)> newTiles = DiscoverTiles.TilesInRadius(position, radius);
            DiscoveredTiles.UnionWith(newTiles);
        }

    }
}
