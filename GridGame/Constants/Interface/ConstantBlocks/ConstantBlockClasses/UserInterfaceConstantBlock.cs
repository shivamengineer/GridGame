using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.ConstantBlocks.ConstantBlockClasses {
    public class UserInterfaceConstantBlock : AbstractConstantBlock {

        private ConstUserInterface ConstType;

        public UserInterfaceConstantBlock(ConstUserInterface ConstType) {
            this.ConstType = ConstType;
            KeyText = ConstType.ToString();
        }

        public override void SetValue(ConstantsController Constants) {
            ValueText = Constants.GetUIInts()[ConstType].ToString();
        }

        public override IConstantBlock NewInstance() {
            IConstantBlock newBlock = new UserInterfaceConstantBlock(ConstType);
            newBlock.SetContent(content, Constants);
            return newBlock;
        }

        public override void StopTyping() {
            typing = false;
        }

    }
}
