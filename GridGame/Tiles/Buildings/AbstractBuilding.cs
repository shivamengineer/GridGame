using GridGame.Constants;
using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.Resources;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using GridGame.UI.Popups;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Buildings {
    public abstract class AbstractBuilding : IBuilding {

        private int population = 0;

        public Texture2D borderTexture;
        public Texture2D baseTexture;

        public Vector2 origin;

        private float timeElapsed = 0f;

        public int production_needed = 0;

        public TemporaryPopup resourcePopup;
        public ProgressBar progressBar;

        public HexagonMap map;

        public ContentLoader content;

        public void SetContent(ContentLoader content) {
            this.content = content;
            
            progressBar = new ProgressBar(content);

            borderTexture = content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER);
            baseTexture = content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND);

            origin = new Vector2(borderTexture.Width / 2f, borderTexture.Height / 2f);
        }

        public void SetMap(HexagonMap map) {
            this.map = map;
        }

        public void AddPeople(int numPeople) {
            population += numPeople;
        }

        public void RemovePeople(int numPeople) {
            population -= numPeople;
        }

        public int GetNumPeople() {
            return population;
        }

        public void Update(GameTime gameTime, DisplayManager displayManager) {
            if(progressBar.IsBuilding()) return;

            if(resourcePopup != null) resourcePopup.Update(gameTime);

            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(timeElapsed >= GameConstants.RESOURCE_TICK_SPEED) {
                timeElapsed -= GameConstants.RESOURCE_TICK_SPEED;
                UpdateEvent(displayManager);
            }
        }

        public int Build(int production) {
            return progressBar.Build(production);
        }

        public bool IsBuilding() { return progressBar.IsBuilding(); }

        public abstract void SetInfo();

        public abstract int GetMaxPeople();

        public abstract BuildingType GetBuildingType();

        public abstract IBuilding newInstance();

        public abstract int GetResources();

        public abstract void SetTile(ITile tile);

        public abstract void UpdateEvent(DisplayManager displayManager);

        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath);

        public void DrawProgressBar(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            Vector2 newPos = new Vector2(position.X - 200, position.Y + (20 * hexMath.GetScale()));
            progressBar.Draw(spriteBatch, newPos, hexMath);
        }

    }
}
