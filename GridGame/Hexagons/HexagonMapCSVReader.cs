using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using GridGame.Tiles;
using GridGame.Tiles.Buildings.BuildingClasses;
using GridGame.Tiles.Terrain.TerrainClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public static class HexagonMapCSVReader {

        public static void LoadHexagonMap(Dictionary<(int, int), Tile> map, ContentLoader content, string filename) {
            Dictionary<string, Tile> tileDictionary = GetTileDictionary();

            string path = "Content/Data/" + filename;
            using(var stream = TitleContainer.OpenStream(path))
            using(var reader = new StreamReader(stream)) {
                int j = 0;
                while(!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    string[] values = line.Split(',');
                    for(int i = 0; i < values.Length; i++) {
                        if(values[i] == "|") {
                            break;
                        }
                        if(values[i] != "") {
                            Tile tile = tileDictionary[values[i]];
                            tile.SetTerrainTextures(content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER), content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND));
                            tile.SetBuildingTextures(content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER), content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND));
                            map.Add(AdjustedPos((i, j)), tile);
                        }
                    }
                    j++;
                }
            }
        }

        private static Dictionary<string, Tile> GetTileDictionary() {
            Dictionary<string, Tile> tileDictionary = new Dictionary<string, Tile> {
                ["*"] = new Tile(new Ocean(), new NIL()),
                ["0"] = new Tile(new Ocean(), new NIL()),
                ["1"] = new Tile(new Land(), new NIL()),
                ["2"] = new Tile(new Coast(), new NIL()),
                ["3"] = new Tile(new Land_River(), new NIL()),
            };
            return tileDictionary;
        }

        private static (int, int) AdjustedPos((int, int) pos) {
            int x;

            if(pos.Item1 % 2 == 0) {
                x = pos.Item1 / 2;
            } else {
                x = (pos.Item1 + 1) / 2;
            }

            return (pos.Item1, pos.Item2 - x);
        }

    }
}
