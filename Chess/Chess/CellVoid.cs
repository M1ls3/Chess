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
        protected Button sourceButton { get; set; }
        protected Grid grid { get; set; }

        public CellVoid(int x, int y, Color color, object sender) : base(x, y, color, sender)
        {
            sourceButton = (Button)Sender;
            grid = (Grid)sourceButton.Parent;
        }
        public override bool CanCapture(Figure figure)
        {
            throw new NotImplementedException();
        }
        public override bool CanMove(Figure figure)
        {
            throw new NotImplementedException();
        }

        public override void PerformMove(Figure figure)
        {
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
            return $"Позиція: ({Row}; {Column}), стан: {Color}";
        }
    }
}

