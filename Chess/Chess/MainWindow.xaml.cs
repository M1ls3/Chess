using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess
{
    public partial class MainWindow : Window
    {
        Figure[] figures = null;
        bool IsWhiteToMove = true;
        bool IsWining = false;

        public MainWindow()
        {
            figures = new Figure[2];
            IsWhiteToMove = true;
            InitializeComponent();
        }

        public void FigureHandler(Figure figure)
        {
            if (figures[0] == null)
            {
                if ((IsWhiteToMove && figure.GetColor() == Color.White) || (!IsWhiteToMove && figure.GetColor() == Color.Black))
                    figures[0] = figure;
            }
            else if (figures[1] == null)
            {
                figures[1] = figure;
                if (figures[0].PerformMove(figures[1])) // 
                {
                    if (figures[0].GetType().ToString() == "Chess.Pawn" && (figures[1].GetRow() < 1 || figures[1].GetRow() > 6))
                    {
                        PromoteToQueen();
                    }
                    IsWining = IsWin();
                    IsWhiteToMove = !IsWhiteToMove;
                }
                if (!IsWining)
                {
                    figures = new Figure[2];
                }
            }
        }

        public void PromoteToQueen()
        {
            object sender = figures[0].GetSender();
            Button button = (Button)sender;
            button.Click -= Pawn_Click;
            button.Click += Queen_Click;
            string imagePath;
            if (figures[0].GetColor() == Color.White)
                imagePath = "../queen_white.png";
            else
                imagePath = "../queen_black.png";
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            button.Background = imageBrush;
        }

        public bool IsWin() // Check for winning
        {
            if (figures[1].GetName() == "king" && figures[1].GetColor() == Color.White)
            {
                Menu menu = new Menu("black");
                menu.Show();
                return true;
            }
            else if (figures[1].GetName() == "king" && figures[1].GetColor() == Color.Black)
            {
                Menu menu = new Menu("white");
                menu.Show();
                return true;
            }
            return false;
        }

        private void Pawn_Click(object sender, RoutedEventArgs e) // Pawn
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString(); // pawn_white_1
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Pawn pawn = new Pawn(row, column, color, sender);
            FigureHandler(pawn);
        }

        private void Rook_Click(object sender, RoutedEventArgs e) // Rook
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Rook rook = new Rook(row, column, color, sender);
            FigureHandler(rook);
        }

        private void Knight_Click(object sender, RoutedEventArgs e) // Knight
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Knight knight = new Knight(row, column, color, sender);
            FigureHandler(knight);
        }

        private void Bishop_Click(object sender, RoutedEventArgs e) // Bishop
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Bishop bishop = new Bishop(row, column, color, sender);
            FigureHandler(bishop);
        }

        private void Queen_Click(object sender, RoutedEventArgs e) // Queen
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Queen queen = new Queen(row, column, color, sender);
            FigureHandler(queen);
        }

        private void King_Click(object sender, RoutedEventArgs e) // King
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            King king = new King(row, column, color, sender);
            FigureHandler(king);
        }

        private void Void_Click(object sender, RoutedEventArgs e) // Void
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            CellVoid cellVoid = new CellVoid(row, column, color, sender);
            FigureHandler(cellVoid);
        }

        private void IsClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

