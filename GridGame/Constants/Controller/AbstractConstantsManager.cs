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
                    if(line == "") continue; //Skips blank lines

                    string[] values = line.Split('=');
                    Read(values[0], values[1]);
                }
            }

            return true;
        }

        public void WriteConstantsToFile(string filename) {
            //
        }

        public abstract void ResetConstants();

        public abstract void Read(string variable, string value);
        public abstract void Write(string filename);

    }
}
