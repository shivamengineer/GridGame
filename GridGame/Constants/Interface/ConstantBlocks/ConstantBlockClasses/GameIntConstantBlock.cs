using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.ConstantBlocks.ConstantBlockClasses {
    public class GameIntConstantBlock : AbstractConstantBlock {

        private ConstGameInt ConstType;

        public GameIntConstantBlock(ConstGameInt ConstType) {
            this.ConstType = ConstType;
            KeyText = ConstType.ToString();
        }

        public override void SetValue(ConstantsController Constants) {
            ValueText = Constants.GetGameInts()[ConstType].ToString();
        }

        public override IConstantBlock NewInstance() {
            IConstantBlock newBlock = new GameIntConstantBlock(ConstType);
            newBlock.SetContent(content, Constants);
            return newBlock;
        }

        public override void StopTyping() {
            typing = false;
            if(Constants.TrySetGameInt(ConstType, inputText)) {
                //
            }
        }

    }
}
