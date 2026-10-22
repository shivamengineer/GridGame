using GridGame.Constants.Colors;
using GridGame.Constants.ConstInterfaceInfo;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller {
    public static class ConstantsDictionaryLoader {

        public static List<string> GetFilenames() {
            string filenamesFile = "Content/Data/ConstantsFilenames.txt";
            List<string> Filenames = new List<string>() { "", };

            if(!File.Exists(filenamesFile)) {
                return Filenames;
            }

            using(var stream = TitleContainer.OpenStream(filenamesFile))
            using(var reader = new StreamReader(stream)) {
                while(!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    var input = line.Replace(" ", "");
                    if(input == "") continue; //Skips blank lines

                    Filenames.Add(line);
                }
            }

            return Filenames;
        }

        public static Dictionary<ConstantTypes, IConstantsManager> GetConstantsManagers(string filename) {
            return new Dictionary<ConstantTypes, IConstantsManager>() {
                [ConstantTypes.COLOR] = new ColorConstantsManager(filename),
                [ConstantTypes.GAME_INT] = new GameIntConstantsManager(filename),
                [ConstantTypes.GAME_FLOAT] = new GameFloatConstantsManager(filename),
                [ConstantTypes.USER_INTERFACE] = new UserInterfaceConstantsManager(filename)
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
                [ConstColors.Citizen_Asymptomatic] = CitizenColors.AsymptomaticColor,

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

                [ConstColors.ButtonSelected] = UIElements.ButtonSelectedColor,
                [ConstColors.ButtonNotSelected] = UIElements.ButtonNotSelectedColor,
                [ConstColors.ButtonTextColor] = UIElements.ButtonTextColor,
            };
        }

        public static Dictionary<ConstGameInt, int> GetDefaultGameInts() {
            return new Dictionary<ConstGameInt, int>() {
                [ConstGameInt.StartFood] = StartingResources.STARTING_FOOD,
                [ConstGameInt.StartGold] = StartingResources.STARTING_GOLD,
                [ConstGameInt.StartMorale] = StartingResources.STARTING_MORALE,
                [ConstGameInt.StartProduction] = StartingResources.STARTING_PRODUCTION,                 
                [ConstGameInt.StartScience] = StartingResources.STARTING_SCIENCE,

                [ConstGameInt.BankResourceRate] = BuildingStats.BANK_RATE,
                [ConstGameInt.FactoryResourceRate] = BuildingStats.FACTORY_RATE,
                [ConstGameInt.FarmResourceRate] = BuildingStats.FARM_RATE,
                [ConstGameInt.LaboratoryResourceRate] = BuildingStats.SCIENCE_RATE,

                [ConstGameInt.CityFoodResourceRate] = CityBaseStats.FOOD_RATE,
                [ConstGameInt.CityGoldResourceRate] = CityBaseStats.GOLD_RATE,
                [ConstGameInt.CityMoraleResourceRate] = CityBaseStats.MORALE_RATE,
                [ConstGameInt.CityProductionResourceRate] = CityBaseStats.PRODUCTION_RATE,
                [ConstGameInt.CityScienceResourceRate] = CityBaseStats.SCIENCE_RATE,

                [ConstGameInt.BankGoldCost] = BuildingCosts.BANK_GOLD_COST,
                [ConstGameInt.CityCenterGoldCost] = BuildingCosts.CITY_CENTER_GOLD_COST,
                [ConstGameInt.FactoryGoldCost] = BuildingCosts.FACTORY_GOLD_COST,
                [ConstGameInt.FarmGoldCost] = BuildingCosts.FARM_GOLD_COST,
                [ConstGameInt.HospitalGoldCost] = BuildingCosts.HOSPITAL_GOLD_COST,
                [ConstGameInt.LaboratoryGoldCost] = BuildingCosts.LABORATORY_GOLD_COST,

                [ConstGameInt.BankProductionCost] = BuildingCosts.BANK_PRODUCTION_COST,
                [ConstGameInt.CityCenterProductionCost] = BuildingCosts.CITY_CENTER_PRODUCTION_COST,
                [ConstGameInt.FactoryProductionCost] = BuildingCosts.FACTORY_PRODUCTION_COST,
                [ConstGameInt.FarmProductionCost] = BuildingCosts.FARM_PRODUCTION_COST,
                [ConstGameInt.HospitalProductionCost] = BuildingCosts.HOSPITAL_PRODUCTION_COST,
                [ConstGameInt.LaboratoryProductionCost] = BuildingCosts.LABORATORY_PRODUCTION_COST,

                [ConstGameInt.CanBuildMaxDistanceFromPlayer] = BuildingLimits.BUILDING_RADIUS_FROM_PLAYER,
                [ConstGameInt.CanBuildMaxDistanceFromCity] = BuildingLimits.BUILDING_RADIUS_FROM_CITY,

                [ConstGameInt.CitizenBaseProductivity] = CityBaseStats.CITIZEN_BASE_PRODUCTIVITY,

                [ConstGameInt.CitizenFoodRation] = FoodStats.FOOD_PER_CITIZEN,
                [ConstGameInt.FoodToAddCitizen] = FoodStats.FOOD_TO_ADD_CITIZEN,

                [ConstGameInt.CitizenVisionRadius] = UnitInfo.UNIT_VISION_RADIUS,

                [ConstGameInt.ProductivityBaseLoss] = FoodStats.PRODUCTIVITY_BASE_LOSS,
                [ConstGameInt.ProductivityIncreaseFromFood] = FoodStats.PRODUCTIVITY_GAIN_FROM_FOOD,

                [ConstGameInt.TentScienceCost] = TechCost.MEDICAL_TENT_COST,
                [ConstGameInt.FarmScienceCost] = TechCost.FARM_COST,
                [ConstGameInt.FacemaskScienceCost] = TechCost.FACEMASK_COST,
                [ConstGameInt.LaboratoryScienceCost] = TechCost.LABORATORY_COST,
                [ConstGameInt.SoapScienceCost] = TechCost.SOAP_COST,
                [ConstGameInt.HospitalScienceCost] = TechCost.HOSPITAL_COST,
                [ConstGameInt.BankScienceCost] = TechCost.BANK_COST,
                [ConstGameInt.FactoryScienceCost] = TechCost.FACTORY_COST,

                [ConstGameInt.VirusSpreadRange] = CovidStats.SPREAD_RANGE,

                [ConstGameInt.MapWidth] = GameConstants.MAP_WIDTH,
                [ConstGameInt.MapHeight] = GameConstants.MAP_HEIGHT,
            };
        }

        public static Dictionary<ConstGameFloat, float> GetDefaultGameFloats() {
            return new Dictionary<ConstGameFloat, float>() {
                [ConstGameFloat.CollectResourceInterval] = GameConstants.RESOURCE_TICK_SPEED,
                [ConstGameFloat.FoodCheckInterval] = GameConstants.FOOD_CHECK_TIME,

                [ConstGameFloat.CitizenMoveTime] = UnitInfo.UNIT_MOVE_TIME,

                [ConstGameFloat.RestedStrength] = HealthEffectStats.RESTED_STRENGTH,
                [ConstGameFloat.DrowsyStrength] = HealthEffectStats.DROWSY_STRENGTH,
                [ConstGameFloat.HydratedStrength] = HealthEffectStats.HYDRATED_WATER_STRENGTH,
                [ConstGameFloat.HungryStrength] = HealthEffectStats.HUNGRY_STRENGTH,
                [ConstGameFloat.RestReduceHungerStrength] = HealthEffectStats.REST_REDUCE_HUNGER_STRENGTH,

                [ConstGameFloat.MinStrength] = CovidStats.MIN_STRENGTH,
                [ConstGameFloat.StrengthRange] = CovidStats.STRENGTH_RANGE,

                [ConstGameFloat.VirusBaseDuration] = CovidStats.VIRUS_BASE_DURATION,
                [ConstGameFloat.VirusPersistChance] = CovidStats.VIRUS_CHANCE_TO_SURVIVE,
                [ConstGameFloat.VirusPersistMultiplier] = CovidStats.VIRUS_SURVIVE_MULTIPLIER,
                [ConstGameFloat.VirusSpreadChance] = CovidStats.SPREAD_CHANCE,
                [ConstGameFloat.VirusTimeBeforeSpread] = CovidStats.TIME_TO_SPREAD,
                [ConstGameFloat.VirusTimeBeforeOutbreak] = CovidStats.TIME_BEFORE_OUTBREAK,
                [ConstGameFloat.VirusAsymptomaticTime] = CovidStats.ASYMPTOMATIC_TIME,
                [ConstGameFloat.VirusMortalityRate] = CovidStats.MORTALITY_RATE,
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

                [ConstUserInterface.ConstBlockWidth] = ConstInterfaceUIInfo.BLOCK_WIDTH,
                [ConstUserInterface.ConstBlockHeight] = ConstInterfaceUIInfo.BLOCK_HEIGHT,
                [ConstUserInterface.ConstBlockSpacing] = ConstInterfaceUIInfo.BLOCK_SPACING,

                [ConstUserInterface.ConstGraphScrollSpeed] = ConstInterfaceUIInfo.SCROLL_SPEED,

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
