using GridGame.Constants.Controller.ConstantsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.ConstantBlockClasses {
    public class GameFloatConstantBlock : AbstractConstantBlock {

        private ConstGameFloat ConstType;

        public GameFloatConstantBlock(ConstGameFloat ConstType) {
            this.ConstType = ConstType;
        }

        public override IConstantBlock NewInstance() {
            IConstantBlock newBlock = new GameFloatConstantBlock(ConstType);
            newBlock.SetContent(content, UIInts);
            return newBlock;
        }

    }
}
