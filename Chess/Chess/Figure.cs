using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Chess
{
    public enum Color
    {
        [Description("white")]
        White,
        [Description("black")]
        Black,
        [Description("void")]
        Void
    }

    public static class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return value.ToString();
        }

        public static Color GetTypeFromDescription(string description)
        {
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                string typeDescription = GetDescription(color);
                if (typeDescription == description)
                {
                    return color;
                }
            }
            throw new ArgumentException("No matching enum value found for the given description.");
        }
    }

    public abstract class Figure
    {
        protected string Name { get; set; }
        protected int Row { get; set; }
        protected int Column { get; set; }
        protected Color Color { get; set; }
        protected object Sender { get; set; }
        protected Button button { get; set; }
        protected Grid grid { get; set; }
         
        public Figure(int row, int column, Color color, object sender)
        {
            button = (Button)sender;
            Row = row;
            Column = column;
            Color = color;
            Sender = sender;
            grid = (Grid)button.Parent;
            string[] value = button.Name.Trim().Split('_');
            Name = value[0];
        }

        public string GetName() { return Name; }
        public int GetRow() { return Row; }
        public int GetColumn() { return Column; }
        public Color GetColor() { return Color; }
        public object GetSender() { return Sender; }

        public abstract bool CanMove(Figure figure);
        public abstract bool CanCapture(Figure figure);
        public abstract bool PerformMove(Figure figure);

        public void Replace(Figure figure)
        {
            grid.Children.Remove(button);
            Grid.SetRow(button, figure.GetRow());
            Grid.SetColumn(button, figure.GetColumn());
            grid.Children.Add(button);
        }

        //Helper method to get a button from the Grid based on its position
        public Button GetFigureFromGrid(int row, int column)
        {
            foreach (UIElement element in grid.Children)
            {
                if (element is Button button && Grid.GetRow(button) == row && Grid.GetColumn(button) == column)
                {
                    string clickValue = button.Name.ToString(); // pawn_white_1
                    string[] nameInfo = clickValue.Trim().Split('_');
                    if (button != this.button && EnumHelper.GetTypeFromDescription(nameInfo[1]) != Color.Void)
                        return button;
                }
            }
            return null; // Button not found
        }
    }
}

