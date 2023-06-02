using System.Collections.Generic;

using WpfApp.Interfaces;

namespace WpfApp
{
    internal class WpfNavigationService : INavigationService
    {
        private readonly IDictionary<string, Window> _windows = new Dictionary<string, Window>();
        private readonly IServiceProvider _serviceProvider;

        public WpfNavigationService( IServiceProvider serviceProvider )
        {
            _serviceProvider = serviceProvider;
        }

        public void ShowWindow( string name )
        {
            if ( !_windows.TryGetValue( name, out var window ) )
            {
                window = Routing.GetOrCreateWindow( name, _serviceProvider );
                if ( window is null ) return;
                _windows.Add( name, window );
                window.Closed += ( s, e ) => _windows.Remove( name );
            }
            window.Show();
            window.BringIntoView();
            window.Activate();
        }

    }
}
