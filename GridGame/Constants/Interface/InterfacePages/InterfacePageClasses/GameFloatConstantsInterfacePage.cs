using GridGame.Constants.Controller;
using GridGame.Constants.Interface.ConstantBlockClasses;
using GridGame.TextureLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.InterfacePages.InterfacePageClasses {
    public class GameFloatConstantsInterfacePage : AbstractConstantsInterfacePage {

        public GameFloatConstantsInterfacePage(ContentLoader Content, ConstantsController Constants) {
            Type = ConstantTypes.GAME_FLOAT;
            ConstantsBlocks = new List<IConstantBlock>();
            int i = 0;
            foreach(var constVar in Constants.GetGameFloats()) {
                IConstantBlock block = new GameFloatConstantBlock(constVar.Key);
                block.SetContent(Content, Constants.GetUIInts());
                block.SetPosition(i);
                ConstantsBlocks.Add(block);
                i++;
            }
        }

    }
}
