using GridGame.TechTree.Backend.Technology;
using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend {
    public class NewTechnology {

        private Dictionary<TechnologyTypes, ITechnology> TechnologyMap;

        public NewTechnology() {
            TechnologyMap = new Dictionary<TechnologyTypes, ITechnology>() {
                [TechnologyTypes.BANK] = new BankTechnology(),
                [TechnologyTypes.FACEMASK] = new FacemaskTechnology(),
                [TechnologyTypes.FACTORY] = new FactoryTechnology(),
                [TechnologyTypes.FARM] = new FarmTechnology(),
                [TechnologyTypes.SOAP] = new SoapTechnology(),
                [TechnologyTypes.MEDICAL_TENT] = new MedicalTentTechnology(),
                [TechnologyTypes.HOSPITAL] = new HospitalTechnology(),
                [TechnologyTypes.LABORATORY] = new LaboratoryTechnology(),
            };
        }

        public ITechnology GetTechnology(TechnologyTypes type) {
            return TechnologyMap[type].NewInstance();
        }

    }
}
