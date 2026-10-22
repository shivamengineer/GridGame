using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Hexagons.StaticClasses;
using GridGame.Tiles.Terrain.TerrainClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller {
    public abstract class AbstractConstantsManager : IConstantsManager {

        public bool ReadConstantsFromFile(string filename) {
            string path = "Content/Data/Constants/" + filename;
            if(!File.Exists(path)) {
                ResetConstants();
                return false;
            }

            using(var stream = TitleContainer.OpenStream(path))
            using(var reader = new StreamReader(stream)) {
                while(!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    var input = line.Replace(" ", "");
                    if(input == "") continue; //Skips blank lines

                    string[] values = input.Split('=');
                    Read(values[0], values[1]);
                }
            }

            return true;
        }

        public abstract void ResetConstants();

        public abstract void Read(string variable, string value);
        public abstract void WriteConstantsToFile(string filename);

        public abstract bool TrySetColor(ConstColors Color, string input);
        public abstract bool TrySetGameInt(ConstGameInt gameInt, string input);
        public abstract bool TrySetGameFloat(ConstGameFloat gameFloat, string input);
        public abstract bool TrySetUIInt(ConstUserInterface UIInt, string input);

        public abstract Dictionary<ConstColors, Color> GetColors();
        public abstract Dictionary<ConstGameInt, int> GetGameInts();
        public abstract Dictionary<ConstGameFloat, float> GetGameFloats();
        public abstract Dictionary<ConstUserInterface, int> GetUIInts();

    }
}
