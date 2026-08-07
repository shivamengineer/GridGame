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
        public Citizen Player;
        public (int, int) city;
        public HashSet<(int, int)> BuildingTiles;

        public PlayerData((int, int) StartPos, HexagonMap hexagonMap, ContentLoader content) {
            CityBuilt = false;
            Player = new Citizen(StartPos.Item1, StartPos.Item2, hexagonMap);
            Player.SetTexture(content);
            BuildingTiles = new HashSet<(int, int)>();
        }

    }
}
