
namespace WpfApp.ViewModels
{
    [QueryProperty( nameof( Name ), "SomeValue" )]
    public class FooWindowViewModel : ViewModelBase
    {
        [Reactive] public string Name { get; set; } = string.Empty;
    }
}