using GridGame.TextureLoading.TextureEnums;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GridGame.TextureLoading {
    public static class ContentLoaderLoader {
        
        public static void LoadAllContent(ContentLoader contentLoader) {
            contentLoader.AddTexture(TextureNames.BLANK_RECTANGLE, "rect_blank");
            contentLoader.AddTexture(TextureNames.BLANK_HEXAGON_BACKGROUND, "hexagon_white");
            contentLoader.AddTexture(TextureNames.BLANK_HEXAGON_BORDER, "hexagon_white_border");
        }

        public static void LoadAllFonts(ContentLoader contentLoader) {
            contentLoader.AddFont(FontNames.ARIAL, "ArialFont");
            contentLoader.AddFont(FontNames.ARIAL_SMALL, "ArialSmallFont");
        }

    }
}
