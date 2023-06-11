using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class King : Figure
    {
        public bool HasMoved { get; set; }

        public King(int x, int y, Color color) : base(x, y, color)
        {
            HasMoved = false;
        }

        public override bool CanMove(int targetX, int targetY, bool capturing)
        {
            int deltaX = Math.Abs(targetX - X);
            int deltaY = Math.Abs(targetY - Y);

            return (deltaX == 1 && deltaY <= 1) || (deltaX <= 1 && deltaY == 1);
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
        //    // Checkmate logic for King
        //    // ...
        //    return false;
        //}

        public override void PerformMove(Figure figure)
        {
            // Move the King
            // ...
        }

        public override string ToString()
        {
            return $"Позиція: ({X}; {Y}), колір: {Color}";
        }
    }
}
