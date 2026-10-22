using GridGame.Constants.Controller;
using GridGame.Constants.Interface.ConstantBlocks;
using GridGame.TextureLoading;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface.InterfacePages {
    public interface IConstantsInterfacePage {

        public int CameraY { get; set; }

        public void SetContent(ContentLoader Content, ConstantsController Constants);
        public void UpdateCamera();
        public List<IConstantBlock> GetActiveBlocks();
        public void TypeLetter(char c);
        public void DeleteLetter();
        public bool OnClick(int x, int y);
        public void Draw(SpriteBatch spriteBatch);

    }
}
