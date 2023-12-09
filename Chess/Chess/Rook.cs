using System.Windows;
using System.Windows.Controls;

namespace Chess
{
    public class Rook : Figure
    {
        protected Button sourceButton { get; set; }

        public Rook(int row, int column, Color color, object sender) : base(row, column, color, sender)
        {
            sourceButton = (Button)Sender;
        }

        public bool MovePattern(Figure figure)
        {
            bool flag = false;
            if (Column == figure.GetColumn())
                if (Row > figure.GetRow())
                    for (int i = Row; i > figure.GetRow(); i--)
                    {
                        Button button = GetFigureFromGrid(i, figure.GetColumn());
                        if (button == null)
                            flag = true;
                        else return false;
                    }
                else
                    for (int i = Row; i < figure.GetRow(); i++)
                    {
                        Button button = GetFigureFromGrid(i, figure.GetColumn());
                        if (button == null)
                            flag = true;
                        else return false;
                    }

            else if (Row == figure.GetRow())
                if (Column > figure.GetColumn())
                    for (int i = Column; i > figure.GetColumn(); i--)
                    {
                        Button button = GetFigureFromGrid(figure.GetRow(), i);
                        if (button == null)
                            flag = true;
                        else return false;
                    }
                else
                    for (int i = Column; i < figure.GetColumn(); i++)
                    {
                        Button button = GetFigureFromGrid(figure.GetRow(), i);
                        if (button == null)
                            flag = true;
                        else return false;
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
                //Move to an empty cell
                Replace(figure);
                sourceButton.Content = " ";
                return true;
            }
            else if (CanCapture(figure))
            {
                //Capture the opponent's piece
                grid.Children.Remove(targetButton);
                Replace(figure);
                sourceButton.Content = " ";
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
