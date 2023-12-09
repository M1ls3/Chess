using System;

namespace Chess
{
    internal class CellVoid : Figure
    { 

        public CellVoid(int row, int column, Color color, object sender) : base(row, column, color, sender) { }

        public override bool CanCapture(Figure figure)
        {
            throw new NotImplementedException();
        }
        public override bool CanMove(Figure figure)
        {
            throw new NotImplementedException();
        }

        public override bool PerformMove(Figure figure)
        {
            return false;
        }

        public override string ToString()
        {
            return $"Position: ({Row}; {Column}), State: {Color}";
        }
    }
}

