using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess
{
    public class Queen : Figure
    {
        protected Button sourceButton { get; set; }
        protected Grid grid { get; set; }

        public Queen(int x, int y, Color color, object sender) : base(x, y, color, sender)
        {
            sourceButton = (Button)Sender;
            grid = (Grid)sourceButton.Parent;
        }

        public override bool CanMove(Figure figure)
        {
            return true;
            //int deltaX = Math.Abs(targetX - X);
            //int deltaY = Math.Abs(targetY - Y);

            //return deltaX == deltaY || targetX == X || targetY == Y;
        }

        public override bool CanCapture(Figure figure)
        {
            return false;
            //return CanMove(targetX, targetY, true);
        }

        public override void PerformMove(Figure figure)
        {
            Button targetButton = (Button)figure.GetSendler();

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
            return $"Позиція: ({Row}; {Column}), колір: {Color}";
        }
    }
}
