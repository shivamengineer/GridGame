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
        public Stack<Citizen> ToRemoveCitizens;
        private int CurrentCitizenIndex;

        private ContentLoader content;

        private HexagonMap hexagonMap;

        public CitizenManager((int, int) StartPos, HexagonMap hexagonMap, ContentLoader content) {
            CurrentPlayer = new Citizen(StartPos, hexagonMap);
            CurrentPlayer.SetTexture(content);
            CurrentPlayer.SetActive(true);

            Citizens = new List<Citizen>() { CurrentPlayer };
            CitizenMap = new Dictionary<(int, int), Citizen> {
                [StartPos] = CurrentPlayer
            };
            ToRemoveCitizens = new Stack<Citizen>();

            CurrentPos = StartPos;
            CurrentCitizenIndex = 0;

            this.hexagonMap = hexagonMap;
            this.content = content;
        }

        public bool AddCitizen((int, int) pos) {
            if(CitizenMap.ContainsKey(pos)) return false;

            Citizen citizen = new Citizen(pos, hexagonMap);
            citizen.SetTexture(content);

            Citizens.Add(citizen);
            CitizenMap.Add(pos, citizen);
            return true;
        }

        public bool KillCitizen(Citizen citizen) {
            if(citizen == CurrentPlayer) ChangeCitizenRight();
            Citizens.Remove(citizen);
            CitizenMap.Remove(citizen.Coords);

            if(Citizens.Count == 0) return true; //if all citizens are dead
            return false;
        }

        public void KillCitizenAtPosition((int, int) pos) {
            Citizens.Remove(CitizenMap[pos]);
            CitizenMap.Remove(pos);
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
