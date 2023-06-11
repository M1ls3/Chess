using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess
{
    public class Pawn : Figure
    {
        protected bool IsFirstMove { get; set; }

        public Pawn(int x, int y, Color color) : base(x, y, color)
        {
            IsFirstMove = true;
        }

        public override bool CanMove(int targetX, int targetY, bool capturing)
        {
            int deltaY = Color == Color.White ? targetY - Y : Y - targetY;
            int deltaX = targetX - X;

            if (capturing)
                return deltaY == 1 && Math.Abs(deltaX) == 1;

            if (deltaX != 0)
                return false;

            if (IsFirstMove && deltaY <= 2 && deltaY > 0)
                return true;

            return deltaY == 1;
        }

        public override bool CanCapture(int targetX, int targetY)
        {
            int deltaY = Color == Color.White ? targetY - Y : Y - targetY;
            int deltaX = targetX - X;

            return deltaY == 1 && Math.Abs(deltaX) == 1;
        }

        //public override bool IsChecking(int targetX, int targetY, Figure[,] board)
        //{
        //    int deltaY = Color == Color.White ? targetY - Y : Y - targetY;
        //    int deltaX = targetX - X;

        //    return deltaY == 1 && Math.Abs(deltaX) == 1;
        //}

        //public override bool IsCheckmate(Figure[,] board)
        //{
        //    // Checkmate logic for Pawn
        //    // ...
        //    return false;
        //}

        public override void PerformMove(Figure figure)
        {
            X = figure.GetRow();
            Y = figure.GetColumn();
        }

        public override string ToString()
        {
            return $"Позиція: ({X}; {Y}), колір: {Color}";
        }
    }
}
