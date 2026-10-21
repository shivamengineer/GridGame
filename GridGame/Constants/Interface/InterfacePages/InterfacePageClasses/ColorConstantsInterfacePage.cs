using GridGame.Constants.Controller;
using GridGame.Constants.Interface.ConstantBlockClasses;
using GridGame.TextureLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.InterfacePages.InterfacePageClasses {
    public class ColorConstantsInterfacePage : AbstractConstantsInterfacePage {

        public ColorConstantsInterfacePage(ContentLoader Content, ConstantsController Constants) {
            Type = ConstantTypes.COLOR;
            ConstantsBlocks = new List<IConstantBlock>();
            int i = 0;
            foreach(var constVar in Constants.GetColors()) {
                IConstantBlock block = new ColorConstantBlock(constVar.Key);
                block.SetContent(Content, Constants.GetUIInts());
                block.SetPosition(i);
                ConstantsBlocks.Add(block);
                i++;
            }
        }

    }
}
