using GridGame.TextureLoading.TextureEnums;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TextureLoading {
    public class ContentLoader {

        private Dictionary<TextureNames, Texture2D> textures;
        private Dictionary<FontNames, SpriteFont> fonts;

        private ContentManager Content;

        public ContentLoader(ContentManager Content) {
            textures = new Dictionary<TextureNames, Texture2D>();
            fonts = new Dictionary<FontNames, SpriteFont>();

            this.Content = Content;

            ContentLoaderLoader.LoadAllContent(this);
            ContentLoaderLoader.LoadAllFonts(this);
        }

        public void AddTexture(TextureNames Name, string TextureFilename) {
            Texture2D texture = Content.Load<Texture2D>(TextureFilename);
            textures.Add(Name, texture);
        }

        public void AddFont(FontNames Name, string FontFilename) {
            SpriteFont font = Content.Load<SpriteFont>(FontFilename);
            fonts.Add(Name, font);
        }

        public Texture2D GetTexture(TextureNames Name) {
            return textures[Name];
        }

        public SpriteFont GetFont(FontNames Name) {
            return fonts[Name];
        }

    }
}
