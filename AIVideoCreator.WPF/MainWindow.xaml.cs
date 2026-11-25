using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AIVideoCreator.WPF.ViewModels;



namespace AIVideoCreator.WPF
{

    public partial class MainWindow : Window
    {

        private int Counter { get; set; } = 1;


        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }


        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;

            viewModel.Projects.Add($"new project {Counter}");

            Counter++;
        }
    }
}