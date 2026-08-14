using GridGame.TextureLoading;
using GridGame.Units.UnitClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons.Managers {
    public class CitizenManager {

        public Citizen CurrentPlayer;
        public List<Citizen> Citizens;
        public HashSet<(int, int)> CitizenPositions;
        private int CurrentCitizenIndex;

        private ContentLoader content;

        private HexagonMap hexagonMap;

        public CitizenManager((int, int) StartPos, HexagonMap hexagonMap, ContentLoader content) {
            CurrentPlayer = new Citizen(StartPos.Item1, StartPos.Item2, hexagonMap);
            CurrentPlayer.SetTexture(content);
            CurrentPlayer.SetActive(true);

            Citizens = new List<Citizen>() {
                CurrentPlayer,
            };
            CurrentCitizenIndex = 0;

            CitizenPositions = new HashSet<(int, int)>();

            this.hexagonMap = hexagonMap;
            this.content = content;
        }

        public void AddCitizen(int Q, int R) {
            if(CitizenPositions.Contains((Q, R)) || CurrentPlayer.Coords == (Q, R)) return;

            Citizen citizen = new Citizen(Q, R, hexagonMap);
            citizen.SetTexture(content);

            Citizens.Add(citizen);
            CitizenPositions.Add((Q, R));
        }
                                                        
        public void ChangeCitizenRight() {
            if(CurrentPlayer.moving) return;

            CitizenPositions.Add(CurrentPlayer.Coords);
            CurrentPlayer.SetActive(false);

            CurrentCitizenIndex++;
            if(CurrentCitizenIndex > Citizens.Count - 1) {
                CurrentCitizenIndex = 0;
            }
            CurrentPlayer = Citizens[CurrentCitizenIndex];

            CitizenPositions.Remove(CurrentPlayer.Coords);
            CurrentPlayer.SetActive(true);

            hexagonMap.hexMap.HexMath.FocusCamera();
        }

        public void ChangeCitizenLeft() {
            if(CurrentPlayer.moving) return;

            CitizenPositions.Add(CurrentPlayer.Coords);
            CurrentPlayer.SetActive(false);

            CurrentCitizenIndex--;
            if(CurrentCitizenIndex < 0) {
                CurrentCitizenIndex = Citizens.Count - 1;
            }
            CurrentPlayer = Citizens[CurrentCitizenIndex];

            CitizenPositions.Remove(CurrentPlayer.Coords);
            CurrentPlayer.SetActive(true);

            hexagonMap.hexMap.HexMath.FocusCamera();
        }

    }
}
