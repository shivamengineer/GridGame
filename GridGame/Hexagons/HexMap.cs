using GridGame.TextureLoading;
using GridGame.Tiles;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public struct HexMap {

        public ContentLoader Content;
        public Dictionary<(int, int), Tile> Tiles;
        public HashSet<(int, int)> DiscoveredTiles;
        public HashSet<(int, int)> LandTiles;
        public HashSet<(int, int)> BuildingTiles;
        public HexagonMath HexMath;

        public HexMap(ContentLoader Content) {
            this.Content = Content;

            Tiles = new Dictionary<(int, int), Tile>();
            DiscoveredTiles = new HashSet<(int, int)>();
            LandTiles = new HashSet<(int, int)>();
            BuildingTiles = new HashSet<(int, int)>();
            HexMath = new HexagonMath();
        }

    }
}
