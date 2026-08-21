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

namespace GridGame.Hexagons.StaticClasses {
    public class HexagonMapCSVReader {

        private Dictionary<(int, int), Tile> map;
        private ContentLoader content;
        public HashSet<(int, int)> Land;
        public HashSet<(int, int)> Rivers;

        public HexagonMapCSVReader(Dictionary<(int, int), Tile> map, ContentLoader content) {
            this.map = map;
            this.content = content;
            Land = new HashSet<(int, int)>();
            Rivers = new HashSet<(int, int)>();
        }

        public void LoadHexagonMap(string filename) {
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
                            Tile tile = tileDictionary[values[i]].newInstance();
                            tile.SetTerrainContent(content);
                            tile.SetBuildingContent(content);
                            (int, int) adjustedCoords = HexAdjustedCoords.AdjustedPos((i, j));
                            map.Add(adjustedCoords, tile);
                            if(values[i] == "1") {
                                Land.Add(adjustedCoords);
                            }
                            if(values[i] == "3") {
                                Rivers.Add(adjustedCoords);
                            }
                        }
                    }
                    j++;
                }
            }
        }

        private Dictionary<string, Tile> GetTileDictionary() {
            Dictionary<string, Tile> tileDictionary = new Dictionary<string, Tile> {
                ["*"] = new Tile(new Ocean(), new NIL()),
                ["0"] = new Tile(new Ocean(), new NIL()),
                ["1"] = new Tile(new Land(), new NIL()),
                ["2"] = new Tile(new Coast(), new NIL()),
                ["3"] = new Tile(new Land_River(), new NIL()),
            };
            return tileDictionary;
        }

    }
}
