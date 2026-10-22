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
using System.Diagnostics;

namespace GridGame.Constants.Interface.ConstantBlocks {
    public abstract class AbstractConstantBlock : IConstantBlock {

        public Rectangle Background { get; set; }
        public int Position { get; set; }

        public Texture2D backgroundTexture;
        public SpriteFont font;
        public Color BackgroundColor;

        public ContentLoader content;
        public ConstantsController Constants;
        public Dictionary<ConstUserInterface, int> UIInts;

        private int cameraY = 0;

        public string KeyText;
        public string ValueText;

        public string inputText;
        public bool typing = false;

        public void SetContent(ContentLoader content, ConstantsController Constants) {
            this.content = content;
            this.Constants = Constants;
            UIInts = Constants.GetUIInts();
            backgroundTexture = content.GetTexture(TextureNames.BLANK_RECTANGLE);
            font = content.GetFont(FontNames.ARIAL);
            SetRectangle();
            SetValue(Constants);
        }
        public void SetPosition(int position) {
            Position = position;
        }

        public void SetRectangle() {
            Background = new Rectangle(0, Background.Y, UIInts[ConstUserInterface.ConstBlockWidth], UIInts[ConstUserInterface.ConstBlockHeight]);
            BackgroundColor = Color.Red;
            UpdatePositionFromCamera();
        }

        private void SetBackgroundPos(int x, int y) {
            Background = new Rectangle(x, y, Background.Width, Background.Height);
        }

        public void UpdatePositionFromCamera() {
            int x = UIInts[ConstUserInterface.WindowWidth] / 2 - UIInts[ConstUserInterface.ConstBlockWidth] / 2;
            int y = (1 + Position) * UIInts[ConstUserInterface.ConstBlockSpacing] + Position * UIInts[ConstUserInterface.ConstBlockHeight] - cameraY;
            SetBackgroundPos(x, y);
        }

        public void TypeLetter(char c) {
            inputText += c;
        }

        public void DeleteLetter() {
            if(inputText.Length > 0) inputText = inputText.Substring(0, inputText.Length - 1);
        }

        public void OnClick() {
            typing = true;
            inputText = "";
        }

        public void Draw(SpriteBatch spriteBatch, int camY) {
            if(cameraY != camY) {
                cameraY = camY;
                UpdatePositionFromCamera();
            }
            string text = ValueText;
            if(typing) text = inputText;

            spriteBatch.Draw(backgroundTexture, Background, BackgroundColor);
            spriteBatch.DrawString(font, KeyText + " = " + text, new Vector2(Background.X + 10, Background.Y + 10), Color.Black);
        }

        public abstract void StopTyping();
        public abstract void SetValue(ConstantsController Constants);
        public abstract IConstantBlock NewInstance();

    }
}

