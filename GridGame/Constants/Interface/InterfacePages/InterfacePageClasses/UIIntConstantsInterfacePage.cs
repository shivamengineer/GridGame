using GridGame.Constants.Controller;
using GridGame.Constants.Interface.ConstantBlockClasses;
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
                block.SetContent(Content, Constants.GetUIInts());
                block.SetPosition(i);
                ConstantsBlocks.Add(block);
                i++;
            }
        }

    }
}
