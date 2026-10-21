using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Interface.ConstantBlocks.ConstantBlockClasses;
using GridGame.Constants.Interface.InterfacePages;
using GridGame.Constants.Interface.InterfacePages.InterfacePageClasses;
using GridGame.TextureLoading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface {
    public class ConstantsInterfaceController {

        public Rectangle Background;
        public Dictionary<ConstantTypes, IConstantsInterfacePage> ConstantPages;
        public ConstantTypes CurrentPage;

        private ContentLoader Content;
        private ConstantsController Constants;

        public ConstantsInterfaceController(ContentLoader Content, ConstantsController Constants) {
            this.Content = Content;
            this.Constants = Constants;
            CurrentPage = ConstantTypes.COLOR;
            Initialize();
        }

        private void Initialize() {
            ConstantPages = new Dictionary<ConstantTypes, IConstantsInterfacePage>() {
                [ConstantTypes.COLOR] = new ColorConstantsInterfacePage(Content, Constants),
                [ConstantTypes.GAME_INT] = new GameIntConstantsInterfacePage(Content, Constants),
                [ConstantTypes.GAME_FLOAT] = new GameFloatConstantsInterfacePage(Content, Constants),
                [ConstantTypes.USER_INTERFACE] = new UIIntConstantsInterfacePage(Content, Constants),
            };
        }

        public void Scroll(int y) {
            ConstantPages[CurrentPage].CameraY += y;
            if(ConstantPages[CurrentPage].CameraY < 0) ConstantPages[CurrentPage].CameraY = 0;
            ConstantPages[CurrentPage].UpdateCamera();
        }

        public void Draw(SpriteBatch spriteBatch) {
            ConstantPages[CurrentPage].Draw(spriteBatch);
        }

    }
}
