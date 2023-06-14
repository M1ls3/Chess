using System.Windows;
using System.Windows.Controls;

namespace Chess
{
    public class Rook : Figure
    {
        //public bool HasMoved { get; set; }
        protected Button sourceButton { get; set; }
        protected Grid grid { get; set; }

        public Rook(int row, int column, Color color, object sender) : base(row, column, color, sender)
        {
            //HasMoved = false;
            sourceButton = (Button)Sender;
            grid = (Grid)sourceButton.Parent;
        }

        private bool MovePatern(Figure figure)
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
                if (MovePatern(figure))
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
                if (MovePatern(figure))
                {
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
                //Move the pawn to an empty cell
                grid.Children.Remove(sourceButton);
                Grid.SetRow(sourceButton, figure.GetRow());
                Grid.SetColumn(sourceButton, figure.GetColumn());
                grid.Children.Add(sourceButton);
            }
            else if (CanCapture(figure))
            {
                //Capture the opponent's piece
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
                    if (button != sourceButton && EnumHelper.GetTypeFromDescription(nameInfo[1]) != Color.Void)
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
