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

        public Pawn(int x, int y, Color color, object sendler) : base(x, y, color, sendler)
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

        public override void PerformMove(Figure figure)
        {
            Button targetButton = (Button)figure.GetSendler();
            Button sourceButton = (Button)Sender;
            Grid grid = (Grid)sourceButton.Parent;

            if (figure.GetColor() == Color.Void)
            {
                // Move the pawn to an empty cell
                grid.Children.Remove(sourceButton);
                Grid.SetRow(sourceButton, figure.GetRow());
                Grid.SetColumn(sourceButton, figure.GetColumn());
                grid.Children.Add(sourceButton);
            }
            else if (figure.GetColor() != Color)
            {
                // Capture the opponent's piece
                grid.Children.Remove(targetButton);
                grid.Children.Remove(sourceButton);
                Grid.SetRow(sourceButton, figure.GetRow());
                Grid.SetColumn(sourceButton, figure.GetColumn());
                grid.Children.Add(sourceButton);
            }
        }

        public override string ToString()
        {
            return $"Позиція: ({X}; {Y}), колір: {Color}";
        }
    }
}
