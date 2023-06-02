namespace WpfApp.Views
{
    /// <summary>
    /// Interaktionslogik für FooWindow.xaml
    /// </summary>
    public partial class FooWindow : Window
    {
        public FooWindow( FooWindowViewModel viewModel )
        {
            InitializeComponent();
            DataContext = viewModel;
            Loaded += async ( s, e ) => await viewModel.InitializeAsync();
        }
    }
}
