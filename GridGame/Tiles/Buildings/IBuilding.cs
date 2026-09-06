using GridGame.Hexagons;
using GridGame.TextureLoading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Buildings {
    public interface IBuilding : ITile {

        public BuildingType BuildingType { get; protected set; }

        public void SetInfo();
        
        public int Build(int production);

        public bool IsBuilding();

        public IBuilding newInstance();

        public void DrawUI(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath);

    }
}
