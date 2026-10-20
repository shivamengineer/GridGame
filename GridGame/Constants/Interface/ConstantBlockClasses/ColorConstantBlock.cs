using GridGame.Constants.Controller.ConstantsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.ConstantBlockClasses {
    public class ColorConstantBlock : AbstractConstantBlock {

        private ConstColors ConstType;

        public ColorConstantBlock(ConstColors ConstType) {
            this.ConstType = ConstType;
        }

        public override IConstantBlock NewInstance() {
            IConstantBlock newBlock = new ColorConstantBlock(ConstType);
            newBlock.SetContent(content, UIInts);
            return newBlock;
        }

    }
}
