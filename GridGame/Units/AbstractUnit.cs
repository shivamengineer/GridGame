using GridGame.Constants;
using GridGame.Constants.Resources;
using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using GridGame.Tiles.Terrain;
using GridGame.Units.UnitComponents;
using GridGame.Virus.BaseVirus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units {
    public abstract class AbstractUnit : IUnit {

        public Texture2D texture;
        public Texture2D infectedTexture;

        public Transform transform;
        public Movement movement;
        public VirusController virusController;
        public Builder builder;

        public float timeElapsedWorking = 0f;

        public Vector2 origin;
        public HexagonMap hexagonMap;


        public int productivity = 10;

        public void SetTexture(ContentLoader Content) {
            texture = Content.GetTexture(TextureNames.BLANK_RECTANGLE);
            infectedTexture = Content.GetTexture(TextureNames.INFECTED_RECTANGLE);
            Texture2D BorderTexture = Content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER);
            origin = new Vector2(BorderTexture.Width, BorderTexture.Height);
            transform.SetOrigin(origin);
        }

        public void SetActive(bool active) {
            transform.active = active;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, HexagonMath hexMath); 

    }
}
