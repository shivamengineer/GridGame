using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller {
    public abstract class AbstractConstantsManager : IConstantsManager {

        public bool ReadConstantsFromFile(string filename) {
            //If file doesn't exist return false and ResetConstants() 
            return true;
        }

        public void WriteConstantsToFile(string filename) {
            //
        }

        public abstract void ResetConstants();

        public abstract void Read(string filename);
        public abstract void Write(string filename);

    }
}
