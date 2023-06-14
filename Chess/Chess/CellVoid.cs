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

        public CellVoid(int row, int column, Color color, object sender) : base(row, column, color, sender)
        {
            sourceButton = (Button)Sender;
        }
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
            if (figure.GetColor() == Color.Void)
            {
                // Move the pawn to an empty cell
                grid.Children.Remove(sourceButton);
                Grid.SetRow(sourceButton, figure.GetRow());
                Grid.SetColumn(sourceButton, figure.GetColumn());
                grid.Children.Add(sourceButton);
                return true;
            }      
            return false;
        }

        public override string ToString()
        {
            return $"Position: ({Row}; {Column}), State: {Color}";
        }
    }
}

