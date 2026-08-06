using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using GridGame.Tiles;
using GridGame.Tiles.Buildings.BuildingClasses;
using GridGame.Tiles.Terrain.TerrainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons.StaticClasses {
    public static class UnknownTileGetter {

        public static Tile GetTile(ContentLoader content) {
            Tile Unknown = new Tile(new Unknown(), new NIL());
            Unknown.SetTerrainTextures(content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER), content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND));
            Unknown.SetBuildingTextures(content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER), content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND));
            return Unknown;
        }

    }
}
