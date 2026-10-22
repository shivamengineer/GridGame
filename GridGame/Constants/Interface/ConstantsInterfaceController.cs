using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Interface.ConstantBlocks.ConstantBlockClasses;
using GridGame.Constants.Interface.InterfacePages;
using GridGame.Constants.Interface.InterfacePages.InterfacePageClasses;
using GridGame.GameManagers;
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
        public List<ConstantTypes> PageTypes;
        public Dictionary<ConstantTypes, IConstantsInterfacePage> ConstantPages;
        public int CurrentPage;

        private DisplayManager displayManager;
        private ContentLoader Content;
        private ConstantsController Constants;

        public ConstantsInterfaceController(DisplayManager displayManager, ContentLoader Content, ConstantsController Constants) {
            this.displayManager = displayManager;
            this.Content = Content;
            this.Constants = Constants;
            CurrentPage = 0;
            Initialize();
        }

        private void Initialize() {
            PageTypes = new List<ConstantTypes>() {
                ConstantTypes.COLOR,
                ConstantTypes.GAME_INT,
                ConstantTypes.GAME_FLOAT,
                ConstantTypes.USER_INTERFACE,
            };
            ConstantPages = new Dictionary<ConstantTypes, IConstantsInterfacePage>() {
                [ConstantTypes.COLOR] = new ColorConstantsInterfacePage(Content, Constants),
                [ConstantTypes.GAME_INT] = new GameIntConstantsInterfacePage(Content, Constants),
                [ConstantTypes.GAME_FLOAT] = new GameFloatConstantsInterfacePage(Content, Constants),
                [ConstantTypes.USER_INTERFACE] = new UIIntConstantsInterfacePage(Content, Constants),
            };
        }

        public void Scroll(int y) {
            ConstantPages[PageTypes[CurrentPage]].CameraY += y;
            if(ConstantPages[PageTypes[CurrentPage]].CameraY < 0) ConstantPages[PageTypes[CurrentPage]].CameraY = 0;
            ConstantPages[PageTypes[CurrentPage]].UpdateCamera();
        }

        public IConstantsInterfacePage GetCurrentPage() {
            return ConstantPages[PageTypes[CurrentPage]];
        }

        public void SwitchPageRight() {
            if(CurrentPage < PageTypes.Count - 1) CurrentPage++;
            else CurrentPage = 0;
        }

        public void SwitchPageLeft() {
            if(CurrentPage > 0) CurrentPage--;
            else CurrentPage = PageTypes.Count - 1;
        }

        public void StopTyping() {
            GetCurrentPage().StopTyping();
            displayManager.ToggleTyping();
        }

        public void Draw(SpriteBatch spriteBatch) {
            GetCurrentPage().Draw(spriteBatch);
        }

    }
}
