using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

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
        protected int X { get; set; }
        protected int Y { get; set; }
        protected Color Color { get; set; }
        protected object Sender { get; set; }

        public Figure(int x, int y, Color color, object sender)
        {
            Button button = (Button)sender;
            X = x;
            Y = y;
            Color = color;
            Sender = sender;
        }

        public int GetRow()
        {
            return X;
        }

        public int GetColumn()
        {
            return Y;
        }

        public Color GetColor()
        {
            return Color;
        }

        public object GetSendler()
        {
            return Sender;
        }

        public abstract bool CanMove(int targetX, int targetY, bool capturing);
        public abstract bool CanCapture(int targetX, int targetY);
        public abstract void PerformMove(Figure figure);
    }
}
