using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class CellVoid : Figure
    {
        public CellVoid(int x, int y, Color color) : base(x, y, color)
        {
            
        }
        public override bool CanCapture(int targetX, int targetY)
        {
            throw new NotImplementedException();
        }
        public override bool CanMove(int targetX, int targetY, bool capturing)
        {
            throw new NotImplementedException();
        }
        public override void PerformMove(Figure figure)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Позиція: ({X}; {Y}), стан: {Color}";
        }
    }
}
