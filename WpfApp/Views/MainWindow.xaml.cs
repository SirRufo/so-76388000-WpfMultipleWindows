namespace WpfApp.Views
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow( MainWindowViewModel viewModel )
        {
            InitializeComponent();
            DataContext = viewModel;
            Loaded += async ( s, e ) => await viewModel.InitializeAsync();
        }
    }
}
