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
    public class ColorConstantsInterfacePage : AbstractConstantsInterfacePage {

        public ColorConstantsInterfacePage(ContentLoader Content, ConstantsController Constants) {
            Type = ConstantTypes.COLOR;
            ConstantsBlocks = new List<IConstantBlock>();
            int i = 0;
            foreach(var constVar in Constants.GetColors()) {
                IConstantBlock block = new ColorConstantBlock(constVar.Key);
                block.SetPosition(i);
                block.SetContent(Content, Constants);
                ConstantsBlocks.Add(block);
                i++;
            }
            SetContent(Content, Constants);
        }

    }
}
