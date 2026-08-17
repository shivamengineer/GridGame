using GridGame.TextureLoading;
using GridGame.Units.UnitClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons.Managers {
    public class CitizenManager {

        public Citizen CurrentPlayer;
        public (int, int) CurrentPos;
        public List<Citizen> Citizens;
        private Dictionary<(int, int), Citizen> CitizenMap;
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

            CitizenMap = new Dictionary<(int, int), Citizen> {
                [StartPos] = CurrentPlayer
            };
            CurrentPos = StartPos;

            this.hexagonMap = hexagonMap;
            this.content = content;
        }

        public void AddCitizen(int Q, int R) {
            if(CitizenMap.ContainsKey((Q, R))) return;

            Citizen citizen = new Citizen(Q, R, hexagonMap);
            citizen.SetTexture(content);

            Citizens.Add(citizen);
            CitizenMap.Add((Q, R), citizen);
        }

        public void ChangeCitizenRight() {
            if(CurrentPlayer.moving) return;

            CurrentPlayer.SetActive(false);

            CurrentCitizenIndex++;
            if(CurrentCitizenIndex > Citizens.Count - 1) {
                CurrentCitizenIndex = 0;
            }
            CurrentPlayer = Citizens[CurrentCitizenIndex];
            CurrentPos = CurrentPlayer.Coords;

            CurrentPlayer.SetActive(true);

            hexagonMap.hexMap.HexMath.FocusCamera();
        }

        public void ChangeCitizenLeft() {
            if(CurrentPlayer.moving) return;

            CurrentPlayer.SetActive(false);

            CurrentCitizenIndex--;
            if(CurrentCitizenIndex < 0) {
                CurrentCitizenIndex = Citizens.Count - 1;
            }
            CurrentPlayer = Citizens[CurrentCitizenIndex];
            CurrentPos = CurrentPlayer.Coords;

            CurrentPlayer.SetActive(true);

            hexagonMap.hexMap.HexMath.FocusCamera();
        }

        public bool HasOtherCitizenAtPos((int, int) pos) {
            return pos != CurrentPos && CitizenMap.ContainsKey(pos);
        }

        public void UpdatePos() {
            CitizenMap[CurrentPlayer.Coords] = CurrentPlayer;
            CitizenMap.Remove(CurrentPos);
            CurrentPos = CurrentPlayer.Coords;
        }

    }
}
