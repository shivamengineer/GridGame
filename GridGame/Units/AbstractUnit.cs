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

        public float progress = 0f;
        public float timeElapsed = 0f;
        public float timeElapsedWorking = 0f;

        public Dictionary<InfectType, IVirus> viruses;
        public HashSet<VirusNames> virusesImmune;

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

        public void Eat() {
            productivity += FoodStats.PRODUCTIVITY_GAIN_FROM_FOOD; //replenish energy
            if(productivity > 10) productivity = 10;
        }

        public void MoveUp() {
            if(transform.moving) return;

            transform.SetTargetCoords(0, -1);

            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;

            SetMoving();
        }

        public void MoveDown() {
            if(transform.moving) return;

            transform.SetTargetCoords(0, 1);

            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;

            SetMoving();
        }

        public void MoveUpRight() {
            if(transform.moving) return;

            transform.SetTargetCoords(1, -1);

            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;

            SetMoving();
        }

        public void MoveDownRight() {
            if(transform.moving) return;

            transform.SetTargetCoords(1, 0);

            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;

            SetMoving();
        }

        public void MoveUpLeft() {
            if(transform.moving) return;

            transform.SetTargetCoords(-1, 0);
                                  
            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;

            SetMoving();
        }

        public void MoveDownLeft() {
            if(transform.moving) return;

            transform.SetTargetCoords(-1, 1);

            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;

            SetMoving();
        }

        public void SetMoving() {
            if(hexagonMap.hexMap.Tiles[transform.TargetCoords].GetTerrainType() == TerrainType.Ocean) return;

            transform.moving = true;
            timeElapsed = 0f;
            timeElapsedWorking = 0f;
        }

        public void SetActive(bool active) {
            transform.active = active;
        }

        public void WorkAtBuilding(GameTime gameTime) {
            timeElapsedWorking += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(timeElapsedWorking >= GameConstants.RESOURCE_TICK_SPEED) {
                timeElapsedWorking -= GameConstants.RESOURCE_TICK_SPEED;

                productivity -= FoodStats.PRODUCTIVITY_BASE_LOSS; // grow hungry
                if(productivity < 0) productivity = 0;

                if(!hexagonMap.hexMap.Tiles[transform.Coords].IsBuilding()) {
                    hexagonMap.WorkTile(transform.Coords);
                } else {
                    int production = productivity * CityBaseStats.CITIZEN_BASE_PRODUCTIVITY;
                    if(!virusesImmune.Contains(VirusNames.Coronavirus) && viruses.ContainsKey(InfectType.CITIZEN_INFECT)) {
                        production = (int)viruses[InfectType.CITIZEN_INFECT].GetCitizenProductivity(production);
                    }

                    hexagonMap.BuildBuilding(transform.Coords, productivity * CityBaseStats.CITIZEN_BASE_PRODUCTIVITY);
                }
            }
        }

        public void UpdatePos(GameTime gameTime) {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            progress = timeElapsed / UnitInfo.UNIT_MOVE_TIME;
            if(progress > 1.0f) {
                ProgressEvent();
                UpdateHexagonMap();
            }
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, HexagonMath hexMath); 

        private void ProgressEvent() {
            progress = 1.0f;
            transform.Coords = transform.TargetCoords;
            transform.moving = false;
        }

        private void UpdateHexagonMap() {
            hexagonMap.citizenManager.UpdatePos();
            hexagonMap.hexMap.UpdateVision(transform.Coords, UnitInfo.UNIT_VISION_RADIUS);
            hexagonMap.hexMap.HexMath.FocusCamera();
            hexagonMap.SetHover(hexagonMap.hexMap.HoveredTile);
        }

    }
}
