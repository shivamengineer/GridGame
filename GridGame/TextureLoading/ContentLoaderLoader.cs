using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TextureLoading {
    public static class ContentLoaderLoader {
        
        public static void LoadAllContent(ContentLoader contentLoader) {
            contentLoader.AddTexture("BlankRectangle", "rect_blank");
            contentLoader.AddTexture("BlankHexagon", "hexagon_white");
            contentLoader.AddTexture("BlankHexagonBorder", "hexagon_white_border");
        }

        public static void LoadAllFonts(ContentLoader contentLoader) {
            contentLoader.AddFont("Arial", "ArialFont");
        }

    }
}
