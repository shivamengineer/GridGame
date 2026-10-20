using GridGame.Constants.Controller.ConstantsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.ConstantBlockClasses {
    public class GameIntConstantBlock : AbstractConstantBlock {

        private ConstGame ConstType;

        public GameIntConstantBlock(ConstGame ConstType) {
            this.ConstType = ConstType;
        }

        public override IConstantBlock NewInstance() {
            IConstantBlock newBlock = new GameIntConstantBlock(ConstType);
            newBlock.SetContent(content, UIInts);
            return newBlock;
        }

    }
}
