using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Chess
{
    public class Bishop : Figure
    {
        public Bishop(int row, int column, Color color, object sender) : base(row, column, color, sender) { }

        public bool MovePattern(Figure figure)
        {
            bool flag = false;
            int deltaColumn = Math.Abs(Column - figure.GetColumn());
            int deltaRow = Math.Abs(Row - figure.GetRow());
            if (deltaColumn == deltaRow) // Check if the movement is along a diagonal
            {
                if (Row > figure.GetRow())
                {
                    if (Column > figure.GetColumn())
                    {
                        for (int i = 0; i < deltaColumn; i++)
                        {
                            Button button = GetFigureFromGrid(Row - i, Column - i);
                            if (button == null)
                                flag = true;
                            else return false;
                        }
                    }
                    else if (Column < figure.GetColumn())
                    {
                        for (int i = 0; i < deltaColumn; i++)
                        {
                            Button button = GetFigureFromGrid(Row - i, Column + i);
                            if (button == null)
                                flag = true;
                            else return false;
                        }
                    }
                }
                else if (Row < figure.GetRow())
                {
                    if (Column > figure.GetColumn())
                    {
                        for (int i = 0; i < deltaColumn; i++)
                        {
                            Button button = GetFigureFromGrid(Row + i, Column - i);
                            if (button == null)
                                flag = true;
                            else return false;
                        }
                    }
                    else if (Column < figure.GetColumn())
                    {
                        for (int i = 0; i < deltaColumn; i++)
                        {
                            Button button = GetFigureFromGrid(Row + i, Column + i);
                            if (button == null)
                                flag = true;
                            else return false;
                        }
                    }
                }
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
                // Move to an empty cell
                Replace(figure);
                return true;
            }
            else if (CanCapture(figure))
            {
                // Capture the opponent's piece
                grid.Children.Remove(targetButton);
                Replace(figure);
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
