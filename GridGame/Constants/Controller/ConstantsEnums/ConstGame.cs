using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller.ConstantsEnums {
    public enum ConstGame {
        StartFood,
        StartGold,
        StartMorale,
        StartProduction,
        StartScience,

        BankResourceRate,
        FactoryResourceRate,
        FarmResourceRate,
        LaboratoryResourceRate,

        CityFoodResourceRate,
        CityGoldResourceRate,
        CityMoraleResourceRate,
        CityProductionResourceRate,
        CityScienceResourceRate,

        BankGoldCost,
        CityCenterGoldCost,
        FactoryGoldCost,
        FarmGoldCost,
        HospitalGoldCost,
        LaboratoryGoldCost,

        BankProductionCost,
        CityCenterProductionCost,
        FactoryProductionCost,
        FarmProductionCost,
        HospitalProductionCost,
        LaboratoryProductionCost,

        CanBuildMaxDistanceFromPlayer,
        CanBuildMaxDistanceFromCity,

        CitizenBaseProductivity,

        CitizenFoodRation,
        FoodToAddCitizen,

        CitizenVisionRadius,

        ProductivityBaseLoss,
        ProductivityIncreaseFromFood,

        TentScienceCost,
        FarmScienceCost,
        FacemaskScienceCost,
        LaboratoryScienceCost,
        SoapScienceCost,
        HospitalScienceCost,
        BankScienceCost,
        FactoryScienceCost,

        VirusSpreadRange,

        MapWidth,
        MapHeight,

        //FLOATS

        CollectResourceInterval,
        FoodCheckInterval,

        CitizenMoveTime,

        RestedStrength,
        DrowsyStrength,
        HydratedStrength,
        HungryStrength,
        RestReduceHungerStrength,

        MinStrength,
        StrengthRange,

        VirusBaseDuration,
        VirusPersistChance,
        VirusPersistMultiplier,
        VirusSpreadChance,
        VirusTimeBeforeSpread,
        VirusTimeBeforeOutbreak,
        VirusAsymptomaticTime,
        VirusMortalityRate,
    }
}
