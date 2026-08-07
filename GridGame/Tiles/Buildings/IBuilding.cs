using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Buildings {
    public interface IBuilding : ITile {

        public int Build(int production);

        public BuildingType GetBuildingType();

        public IBuilding newInstance();

    }
}
