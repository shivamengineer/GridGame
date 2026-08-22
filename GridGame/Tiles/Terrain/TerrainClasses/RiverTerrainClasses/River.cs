using GridGame.Hexagons;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
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

            HashSet<int> Rivers = new HashSet<int>();
            HashSet<int> Oceans = new HashSet<int>();

            for(int i = 0; i < adjacent.Length; i++) {
                if(HasRiver(adjacent[i])) {
                    Rivers.Add(i);
                } else if(HasOcean(adjacent[i])) {
                    Oceans.Add(i);
                }   
            }

            id = setID(Rivers, Oceans);

            return GetRiverType[id];
        }

        private string setID(HashSet<int> rivers, HashSet<int> oceans) {
            Random random = new Random();

            string id = "";
            (int, int) idInts = (-1, -1);
            int riverPoint = -1;

            int addedRivers = 0;

            if(rivers.Count > 1) {
                idInts = GetTwoRandom(rivers, random);
                addedRivers += 2;
            } else if(rivers.Count > 0) {
                riverPoint = rivers.First();
                addedRivers++;
            }                    
            if(addedRivers < 2 && oceans.Count > 0) {
                if(addedRivers == 0 && oceans.Count == 1) {
                    return id + oceans.First(); //IF ONLY CONNECTED AT ONE POINT
                } else if(addedRivers == 0) {
                    idInts = GetTwoRandom(oceans, random);
                    addedRivers += 2;
                } else if(addedRivers == 1 && oceans.Count == 1) {
                    idInts = GetAscendingOrder(riverPoint, oceans.First());
                    addedRivers++;
                } else if(addedRivers == 1) {
                    idInts = GetAscendingOrder(riverPoint, oceans.ElementAt(random.Next(oceans.Count)));
                    addedRivers++;
                }
            }
            if(addedRivers < 2) {
                Debug.WriteLine("DEFAULT");
                return "3"; //default
            }

            if(idInts.Item1 != 0) id += idInts.Item1;
            id += (idInts.Item2 - idInts.Item1);

            return id;
        }

        private bool HasOcean((int, int) coords) {
            if(!tiles.ContainsKey(coords)) return false;
            if(tiles[coords].GetTerrainType() == TerrainType.Ocean) return true;
            return false;
        }

        private bool HasRiver((int, int) coords) {
            if(!tiles.ContainsKey(coords)) return false;
            if(tiles[coords].GetTerrainType() == TerrainType.Land_River) return true;
            return false;
        }

        private (int, int) GetTwoRandom(HashSet<int> set, Random random) {
            int rand = set.ElementAt(random.Next(set.Count));
            set.Remove(rand);
            int rand2 = set.ElementAt(random.Next(set.Count));
            set.Remove(rand);

            if(rand < rand2) return (rand, rand2);
            else return (rand2, rand);
        }

        private (int, int) GetAscendingOrder(int x, int y) {
            if(x < y) return (x, y);
            return (y, x);
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
