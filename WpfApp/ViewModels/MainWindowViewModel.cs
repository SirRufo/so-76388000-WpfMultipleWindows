using System.Reactive;

using WpfApp.Interfaces;

namespace WpfApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ReactiveCommand<string, Unit> ShowWindowCommand { get; }

        public MainWindowViewModel( INavigationService navigationService )
        {
            _navigationService = navigationService;

            ShowWindowCommand = ReactiveCommand.Create<string>( OnShowWindow );
        }

        private void OnShowWindow( string name )
        {
            _navigationService.ShowWindow( name );
        }
    }
}