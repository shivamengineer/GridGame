using GridGame.Hexagons.Managers;
using GridGame.Hexagons.StaticClasses;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using GridGame.Tiles;
using GridGame.Tiles.Terrain;
using GridGame.Tiles.Terrain.TerrainClasses.RiverTerrainClasses;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public class HexMap {

        public ContentLoader Content;
        public Dictionary<(int, int), Tile> Tiles;
        public HashSet<(int, int)> DiscoveredTiles;
        public (int, int) HoveredTile;
        public HexagonMath HexMath;
        private River river;
        public HexagonMapCSVReader csvReader;

        public HexMap(ContentLoader Content, CitizenManager citizens) {
            this.Content = Content;

            Tiles = new Dictionary<(int, int), Tile>();
            csvReader = new HexagonMapCSVReader(Tiles, Content);

            DiscoveredTiles = new HashSet<(int, int)>();
            HexMath = new HexagonMath();
            river = new River(Tiles);
        }

        public void SetCitizens(CitizenManager citizens) {
            HexMath.SetCitizens(citizens);
        }

        public (int, int) Initialize() {
            csvReader.LoadHexagonMap("Map1.csv");
            SetRiverTextures();
            (int, int) StartCoords = DiscoverTiles.GetStartTile(csvReader.Land);
            DiscoveredTiles = DiscoverTiles.TilesInRadius(StartCoords, 2);
            return StartCoords;
        }

        private void SetRiverTextures() {
            foreach((int, int) coords in csvReader.Rivers) {
                TextureNames texture = river.GetTextureName(coords);
                Tiles[coords].SetRiverTexture(Content, texture);
            }
        }

        public void UpdateVision((int, int) position, int radius) {
            HashSet<(int, int)> newTiles = DiscoverTiles.TilesInRadius(position, radius);
            DiscoveredTiles.UnionWith(newTiles);
        }

        public bool HasAdjacent((int, int) position, TerrainType terrainType) {
            HashSet<(int, int)> adjacentTiles = DiscoverTiles.TilesInRadius(position, 1);
            adjacentTiles.Remove(position);
            foreach((int, int) pos in adjacentTiles) {
                if(Tiles[pos].GetTerrainType() == terrainType) return true;
            }
            return false;
        }                                                   

    }
}
