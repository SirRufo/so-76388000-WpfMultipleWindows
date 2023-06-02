using System.Globalization;
using System.Reflection;
using System.Windows.Markup;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof( FrameworkElement ),
                new FrameworkPropertyMetadata( XmlLanguage.GetLanguage( CultureInfo.CurrentCulture.IetfLanguageTag ) ) );
        }

        public static string Company => Assembly.GetEntryAssembly()!.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company ?? string.Empty;
        public static string Copyright => Assembly.GetEntryAssembly()!.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? string.Empty;
        public static string Description => Assembly.GetEntryAssembly()!.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? string.Empty;
        public static string FileVersion => Assembly.GetEntryAssembly()!.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version ?? string.Empty;
        public static string InformationalVersion => Assembly.GetEntryAssembly()!.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "unknown";
        public static string Product => Assembly.GetEntryAssembly()!.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? string.Empty;
        public static string Title => Assembly.GetEntryAssembly()!.GetCustomAttribute<AssemblyTitleAttribute>()?.Title ?? string.Empty;
        public static string Trademark => Assembly.GetEntryAssembly()!.GetCustomAttribute<AssemblyTrademarkAttribute>()?.Trademark ?? string.Empty;
        public static string Version => Assembly.GetEntryAssembly()!.GetCustomAttribute<AssemblyVersionAttribute>()?.Version ?? string.Empty;
    }
}