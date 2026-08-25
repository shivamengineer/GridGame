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

        public float timeElapsedWorking = 0f;

        public Dictionary<InfectType, IVirus> viruses;
        public HashSet<VirusNames> virusesImmune;

        public Vector2 origin;
        public HexagonMap hexagonMap;

        public Movement movement;

        public int productivity = 10;

        public void SetTexture(ContentLoader Content) {
            texture = Content.GetTexture(TextureNames.BLANK_RECTANGLE);
            infectedTexture = Content.GetTexture(TextureNames.INFECTED_RECTANGLE);
            Texture2D BorderTexture = Content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER);
            origin = new Vector2(BorderTexture.Width, BorderTexture.Height);
            transform.SetOrigin(origin);
        }

        public void Eat() {
            productivity += FoodStats.PRODUCTIVITY_GAIN_FROM_FOOD; //replenish energy
            if(productivity > 10) productivity = 10;
        }

        public void SetActive(bool active) {
            transform.active = active;
        }

        public void WorkAtBuilding(GameTime gameTime) {
            if(!UpdateTime(gameTime)) return;
            GrowHungry();

            if(!hexagonMap.hexMap.Tiles[transform.Coords].IsBuilding()) hexagonMap.WorkTile(transform.Coords);
            else BuildBuilding();
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, HexagonMath hexMath); 

        private bool UpdateTime(GameTime gameTime) {
            timeElapsedWorking += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timeElapsedWorking >= GameConstants.RESOURCE_TICK_SPEED) {
                timeElapsedWorking -= GameConstants.RESOURCE_TICK_SPEED;
                return true;
            }
            return false;
        }

        private void GrowHungry() {
            productivity -= FoodStats.PRODUCTIVITY_BASE_LOSS; // grow hungry if working
            if(productivity < 0) productivity = 0;
        }

        private void BuildBuilding() {
            int production = productivity * CityBaseStats.CITIZEN_BASE_PRODUCTIVITY;
            if(!virusesImmune.Contains(VirusNames.Coronavirus) && viruses.ContainsKey(InfectType.CITIZEN_INFECT)) {
                production = (int)viruses[InfectType.CITIZEN_INFECT].GetCitizenProductivity(production);
            }
            hexagonMap.BuildBuilding(transform.Coords, productivity * CityBaseStats.CITIZEN_BASE_PRODUCTIVITY);
        }

    }
}
