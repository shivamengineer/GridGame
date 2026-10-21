using GridGame.Constants.Controller;
using GridGame.Constants.Interface.ConstantBlocks.ConstantBlockClasses;
using GridGame.Constants.Interface.ConstantBlocks;
using GridGame.TextureLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.InterfacePages.InterfacePageClasses {
    public class UIIntConstantsInterfacePage : AbstractConstantsInterfacePage {

        public UIIntConstantsInterfacePage(ContentLoader Content, ConstantsController Constants) {
            Type = ConstantTypes.USER_INTERFACE;
            ConstantsBlocks = new List<IConstantBlock>();
            int i = 0;
            foreach(var constVar in Constants.GetUIInts()) {
                IConstantBlock block = new UserInterfaceConstantBlock(constVar.Key);
                block.SetPosition(i);
                block.SetContent(Content, Constants);
                ConstantsBlocks.Add(block);
                i++;
            }
            SetContent(Content, Constants);
        }

    }
}
