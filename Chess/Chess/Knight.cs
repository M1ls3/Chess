using System.Windows.Controls;

namespace Chess
{
    public class Knight : Figure
    {
        public Knight(int x, int y, Color color, object sender) : base(x, y, color, sender) { }

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
