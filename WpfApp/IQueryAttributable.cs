using System.Collections.Generic;

namespace WpfApp
{
    public interface IQueryAttributable
    {
        void ApplyQueryAttributes( IDictionary<string, object> query );
    }
}
