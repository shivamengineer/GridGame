using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Resources;
using GridGame.TechTree.Backend.Technology;
using GridGame.TechTree.Backend;
using GridGame.TextureLoading.TextureEnums;
using GridGame.TextureLoading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridGame.Tiles.Terrain.TerrainClasses;
using static System.Net.Mime.MediaTypeNames;

namespace GridGame.Constants.Interface {
    public abstract class AbstractConstantBlock : IConstantBlock {

        public Rectangle Background { get; set; }
        public int Position { get; set; }

        public Texture2D backgroundTexture;
        public SpriteFont font;
        public Color BackgroundColor;

        public ContentLoader content;
        public Dictionary<ConstUserInterface, int> UIInts;

        private int cameraY = 0;

        public string Text;

        public void SetContent(ContentLoader content, Dictionary<ConstUserInterface, int> UIInts) {
            this.content = content;
            this.UIInts = UIInts;
            backgroundTexture = content.GetTexture(TextureNames.BLANK_RECTANGLE);
            font = content.GetFont(FontNames.ARIAL);
            SetRectangle();
        }
        public void SetPosition(int position) {
            Position = position;
        }

        public void SetRectangle() {
            Background = new Rectangle(0, Background.Y, UIInts[ConstUserInterface.ConstBlockWidth], UIInts[ConstUserInterface.ConstBlockHeight]);
            UpdatePositionFromCamera();
        }

        private void SetBackgroundPos(int x, int y) {
            Background = new Rectangle(x, y, Background.Width, Background.Height);
        }

        public void UpdatePositionFromCamera() {
            int x = (UIInts[ConstUserInterface.WindowWidth] / 2) - (UIInts[ConstUserInterface.ConstBlockWidth] / 2);
            int y = ((1 + Position) * UIInts[ConstUserInterface.ConstBlockSpacing]) + (Position * UIInts[ConstUserInterface.ConstBlockHeight]) - cameraY;
            SetBackgroundPos(x, y);
        }

        public void OnClick() {
            //
        }

        public void Draw(SpriteBatch spriteBatch, int camY) {
            if(cameraY != camY) {
                cameraY = camY;
                UpdatePositionFromCamera();
            }

            spriteBatch.Draw(backgroundTexture, Background, BackgroundColor);
            spriteBatch.DrawString(font, Text, new Vector2(Background.X + 10, Background.Y + 10), Color.Red);
        }

        public abstract IConstantBlock NewInstance();

    }
}

