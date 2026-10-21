using GridGame.Constants.Controller;
using GridGame.TextureLoading;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.InterfacePages {
    public abstract class AbstractConstantsInterfacePage : IConstantsInterfacePage {

        public List<IConstantBlock> ConstantsBlocks;

        public ContentLoader Content;
        public ConstantsController Constants;

        public ConstantTypes Type;

        public void SetContent(ContentLoader Content, ConstantsController Constants) {
            this.Content = Content;
            this.Constants = Constants;
        }

        public void Draw(SpriteBatch spriteBatch, int cameraY) {
            //
        }

    }
}
