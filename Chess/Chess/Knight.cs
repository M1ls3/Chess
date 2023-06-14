using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chess
{
    public class Knight : Figure
    {
        protected Button sourceButton { get; set; }

        public Knight(int x, int y, Color color, object sender) : base(x, y, color, sender)
        {
            sourceButton = (Button)Sender;
        }

        private bool MovePattern(Figure figure)
        {
            bool flag = false;
            if ((Row == figure.GetRow() + 2 && Column == figure.GetColumn() + 1) || (Row == figure.GetRow() + 2 && Column == figure.GetColumn() - 1) ||
                (Row == figure.GetRow() - 2 && Column == figure.GetColumn() + 1) || (Row == figure.GetRow() - 2 && Column == figure.GetColumn() - 1) ||
                (Row == figure.GetRow() + 1 && Column == figure.GetColumn() + 2) || (Row == figure.GetRow() + 1 && Column == figure.GetColumn() - 2) ||
                (Row == figure.GetRow() - 1 && Column == figure.GetColumn() + 2) || (Row == figure.GetRow() - 1 && Column == figure.GetColumn() - 2))
                flag = true;
            return flag;
        }

        public override bool CanMove(Figure figure)
        {
            bool flag = false;
            if (figure.GetColor() == Color.Void)
            {
                if (MovePattern(figure))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public override bool CanCapture(Figure figure)
        {
            bool flag = false;
            if (Color != figure.GetColor() && figure.GetColor() != Color.Void)
            {
                if (MovePattern(figure))
                {
                    flag = true;
                }
            }
            return flag;
        }


        public override bool PerformMove(Figure figure)
        {
            Button targetButton = (Button)figure.GetSender();

            if (CanMove(figure))
            {
                // Move the pawn to an empty cell
                grid.Children.Remove(sourceButton);
                Grid.SetRow(sourceButton, figure.GetRow());
                Grid.SetColumn(sourceButton, figure.GetColumn());
                grid.Children.Add(sourceButton);
                return true;
            }
            else if (CanCapture(figure))
            {
                // Capture the opponent's piece
                grid.Children.Remove(targetButton);
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
            return $"Position: ({Row}; {Column}), Color: {Color}";
        }
    }
}
