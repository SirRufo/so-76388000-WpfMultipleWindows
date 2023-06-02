
using System.Collections.Generic;

namespace WpfApp.ViewModels
{
    public class BarWindowViewModel : ViewModelBase, IQueryAttributable
    {
        [Reactive] public string ReadOnlyName { get; private set; } = string.Empty;
        public void ApplyQueryAttributes( IDictionary<string, object> query )
        {
            ReadOnlyName = query.TryGetValue( "SomeValue", out var val ) ? val as string ?? string.Empty : string.Empty;
        }
    }
}