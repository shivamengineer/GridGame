using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons.StaticClasses {
    public static class DiscoveredTiles {
        public static HashSet<(int, int)> GetTileSet(HashSet<(int, int)> landTiles) {
            Random random = new Random();
            int randomIndex = random.Next(landTiles.Count);
            (int, int) coords = landTiles.ElementAt(randomIndex);

            HashSet<(int, int)> tiles = TilesInRadius(coords, 2);

            return tiles;
        }

        public static HashSet<(int, int)> TilesInRadius((int, int) tile, int radius) {
            HashSet<(int, int)> tiles = new HashSet<(int, int)>();

            for(int i = -radius; i <= radius; i++) {
                int minY = Math.Max(-radius, -i - radius);
                int maxY = Math.Min(radius, -i + radius);

                for(int j = minY; j <= maxY; j++) {
                    tiles.Add((tile.Item1 + i, tile.Item2 + j));
                }
            }

            return tiles;
        }
    }
}
