using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller {
    public interface IConstantsFile {

        public void ReadConstants(string filename);
        public void WriteConstantsToFile(string filename);
        public void ResetConstants();

    }
}
