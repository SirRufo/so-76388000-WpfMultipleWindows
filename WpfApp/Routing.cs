using System.Collections.Generic;

namespace WpfApp
{
    public static class Routing
    {
        private static readonly Dictionary<string, Type> _windows = new();
        public static void RegisterWindow( string name, Type type )
        {
            _windows.Add( name, type );
        }

        public static Window? GetOrCreateWindow( string name, IServiceProvider serviceProvider )
        {
            Window? result = null;

            if ( _windows.TryGetValue( name, out var windowType ) )
                result = serviceProvider.GetService( windowType ) as Window;

            return result;
        }

    }
}

