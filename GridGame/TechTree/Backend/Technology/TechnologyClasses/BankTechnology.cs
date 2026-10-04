using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology.TechnologyClasses {
    public class BankTechnology : AbstractTechnology {

        public BankTechnology() {
            Research = ResearchType.BUILDING;
            Building = BuildingType.Bank;
            TechType = TechnologyTypes.BANK;
        }

        public override ITechnology NewInstance() {
            return new BankTechnology();
        }

    }
}
