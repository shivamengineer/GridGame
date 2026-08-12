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

        public Citizen CurrentPlayer;
        public List<Citizen> Citizens;
        private int CurrentCitizen;
        
        public (int, int) city;
        public HashSet<(int, int)> BuildingTiles;
        public Queue<(int, int)> UnfinishedBuildingTiles;
        public bool SpentGold;

        private ContentLoader content;

        public PlayerData((int, int) StartPos, HexagonMap hexagonMap, ContentLoader content) {
            CityBuilt = false;
            CurrentPlayer = new Citizen(StartPos.Item1, StartPos.Item2, hexagonMap);
            CurrentPlayer.SetTexture(content);

            Citizens = new List<Citizen>() {
                CurrentPlayer,
            };
            CurrentCitizen = 0;

            BuildingTiles = new HashSet<(int, int)>();
            UnfinishedBuildingTiles = new Queue<(int, int)>();
            SpentGold = false;

            this.content = content;
        }

        public void AddCitizen(int Q, int R, HexagonMap hexagonMap) {
            Citizen citizen = new Citizen(Q, R, hexagonMap);
            citizen.SetTexture(content);

            Citizens.Add(citizen);
        }

        public void ChangeCitizenRight() {
            CurrentCitizen++;
            if(CurrentCitizen > Citizens.Count - 1) {
                CurrentCitizen = 0;
            }
        }

        public void ChangeCitizenLeft() {
            CurrentCitizen--;
            if(CurrentCitizen < 0) {
                CurrentCitizen = Citizens.Count - 1;
            }
        }

    }
}
