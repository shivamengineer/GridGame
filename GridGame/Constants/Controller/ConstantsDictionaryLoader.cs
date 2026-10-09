using GridGame.Constants.Colors;
using GridGame.Constants.Controller.ConstantsClasses;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Resources;
using GridGame.Constants.TechTreeInfo;
using GridGame.Constants.Treatment;
using GridGame.Constants.Viruses.Covid;
using GridGame.Tiles.Buildings.BuildingClasses;
using GridGame.Tiles.Terrain.TerrainClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller {
    public static class ConstantsDictionaryLoader {

        public static Dictionary<ConstantTypes, string> GetFilenames() {
            return new Dictionary<ConstantTypes, string>() {
                [ConstantTypes.COLOR] = "ConstantColor.txt",
                [ConstantTypes.GAME] = "ConstantGame.txt",
                [ConstantTypes.USER_INTERFACE] = "ConstantUserInterface.txt",
            };
        }

        public static Dictionary<ConstantTypes, IConstantsManager> GetConstantsManagers() {
            return new Dictionary<ConstantTypes, IConstantsManager>() {
                [ConstantTypes.COLOR] = new ColorConstantsManager(),
                [ConstantTypes.GAME] = new GameConstantsManager(),
                [ConstantTypes.USER_INTERFACE] = new UserInterfaceConstantsManager()
            };
        }

        public static Dictionary<ConstColors, Color> GetDefaultColorConstants() {
            return new Dictionary<ConstColors, Color>() {
                [ConstColors.Bank] = BuildingColors.BankColor,
                [ConstColors.CityCenter] = BuildingColors.CityCenterColor,
                [ConstColors.Tile_Empty] = BuildingColors.EmptyColor,
                [ConstColors.Factory] = BuildingColors.FactoryColor,
                [ConstColors.Farm] = BuildingColors.FarmColor,
                [ConstColors.Hospital] = BuildingColors.HospitalColor,
                [ConstColors.Laboratory] = BuildingColors.LaboratoryColor,
                [ConstColors.Tile_NIL] = BuildingColors.NILColor,

                [ConstColors.Citizen_Active] = CitizenColors.ActiveColor,
                [ConstColors.Citizen_Inactive] = CitizenColors.InactiveColor,
                [ConstColors.Citizen_Infected] = CitizenColors.InfectColor,

                [ConstColors.Ocean] = TerrainColors.OceanColor,
                [ConstColors.Land] = TerrainColors.LandColor,
                [ConstColors.Coast] = TerrainColors.CoastColor,
                [ConstColors.LandRiver] = TerrainColors.Land_RiverColor,
                [ConstColors.Unknown] = TerrainColors.UnknownColor,
                [ConstColors.UnknownBorder] = TerrainColors.UnknownBorderColor,

                [ConstColors.OceanHover] = TerrainColors.OceanHoverColor,
                [ConstColors.LandHover] = TerrainColors.LandHoverColor,
                [ConstColors.CoastHover] = TerrainColors.CoastHoverColor,
                [ConstColors.LandRiverHover] = TerrainColors.Land_RiverHoverColor,
                [ConstColors.DefaultHover] = TerrainColors.DefaultHoverColor,

                [ConstColors.CanBuild] = TerrainColors.CanBuildColor,
                [ConstColors.CannotBuild] = TerrainColors.CannotBuildColor,
            };
        }

        public static Dictionary<ConstGame, int> GetDefaultGameInts() {
            return new Dictionary<ConstGame, int>() {
                [ConstGame.StartFood] = StartingResources.STARTING_FOOD,
                [ConstGame.StartGold] = StartingResources.STARTING_GOLD,
                [ConstGame.StartMorale] = StartingResources.STARTING_MORALE,
                [ConstGame.StartProduction] = StartingResources.STARTING_PRODUCTION,                 
                [ConstGame.StartScience] = StartingResources.STARTING_SCIENCE,

                [ConstGame.BankResourceRate] = BuildingStats.BANK_RATE,
                [ConstGame.FactoryResourceRate] = BuildingStats.FACTORY_RATE,
                [ConstGame.FarmResourceRate] = BuildingStats.FARM_RATE,
                [ConstGame.LaboratoryResourceRate] = BuildingStats.SCIENCE_RATE,

                [ConstGame.CityFoodResourceRate] = CityBaseStats.FOOD_RATE,
                [ConstGame.CityGoldResourceRate] = CityBaseStats.GOLD_RATE,
                [ConstGame.CityMoraleResourceRate] = CityBaseStats.MORALE_RATE,
                [ConstGame.CityProductionResourceRate] = CityBaseStats.PRODUCTION_RATE,
                [ConstGame.CityScienceResourceRate] = CityBaseStats.SCIENCE_RATE,

                [ConstGame.BankGoldCost] = BuildingCosts.BANK_GOLD_COST,
                [ConstGame.CityCenterGoldCost] = BuildingCosts.CITY_CENTER_GOLD_COST,
                [ConstGame.FactoryGoldCost] = BuildingCosts.FACTORY_GOLD_COST,
                [ConstGame.FarmGoldCost] = BuildingCosts.FARM_GOLD_COST,
                [ConstGame.HospitalGoldCost] = BuildingCosts.HOSPITAL_GOLD_COST,
                [ConstGame.LaboratoryGoldCost] = BuildingCosts.LABORATORY_GOLD_COST,

                [ConstGame.BankProductionCost] = BuildingCosts.BANK_PRODUCTION_COST,
                [ConstGame.CityCenterProductionCost] = BuildingCosts.CITY_CENTER_PRODUCTION_COST,
                [ConstGame.FactoryProductionCost] = BuildingCosts.FACTORY_PRODUCTION_COST,
                [ConstGame.FarmProductionCost] = BuildingCosts.FARM_PRODUCTION_COST,
                [ConstGame.HospitalProductionCost] = BuildingCosts.HOSPITAL_PRODUCTION_COST,
                [ConstGame.LaboratoryProductionCost] = BuildingCosts.LABORATORY_PRODUCTION_COST,

                [ConstGame.CanBuildMaxDistanceFromPlayer] = BuildingLimits.BUILDING_RADIUS_FROM_PLAYER,
                [ConstGame.CanBuildMaxDistanceFromCity] = BuildingLimits.BUILDING_RADIUS_FROM_CITY,

                [ConstGame.CitizenBaseProductivity] = CityBaseStats.CITIZEN_BASE_PRODUCTIVITY,

                [ConstGame.CitizenFoodRation] = FoodStats.FOOD_PER_CITIZEN,
                [ConstGame.FoodToAddCitizen] = FoodStats.FOOD_TO_ADD_CITIZEN,

                [ConstGame.CitizenVisionRadius] = UnitInfo.UNIT_VISION_RADIUS,

                [ConstGame.ProductivityBaseLoss] = FoodStats.PRODUCTIVITY_BASE_LOSS,
                [ConstGame.ProductivityIncreaseFromFood] = FoodStats.PRODUCTIVITY_GAIN_FROM_FOOD,

                [ConstGame.TentScienceCost] = TechCost.MEDICAL_TENT_COST,
                [ConstGame.FarmScienceCost] = TechCost.FARM_COST,
                [ConstGame.FacemaskScienceCost] = TechCost.FACEMASK_COST,
                [ConstGame.LaboratoryScienceCost] = TechCost.LABORATORY_COST,
                [ConstGame.SoapScienceCost] = TechCost.SOAP_COST,
                [ConstGame.HospitalScienceCost] = TechCost.HOSPITAL_COST,
                [ConstGame.BankScienceCost] = TechCost.BANK_COST,
                [ConstGame.FactoryScienceCost] = TechCost.FACTORY_COST,

                [ConstGame.VirusSpreadRange] = CovidStats.SPREAD_RANGE,

                [ConstGame.MapWidth] = GameConstants.MAP_WIDTH,
                [ConstGame.MapHeight] = GameConstants.MAP_HEIGHT,
            };
        }

        public static Dictionary<ConstGame, float> GetDefaultGameFloats() {
            return new Dictionary<ConstGame, float>() {
                [ConstGame.CollectResourceInterval] = GameConstants.RESOURCE_TICK_SPEED,
                [ConstGame.FoodCheckInterval] = GameConstants.FOOD_CHECK_TIME,

                [ConstGame.CitizenMoveTime] = UnitInfo.UNIT_MOVE_TIME,

                [ConstGame.RestedStrength] = HealthEffectStats.RESTED_STRENGTH,
                [ConstGame.DrowsyStrength] = HealthEffectStats.DROWSY_STRENGTH,
                [ConstGame.HydratedStrength] = HealthEffectStats.HYDRATED_WATER_STRENGTH,
                [ConstGame.HungryStrength] = HealthEffectStats.HUNGRY_STRENGTH,
                [ConstGame.RestReduceHungerStrength] = HealthEffectStats.REST_REDUCE_HUNGER_STRENGTH,

                [ConstGame.MinStrength] = CovidStats.MIN_STRENGTH,
                [ConstGame.StrengthRange] = CovidStats.STRENGTH_RANGE,

                [ConstGame.VirusBaseDuration] = CovidStats.VIRUS_BASE_DURATION,
                [ConstGame.VirusPersistChance] = CovidStats.VIRUS_CHANCE_TO_SURVIVE,
                [ConstGame.VirusPersistMultiplier] = CovidStats.VIRUS_SURVIVE_MULTIPLIER,
                [ConstGame.VirusSpreadChance] = CovidStats.SPREAD_CHANCE,
                [ConstGame.VirusTimeBeforeSpread] = CovidStats.TIME_TO_SPREAD,
                [ConstGame.VirusTimeBeforeOutbreak] = CovidStats.TIME_BEFORE_OUTBREAK,
                [ConstGame.VirusAsymptomaticTime] = CovidStats.ASYMPTOMATIC_TIME,
                [ConstGame.VirusMortalityRate] = CovidStats.MORTALITY_RATE,
            };
        }

        public static Dictionary<ConstUserInterface, int> GetDefaultUserInterfaceValues() {
            return new Dictionary<ConstUserInterface, int>() {
                [ConstUserInterface.WindowWidth] = GameConstants.WINDOW_WIDTH,
                [ConstUserInterface.WindowHeight] = GameConstants.WINDOW_HEIGHT,

                [ConstUserInterface.TechBlockWidth] = TechTreeGraph.BLOCK_WIDTH,
                [ConstUserInterface.TechBlockHeight] = TechTreeGraph.BLOCK_HEIGHT,
                [ConstUserInterface.TechBlockSpacing] = TechTreeGraph.BLOCK_SPACING,

                [ConstUserInterface.TechTreeScrollSpeed] = TechTreeGraph.SCROLL_SPEED,

                [ConstUserInterface.ProgressBarWidth] = PopupInfo.PROGRESS_BAR_WIDTH,
                [ConstUserInterface.ProgressBarHeight] = PopupInfo.PROGRESS_BAR_HEIGHT,

                [ConstUserInterface.CollectResourcePopupWidth] = PopupInfo.RESOURCE_POPUP_WIDTH,
                [ConstUserInterface.CollectResourcePopupHeight] = PopupInfo.RESOURCE_POPUP_HEIGHT,

                [ConstUserInterface.ResourcesOverlayHeight] = UIOverlayDetails.RESOURCE_BAR_HEIGHT,
                [ConstUserInterface.ResourcesOverlayPadding] = UIOverlayDetails.RESOURCE_BAR_PADDING,
                [ConstUserInterface.ResourcesOverlayY] = UIOverlayDetails.RESOURCE_BAR_Y,
                [ConstUserInterface.ResourcesOverlayElementY] = UIOverlayDetails.RESOURCE_BAR_ITEM_Y,
                [ConstUserInterface.ResourcesOverlayElementMarginX] = UIOverlayDetails.RESOURCE_BAR_ITEM_MARGIN_X,

                [ConstUserInterface.CitizenInfectedBarWidth] = UnitInfo.INFECTED_WIDTH,
                [ConstUserInterface.CitizenInfectedBarHeight] = UnitInfo.INFECTED_HEIGHT,

                [ConstUserInterface.CitizenWidth] = UnitInfo.UNIT_WIDTH,
                [ConstUserInterface.CitizenHeight] = UnitInfo.UNIT_HEIGHT,
            };
        }

    }
}
