using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Terrain {
    public interface ITerrain : ITile {

        public TerrainType GetTerrainType();

        public ITerrain newInstance();

        public void DrawBackground(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath, bool hovered, bool inRange);

    }
}
