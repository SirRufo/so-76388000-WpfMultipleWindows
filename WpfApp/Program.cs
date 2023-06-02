// Create a builder by specifying the application and main window.
using WpfApp;
using WpfApp.Interfaces;

var builder = WpfApplication<App, MainWindow>.CreateBuilder( args );

// Configure dependency injection.
// Injecting MainWindowViewModel into MainWindow.
builder.Services
    .AddSingleton<INavigationService, WpfNavigationService>()

    .AddTransient<MainWindowViewModel>()
    .AddTransient<FooWindow>().AddTransient<FooWindowViewModel>()
    .AddTransient<BarWindow>().AddTransient<BarWindowViewModel>()
    ;


Routing.RegisterWindow( "foo", typeof( FooWindow ) );
Routing.RegisterWindow( "bar", typeof( BarWindow ) );

// Configure the settings.
// Injecting IOptions<MySettings> from appsetting.json.
/*
builder.Services.Configure<MySettings>( builder.Configuration.GetSection( "MySettings" ) );
*/

// Configure logging.
// Using the diagnostic logging library Serilog.
/*
builder.Host.UseSerilog( ( hostingContext, services, loggerConfiguration ) => loggerConfiguration
    .ReadFrom.Configuration( hostingContext.Configuration )
    .Enrich.FromLogContext()
    .WriteTo.Debug()
    .WriteTo.File(
        @"Logs\log.txt",
        rollingInterval: RollingInterval.Day ) );
*/

var app = builder.Build();

await app.RunAsync();