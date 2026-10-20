using GridGame.Constants.Controller.ConstantsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.ConstantBlockClasses {
    public class GameFloatConstantBlock : AbstractConstantBlock {

        private ConstGame ConstType;

        public GameFloatConstantBlock(ConstGame ConstType) {
            this.ConstType = ConstType;
            SetBackground();
        }

    }
}
