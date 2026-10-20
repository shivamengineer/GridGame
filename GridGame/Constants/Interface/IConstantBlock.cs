using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Resources;
using GridGame.TextureLoading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface {
    public interface IConstantBlock {

        public Rectangle Background { get; protected set; }
        public int Position { get; protected set; }

        public void SetContent(ContentLoader content, Dictionary<ConstUserInterface, int> UIInts);
        public void SetPosition(int position);
        public void OnClick();
        public void Draw(SpriteBatch spriteBatch, int camY);
        public IConstantBlock NewInstance();

    }
}
