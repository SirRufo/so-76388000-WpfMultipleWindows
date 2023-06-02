namespace WpfApp.Views
{
    /// <summary>
    /// Interaktionslogik für BarWindow.xaml
    /// </summary>
    public partial class BarWindow : Window
    {
        public BarWindow( BarWindowViewModel viewModel )
        {
            InitializeComponent();
            DataContext = viewModel;
            Loaded += async ( s, e ) => await viewModel.InitializeAsync();
        }
    }
}
