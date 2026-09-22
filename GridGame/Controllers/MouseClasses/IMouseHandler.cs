using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Controllers.MouseClasses {
    public interface IMouseHandler {

        public void OnMouseDown(int x, int y, HexagonMap hexagonMap);

    }
}
