using GridGame.Hexagons;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Terrain.TerrainClasses.RiverTerrainClasses {
    public class River {

        Dictionary<(int, int), Tile> tiles;
        private Dictionary<string, TextureNames> GetRiverType;
        private string id;

        public River(Dictionary<(int, int), Tile> tiles) {
            this.tiles = tiles;
            InitializeDictionary();
        }

        public TextureNames GetTextureName((int, int) coords) {
            id = "";

            int x = coords.Item1;
            int y = coords.Item2;

            (int, int)[] adjacent =
            [
                (x, y - 1), //above
                (x + 1, y - 1), //up right
                (x + 1, y), //down right
                (x, y + 1), //down
                (x - 1, y + 1), //down left
                (x - 1, y), //up left
            ];

            int first = -1;
            bool second = false;

            for(int i = 0; i < adjacent.Length; i++) {
                if(HasWater(adjacent[i])) {
                    if(first == -1) {
                        first = i;
                        if(i != 0) {
                            id += i;
                        }
                    } else if(!second){
                        second = true;
                        id += i - first;
                    }
                }   
            }

            if(!second) id = "3";

            return GetRiverType[id];
        }

        private bool HasWater((int, int) coords) {
            if(!tiles.ContainsKey(coords)) return false;
            if(tiles[coords].GetTerrainType() == TerrainType.Ocean 
                || tiles[coords].GetTerrainType() == TerrainType.Land_River) return true;
            return false;
        }

        private void InitializeDictionary() {
            GetRiverType = new Dictionary<string, TextureNames>() {
                ["1"] = TextureNames.RIVER_1,
                ["2"] = TextureNames.RIVER_2,
                ["3"] = TextureNames.RIVER_3,
                ["4"] = TextureNames.RIVER_4,
                ["5"] = TextureNames.RIVER_5,

                ["11"] = TextureNames.RIVER_11,
                ["12"] = TextureNames.RIVER_12,
                ["13"] = TextureNames.RIVER_13,
                ["14"] = TextureNames.RIVER_14,

                ["21"] = TextureNames.RIVER_21,
                ["22"] = TextureNames.RIVER_22,
                ["23"] = TextureNames.RIVER_23,

                ["31"] = TextureNames.RIVER_31,
                ["32"] = TextureNames.RIVER_32,

                ["41"] = TextureNames.RIVER_41,
            };
        }

    }
}
