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

        private Dictionary<string, Texture2D> textures;
        private Dictionary<string, SpriteFont> fonts;

        private ContentManager Content;

        public ContentLoader(ContentManager Content) {
            textures = new Dictionary<string, Texture2D>();
            fonts = new Dictionary<string, SpriteFont>();

            this.Content = Content;

            ContentLoaderLoader.LoadAllContent(this);
            ContentLoaderLoader.LoadAllFonts(this);
        }

        public void AddTexture(string Name, string TextureFilename) {
            Texture2D texture = Content.Load<Texture2D>(TextureFilename);
            textures.Add(Name, texture);
        }

        public void AddFont(string Name, string FontFilename) {
            SpriteFont font = Content.Load<SpriteFont>(FontFilename);
            fonts.Add(Name, font);
        }

        public Texture2D GetTexture(string Name) {
            return textures[Name];
        }

        public SpriteFont GetFont(string Name) {
            return fonts[Name];
        }

    }
}
