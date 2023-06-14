using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Chess
{
    public class Pawn : Figure
    {
        protected bool IsFirstMove { get; set; }
        protected Button sourceButton { get; set; }
        protected Grid grid { get; set; }

        public Pawn(int row, int column, Color color, object sendler) : base(row, column, color, sendler)
        {
            IsFirstMove = true;
            sourceButton = (Button)Sender;
            grid = (Grid)sourceButton.Parent;
        }

        public override bool CanMove(Figure figure)
        {
            bool flag = false;
            if (figure.GetColor() == Color.Void && Column == figure.GetColumn())
            {
                if (Color == Color.White)
                {
                    if (Row == 6 && figure.GetRow() == 4 && GetFigureFromGrid(5, figure.GetColumn()) == null)
                        flag = true;
                    else if (Row == figure.GetRow() + 1)
                        flag = true;
                }
                else
                {
                    if (Row == 1 && figure.GetRow() == 3 && GetFigureFromGrid(2, figure.GetColumn()) == null)
                        flag = true;
                    else if (Row == figure.GetRow() - 1)
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
                if (figure.GetColumn() + 1 == Column || figure.GetColumn() - 1 == Column)
                {
                    if (Color == Color.White && figure.GetRow() + 1 == Row)
                        flag = true;
                    else if (Color == Color.Black && figure.GetRow() - 1 == Row)
                        flag = true;
                }
            }
            return flag;
        }

        public override void PerformMove(Figure figure)
        {
            Button targetButton = (Button)figure.GetSendler();

            if (CanMove(figure))
            {
                // Move the pawn to an empty cell
                grid.Children.Remove(sourceButton);
                Grid.SetRow(sourceButton, figure.GetRow());
                Grid.SetColumn(sourceButton, figure.GetColumn());
                grid.Children.Add(sourceButton);
            }
            else if (CanCapture(figure))
            {
                // Capture the opponent's piece
                grid.Children.Remove(targetButton);
                grid.Children.Remove(sourceButton);
                Grid.SetRow(sourceButton, figure.GetRow());
                Grid.SetColumn(sourceButton, figure.GetColumn());
                grid.Children.Add(sourceButton);
            }
        }

        //Helper method to get a button from the Grid based on its position
        private Button GetFigureFromGrid(int row, int column)
        {
            foreach (UIElement element in grid.Children)
            {
                if (element is Button button && Grid.GetRow(button) == row && Grid.GetColumn(button) == column)
                {
                    string clickValue = button.Name.ToString(); // pawn_white_1
                    string[] nameInfo = clickValue.Trim().Split('_');
                    if (EnumHelper.GetTypeFromDescription(nameInfo[1]) != Color.Void)
                        return button;
                }
            }
            return null; // Button not found
        }

        public override string ToString()
        {
            return $"Position: ({Row}; {Column}), Color: {Color}";
        }
    }
}
