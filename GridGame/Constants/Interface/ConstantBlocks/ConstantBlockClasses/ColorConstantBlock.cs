using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.ConstantBlocks.ConstantBlockClasses {
    public class ColorConstantBlock : AbstractConstantBlock {

        private ConstColors ConstType;

        public ColorConstantBlock(ConstColors ConstType) {
            this.ConstType = ConstType;
            KeyText = ConstType.ToString();
        }

        public override void SetValue(ConstantsController Constants) {
            ValueText = Constants.GetColors()[ConstType].ToString();
        }

        public override IConstantBlock NewInstance() {
            IConstantBlock newBlock = new ColorConstantBlock(ConstType);
            newBlock.SetContent(content, Constants);
            return newBlock;
        }

        public override void StopTyping() {
            typing = false;
        }

    }
}
