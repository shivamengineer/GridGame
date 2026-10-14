using GridGame.Constants;
using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
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

        private int foodToAddCitizen;
        private int foodRation;

        public FoodManager(HexagonMap hexagonMap, ConstantsController constantsController) {
            citizenManager = hexagonMap.citizenManager;
            playerResources = hexagonMap.playerData.playerResources;
            buildingManager = hexagonMap.playerData.buildingManager;

            this.hexagonMap = hexagonMap;

            Dictionary<ConstGame, int> gameInts = constantsController.ConstantsFiles[ConstantTypes.GAME].GetGameInts();
            foodToAddCitizen = gameInts[ConstGame.FoodToAddCitizen];
            foodRation = gameInts[ConstGame.CitizenFoodRation];
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
            int foodNeeded = numCitizens * foodRation;

            if(foodOwned >= foodNeeded) {
                foreach(var citizen in citizenManager.Citizens) {
                    citizen.builder.Eat();
                }
                playerResources.SubtractResource(ResourceType.Food, foodNeeded);
                TryAddCitizen();
            } else {
                FeedSomeCitizens(foodOwned);
            }
            hexagonMap.displayManager.UpdateResource(ResourceType.Food);
        }

        private void TryAddCitizen() {
            int foodOwned = playerResources.GetResourceAmount(ResourceType.Food);

            if(foodOwned >= foodToAddCitizen) {
                if(!citizenManager.AddCitizen(buildingManager.city)) {
                    //citizenManager.AddElsewhere();
                }
            }
        }

        private void FeedSomeCitizens(int foodOwned) {
            int numMeals = foodOwned / foodRation;
            Citizen[] fedCitizens = Random.Shared.GetItems(citizenManager.Citizens.ToArray(), numMeals);
            foreach(var citizen in fedCitizens) {
                citizen.builder.Eat();
            }
        }

    }
}
