using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

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
            //Menu();
            figures = new Figure[2];
            InitializeComponent();
        }

        public void Show()
        {
            string output = $"[1] {figures[0].ToString()} \n[2] {figures[1].ToString()}";
            MessageBox.Show($"{output}");
            figures = new Figure[2];

            //figures[0].PerformMove(figures[1]);
        }

        private void Pawn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string clickValue = button.Name.ToString();
            string[] nameInfo = clickValue.Trim().Split('_');
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            Color color = EnumHelper.GetTypeFromDescription(nameInfo[1]);

            Pawn pawn = new Pawn(row, column, color);
            if (figures[0] == null)
            {
                figures[0] = pawn;
            }
            else if (figures[1] == null)
            {
                figures[1] = pawn;
                Show();
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

            Rook rook = new Rook(row, column, color);
            if (figures[0] == null)
            {
                figures[0] = rook;
            }
            else if (figures[1] == null)
            {
                figures[1] = rook;
                Show();
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

            Knight knight = new Knight(row, column, color);
            if (figures[0] == null)
            {
                figures[0] = knight;
            }
            else if (figures[1] == null)
            {
                figures[1] = knight;
                Show();
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

            Bishop bishop = new Bishop(row, column, color);
            if (figures[0] == null)
            {
                figures[0] = bishop;
            }
            else if (figures[1] == null)
            {
                figures[1] = bishop;
                Show();
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

            Queen queen = new Queen(row, column, color);
            if (figures[0] == null)
            {
                figures[0] = queen;
            }
            else if (figures[1] == null)
            {
                figures[1] = queen;
                Show();
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

            King king = new King(row, column, color);
            if (figures[0] == null)
            {
                figures[0] = king;
            }
            else if (figures[1] == null)
            {
                figures[1] = king;
                Show();
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

            CellVoid cellVoid = new CellVoid(row, column, color);
            if (figures[0] == null)
            {
                figures = new Figure[2];
            }
            else if (figures[1] == null)
            {
                figures[1] = cellVoid;
                Show();
            }
        }
    }
}
