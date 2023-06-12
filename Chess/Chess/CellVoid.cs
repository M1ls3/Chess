using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess
{
    internal class CellVoid : Figure
    {
        public CellVoid(int x, int y, Color color, object sender) : base(x, y, color, sender)
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
        }

        public override string ToString()
        {
            return $"Позиція: ({X}; {Y}), стан: {Color}";
        }
    }
}

