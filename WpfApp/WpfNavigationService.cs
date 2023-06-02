using System.Collections.Generic;
using System.Reflection;

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

        public void ShowWindow( string name, IDictionary<string, object>? parameters = null )
        {
            if ( !_windows.TryGetValue( name, out var window ) )
            {
                window = Routing.GetOrCreateWindow( name, _serviceProvider );
                if ( window is null ) return;
                _windows.Add( name, window );
                window.Closed += ( s, e ) => _windows.Remove( name );
            }

            if ( parameters is not null )
            {
                SetParameters( window, parameters );
                if ( window.DataContext is not null )
                    SetParameters( window.DataContext, parameters );
            }

            window.Show();
            window.BringIntoView();
            window.Activate();
        }

        private void SetParameters( object instance, IDictionary<string, object> parameters )
        {
            ( instance as IQueryAttributable )?.ApplyQueryAttributes( parameters );

            var type = instance.GetType();

            foreach ( var qpa in type.GetCustomAttributes<QueryPropertyAttribute>() )
            {
                var prop = type.GetProperty( qpa.Name );
                if ( prop is not null && prop.CanWrite && parameters.TryGetValue( qpa.QueryId, out var value ) && value.GetType().IsAssignableTo( prop.PropertyType ) )
                    prop.SetValue( instance, value );
            }
        }
    }
}
