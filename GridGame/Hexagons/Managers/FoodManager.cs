using GridGame.Constants;
using GridGame.Constants.Resources;
using GridGame.Resources;
using GridGame.Units.UnitClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons.Managers {
    public class FoodManager {

        private HexagonMap hexagonMap;
        private CitizenManager citizenManager;
        private PlayerResources playerResources;
        private BuildingManager buildingManager;

        private float timeElapsed = 0f;

        public FoodManager(HexagonMap hexagonMap) {
            citizenManager = hexagonMap.citizenManager;
            playerResources = hexagonMap.playerData.playerResources;
            buildingManager = hexagonMap.playerData.buildingManager;

            this.hexagonMap = hexagonMap;
        }

        public void Update(GameTime gameTime) {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(timeElapsed >= GameConstants.FOOD_CHECK_TIME) {
                timeElapsed -= GameConstants.FOOD_CHECK_TIME;
                UpdateEvent();
            }
        }

        private void UpdateEvent() {
            int numCitizens = citizenManager.Citizens.Count;
            int foodOwned = playerResources.GetResourceAmount(ResourceType.Food);
            int foodNeeded = numCitizens * FoodStats.FOOD_PER_CITIZEN;

            if(foodOwned >= foodNeeded) {
                playerResources.SubtractResource(ResourceType.Food, foodNeeded);
                TryAddCitizen();
            } else {
                FeedSomeCitizens(foodOwned);
            }
            hexagonMap.displayManager.resourceManager.resourceDisplay.UpdateResource(ResourceType.Food, playerResources);
        }

        private void TryAddCitizen() {
            int foodOwned = playerResources.GetResourceAmount(ResourceType.Food);

            if(foodOwned >= FoodStats.FOOD_TO_ADD_CITIZEN) {
                if(!citizenManager.AddCitizen(buildingManager.city)) {
                    //citizenManager.AddElsewhere();
                }
            }
        }

        private void FeedSomeCitizens(int foodOwned) {
            int numMeals = foodOwned / FoodStats.FOOD_PER_CITIZEN;
            Citizen[] fedCitizens = Random.Shared.GetItems(citizenManager.Citizens.ToArray(), numMeals);
            foreach(var citizen in fedCitizens) {
                citizen.Eat();
            }
        }

    }
}
