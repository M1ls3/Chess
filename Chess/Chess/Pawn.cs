using System.Windows.Controls;

namespace Chess
{
    public class Pawn : Figure
    {
        public Pawn(int row, int column, Color color, object sendler) : base(row, column, color, sendler) { }

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

        public override bool PerformMove(Figure figure)
        {
            Button targetButton = (Button)figure.GetSender();

            if (CanMove(figure))
            {
                // Move the pawn to an empty cell
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
