using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Queen : Figure
    {
        public Queen(int x, int y, Color color) : base(x, y, color)
        {
        }

        public override bool CanMove(int targetX, int targetY, bool capturing)
        {
            int deltaX = Math.Abs(targetX - X);
            int deltaY = Math.Abs(targetY - Y);

            return deltaX == deltaY || targetX == X || targetY == Y;
        }

        public override bool CanCapture(int targetX, int targetY)
        {
            return CanMove(targetX, targetY, true);
        }

        //public override bool IsChecking(int targetX, int targetY, Figure[,] board)
        //{
        //    return CanMove(targetX, targetY, false);
        //}

        //public override bool IsCheckmate(Figure[,] board)
        //{
        //    // Checkmate logic for Queen
        //    // ...
        //    return false;
        //}

        public override void PerformMove(Figure figure)
        {
            // Move the Queen
            // ...
        }

        public override string ToString()
        {
            return $"Позиція: ({X}; {Y}), колір: {Color}";
        }
    }
}
