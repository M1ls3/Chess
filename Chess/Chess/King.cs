using System;
using System.Windows.Controls;

namespace Chess
{
    public class King : Figure
    {
        protected Button sourceButton { get; set; }

        public King(int row, int column, Color color, object sender) : base(row, column, color, sender)
        {
            sourceButton = (Button)Sender;
        }

        private bool MovePattern(Figure figure)
        {
            bool flag = false;
            int deltaColumn = Math.Abs(Column - figure.GetColumn());
            int deltaRow = Math.Abs(Row - figure.GetRow());
            if (deltaColumn <= 1 && deltaRow <= 1)
            {
                flag = true;
            }
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
                Replace(figure);
                sourceButton.Content = " ";
                return true;
            }
            else if (CanCapture(figure))
            {
                // Capture the opponent's piece
                grid.Children.Remove(targetButton);
                Replace(figure);
                sourceButton.Content = " ";
                return true;
            }
            else return CanCastling(figure);
        } 

        public bool CanCastling(Figure figure)
        {
            bool flag = false;
            if (figure.GetColor() == Color.Void && sourceButton.Content.ToString() == "N")
            {
                if (figure.GetColumn() == 6)
                {
                    Button rook = GetFigureFromGrid(Row, 7);
                    string[] value = rook.Name.Trim().Split('_');
                    string name = value[0];
                    string color = value[1];

                    if (rook != null && name == "rook" && EnumHelper.GetTypeFromDescription(color) == Color
                        && rook.Content.ToString() == "N" && GetFigureFromGrid(Row, 5) == null)
                    {
                        grid.Children.Remove(sourceButton);
                        grid.Children.Remove(rook);
                        Grid.SetRow(sourceButton, figure.GetRow());
                        Grid.SetColumn(sourceButton, figure.GetColumn());
                        grid.Children.Add(sourceButton);
                        Grid.SetRow(rook, figure.GetRow());
                        Grid.SetColumn(rook, figure.GetColumn() - 1);
                        grid.Children.Add(rook);
                        sourceButton.Content = " ";
                        flag = true;
                    }
                }
                else if (figure.GetColumn() == 2)
                {
                    Button rook = GetFigureFromGrid(Row, 0);
                    string[] value = rook.Name.Trim().Split('_');
                    string name = value[0];
                    string color = value[1];

                    if (rook != null && name == "rook" && EnumHelper.GetTypeFromDescription(color) == Color
                        && rook.Content.ToString() == "N" && GetFigureFromGrid(Row, 1) == null && GetFigureFromGrid(Row, 3) == null)
                    {
                        grid.Children.Remove(sourceButton);
                        grid.Children.Remove(rook);
                        Grid.SetRow(sourceButton, figure.GetRow());
                        Grid.SetColumn(sourceButton, figure.GetColumn() - 1);
                        grid.Children.Add(sourceButton);
                        Grid.SetRow(rook, figure.GetRow());
                        Grid.SetColumn(rook, figure.GetColumn());
                        grid.Children.Add(rook);
                        sourceButton.Content = " ";
                        flag = true;
                    }
                }
            }
            return flag;
        }

        public override string ToString()
        {
            return $"Position: ({Row}; {Column}), Color: {Color}";
        }
    }
}
