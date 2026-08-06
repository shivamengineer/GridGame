using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units {
    public interface IUnit {

        public void MoveTo(int q, int r);

        public void MoveUp();

        public void MoveDown();

        public void MoveUpRight();

        public void MoveDownRight();

        public void MoveUpLeft();

        public void MoveDownLeft();

    }
}
