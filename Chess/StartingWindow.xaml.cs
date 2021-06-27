using System.Windows;

namespace Chess
{
    /// <summary>
    /// Interaction logic for StartingWindow.xaml
    /// </summary>
    public partial class StartingWindow : Window
    {
        public StartingWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (hvh.IsChecked == true)
            {
                MainWindow.mode = Mode.with_Human;
                MainWindow.user_mode = "white";
            }
            else if (hvc.IsChecked == true)
            {
                MainWindow.mode = Mode.with_Computer;
                MainWindow.user_mode = "white";
            }
            else if (cvh.IsChecked == true)
            {
                MainWindow.mode = Mode.with_Computer;
                MainWindow.user_mode = "black";
            }

            this.Visibility = Visibility.Collapsed;
            MainWindow m = new MainWindow();
            m.ShowDialog();

        }
    }
}
