using GridGame.Constants.Controller.ConstantsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller {
    public class ConstantsController {

        public List<IConstantsFile> ConstantsFiles;

        public ConstantsController() {
            ConstantsFiles = new List<IConstantsFile>();
        }

    }
}
