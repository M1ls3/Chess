using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess
{
    public class Rook : Figure
    {
        public bool HasMoved { get; set; }

        public Rook(int x, int y, Color color, object sender) : base(x, y, color, sender)
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
