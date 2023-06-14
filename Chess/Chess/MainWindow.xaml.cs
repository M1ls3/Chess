using System.Data.Common;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

// Питання.
// 1. Фігури мають ходии.
// 2. Фігури мають перевіряти як саме ходити

namespace Chess
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static void Menu()
        {
            if (MessageBox.Show("Want to start a game of Chess?", "Menu", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            {
                Application.Current.Shutdown();
            }
        }

        Figure[] figures = null;

        public MainWindow()
        {
            figures = new Figure[2];
            InitializeComponent();
        }


        //public void Show(Figure figure)
        //{
        //    string output = $"Pos: [1] {figure.ToString()}\n";
        //    MessageBox.Show($"{output}");
        //    figures = new Figure[2];

        //    //figures[0].PerformMove(figures[1]);
        //}

        private void Pawn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString(); // pawn_white_1
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Pawn pawn = new Pawn(row, column, color, sender);
            if (figures[0] == null)
            {
                figures[0] = pawn;
            }
            else if (figures[1] == null)
            {
                figures[1] = pawn;
                figures[0].PerformMove(figures[1]);
                figures = new Figure[2];
                //Show();
            }
        }

        private void Rook_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Rook rook = new Rook(row, column, color, sender);
            if (figures[0] == null)
            {
                figures[0] = rook;
            }
            else if (figures[1] == null)
            {
                figures[1] = rook;
                figures[0].PerformMove(figures[1]);
                figures = new Figure[2];
                //Show();
            }
        }

        private void Knight_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Knight knight = new Knight(row, column, color, sender);
            if (figures[0] == null)
            {
                figures[0] = knight;
            }
            else if (figures[1] == null)
            {
                figures[1] = knight;
                figures[0].PerformMove(figures[1]);
                figures = new Figure[2];
                //Show();
            }
        }

        private void Bishop_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Bishop bishop = new Bishop(row, column, color, sender);
            if (figures[0] == null)
            {
                figures[0] = bishop;
            }
            else if (figures[1] == null)
            {
                figures[1] = bishop;
                figures[0].PerformMove(figures[1]);
                //Show();
                figures = new Figure[2];
            }
        }

        private void Queen_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Queen queen = new Queen(row, column, color, sender);
            if (figures[0] == null)
            {
                figures[0] = queen;
            }
            else if (figures[1] == null)
            {
                figures[1] = queen;
                figures[0].PerformMove(figures[1]);
                figures = new Figure[2];
                //Show();
            }
        }

        private void King_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            King king = new King(row, column, color, sender);
            if (figures[0] == null)
            {

                figures[0] = king;
            }
            else if (figures[1] == null)
            {
                figures[1] = king;
                figures[0].PerformMove(figures[1]);
                figures = new Figure[2];
                //Show();
            }
        }

        private void Void_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            CellVoid cellVoid = new CellVoid(row, column, color, sender);

            if (figures[0] == null)
            {
                figures = new Figure[2];
            }
            else if (figures[1] == null)
            {
                figures[1] = cellVoid;
                figures[0].PerformMove(figures[1]);
                figures = new Figure[2];
                //Show();
            }
        }
    }
}

