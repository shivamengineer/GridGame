using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Interface.ConstantBlocks;
using GridGame.Constants.TechTreeInfo;
using GridGame.TechTree.Backend;
using GridGame.TechTree.Visual.TechnologyBlocks;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.InterfacePages {
    public abstract class AbstractConstantsInterfacePage : IConstantsInterfacePage {

        public int CameraY { get; set; }

        public ConstantTypes Type;

        public List<IConstantBlock> ConstantsBlocks;

        public ContentLoader Content;
        public ConstantsController Constants;
        public Dictionary<ConstUserInterface, int> UIInts;

        private Texture2D Background;
        private Rectangle destRect;

        private int NumBlocks;
        private int FirstBlock;
        private int LastBlock;

        public void SetContent(ContentLoader Content, ConstantsController Constants) {
            this.Content = Content;
            this.Constants = Constants;
            UIInts = Constants.GetUIInts();

            Background = Content.GetTexture(TextureNames.BLANK_RECTANGLE);
            destRect = new Rectangle(0, 0, UIInts[ConstUserInterface.WindowWidth], UIInts[ConstUserInterface.WindowHeight]);

            UpdateCamera();
        }

        public void UpdateCamera() {
            NumBlocks = (UIInts[ConstUserInterface.WindowHeight] * 5 / 4) / (UIInts[ConstUserInterface.ConstBlockHeight] + UIInts[ConstUserInterface.ConstBlockSpacing]);
            FirstBlock = CameraY / (UIInts[ConstUserInterface.ConstBlockHeight] + UIInts[ConstUserInterface.ConstBlockSpacing]);
            LastBlock = FirstBlock + NumBlocks;

            if(FirstBlock < 0) FirstBlock = 0;
            if(LastBlock >= ConstantsBlocks.Count) LastBlock = ConstantsBlocks.Count - 1;
        }

        public List<IConstantBlock> GetActiveBlocks() {
            int last = Math.Min(LastBlock + 1, ConstantsBlocks.Count - 1) - FirstBlock;
            return ConstantsBlocks.GetRange(FirstBlock, last);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Background, destRect, Color.Azure);

            for(int i = FirstBlock; i < LastBlock; i++) {
                ConstantsBlocks[i].Draw(spriteBatch, CameraY);
            }
        }

    }
}
