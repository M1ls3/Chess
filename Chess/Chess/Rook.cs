using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Rook : Figure
    {
        public bool HasMoved { get; set; }

        public Rook(int x, int y, Color color) : base(x, y, color)
        {
            HasMoved = false;
        }

        public override bool CanMove(int targetX, int targetY, bool capturing)
        {
            return targetX == X || targetY == Y;
        }

        public override bool CanCapture(int targetX, int targetY)
        {
            return CanMove(targetX, targetY, true);
        }

        //public override bool IsChecking(int targetX, int targetY, Figure[,] board)
        //{
        //    return targetX == X || targetY == Y;
        //}

        //public override bool IsCheckmate(Figure[,] board)
        //{
        //    // Checkmate logic for Rook
        //    // ...
        //    return false;
        //}

        public override void PerformMove(Figure figure)
        {
            // Move the Rook
            // ...
        }

        public override string ToString()
        {
            return $"Позиція: ({X}; {Y}), колір: {Color}";
        }
    }
}
