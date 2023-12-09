using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Chess
{
    public class Queen : Figure
    {
        protected Button sourceButton { get; set; }

        public Queen(int row, int column, Color color, object sender) : base(row, column, color, sender)
        {
            sourceButton = (Button)Sender;
        }

        private bool MovePattern(Figure figure)
        {
            bool flag = false;
            string clickValue = sourceButton.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_'); 
            int row = Grid.GetRow(sourceButton);
            int column = Grid.GetColumn(sourceButton);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Bishop bishop = new Bishop(row, column, color, Sender);
            Rook rook = new Rook(row, column, color, Sender);

            if (bishop.MovePattern(figure) || rook.MovePattern(figure))
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
