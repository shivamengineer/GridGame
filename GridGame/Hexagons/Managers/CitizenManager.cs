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

        public CitizenManager((int, int) StartPos, HexagonMap hexagonMap, ContentLoader content) {
            CurrentPlayer = new Citizen(StartPos.Item1, StartPos.Item2, hexagonMap);
            CurrentPlayer.SetTexture(content);

            Citizens = new List<Citizen>() {
                CurrentPlayer,
            };
            CurrentCitizenIndex = 0;

            CitizenPositions = new HashSet<(int, int)>();

            this.content = content;
        }

        public void AddCitizen(int Q, int R, HexagonMap hexagonMap) {
            Citizen citizen = new Citizen(Q, R, hexagonMap);
            citizen.SetTexture(content);

            Citizens.Add(citizen);
            CitizenPositions.Add((Q, R));
        }

        public void ChangeCitizenRight() {
            CitizenPositions.Add(CurrentPlayer.Coords);

            CurrentCitizenIndex++;
            if(CurrentCitizenIndex > Citizens.Count - 1) {
                CurrentCitizenIndex = 0;
            }
            CurrentPlayer = Citizens[CurrentCitizenIndex];

            CitizenPositions.Remove(CurrentPlayer.Coords);
        }

        public void ChangeCitizenLeft() {
            CitizenPositions.Add(CurrentPlayer.Coords);

            CurrentCitizenIndex--;
            if(CurrentCitizenIndex < 0) {
                CurrentCitizenIndex = Citizens.Count - 1;
            }
            CurrentPlayer = Citizens[CurrentCitizenIndex];

            CitizenPositions.Remove(CurrentPlayer.Coords);
        }

    }
}
