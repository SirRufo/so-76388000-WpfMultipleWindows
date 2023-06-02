using System.Collections.Generic;

namespace WpfApp.Interfaces
{
    public interface INavigationService
    {
        void ShowWindow( string name, IDictionary<string, object>? parameters = null );
    }
}
