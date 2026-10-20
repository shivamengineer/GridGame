using GridGame.Constants.Controller.ConstantsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.ConstantBlockClasses {
    public class UserInterfaceConstantBlock : AbstractConstantBlock {

        private ConstUserInterface ConstType;

        public UserInterfaceConstantBlock(ConstUserInterface ConstType) {
            this.ConstType = ConstType;
            SetBackground();
        }

    }
}
