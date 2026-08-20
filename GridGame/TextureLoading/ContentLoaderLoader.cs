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
            contentLoader.AddTexture(TextureNames.INFECTED_RECTANGLE, "rect_infected");
            contentLoader.AddTexture(TextureNames.BLANK_HEXAGON_BACKGROUND, "hexagon_white");
            contentLoader.AddTexture(TextureNames.BLANK_HEXAGON_BORDER, "hexagon_white_border");
            contentLoader.AddTexture(TextureNames.INFECTED_HEXAGON_BACKGROUND, "hexagon_infected");
            LoadRiverContent(contentLoader);
        }

        private static void LoadRiverContent(ContentLoader contentLoader) {
            contentLoader.AddTexture(TextureNames.RIVER_1, "rivers/hexagon_river1");
            contentLoader.AddTexture(TextureNames.RIVER_2, "rivers/hexagon_river2");
            contentLoader.AddTexture(TextureNames.RIVER_3, "rivers/hexagon_river3");
            contentLoader.AddTexture(TextureNames.RIVER_4, "rivers/hexagon_river4");
            contentLoader.AddTexture(TextureNames.RIVER_5, "rivers/hexagon_river5");

            contentLoader.AddTexture(TextureNames.RIVER_11, "rivers/hexagon_river11");
            contentLoader.AddTexture(TextureNames.RIVER_12, "rivers/hexagon_river12");
            contentLoader.AddTexture(TextureNames.RIVER_13, "rivers/hexagon_river13");
            contentLoader.AddTexture(TextureNames.RIVER_14, "rivers/hexagon_river14");

            contentLoader.AddTexture(TextureNames.RIVER_21, "rivers/hexagon_river21");
            contentLoader.AddTexture(TextureNames.RIVER_22, "rivers/hexagon_river22");
            contentLoader.AddTexture(TextureNames.RIVER_23, "rivers/hexagon_river23");

            contentLoader.AddTexture(TextureNames.RIVER_31, "rivers/hexagon_river31");
            contentLoader.AddTexture(TextureNames.RIVER_32, "rivers/hexagon_river32");

            contentLoader.AddTexture(TextureNames.RIVER_41, "rivers/hexagon_river41");
        }

        public static void LoadAllFonts(ContentLoader contentLoader) {
            contentLoader.AddFont(FontNames.ARIAL, "ArialFont");
            contentLoader.AddFont(FontNames.ARIAL_SMALL, "ArialSmallFont");
        }

    }
}
