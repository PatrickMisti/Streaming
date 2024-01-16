using Runner;
using Serilog;
using Topshelf;
using Topshelf.Runtime;

var _logger = new LoggerConfiguration()
    .ReadFrom.AppSettings()
    .CreateLogger();

var service = new CoreService();

try
{
    var host = HostFactory.New(x =>
    {
        // add services
        x.Service<CoreService>(s =>
        {
            s.ConstructUsing(name => service);
            s.WhenStarted(async tc => await tc.StartAsync());
            s.WhenStopped(tc => tc.Stop());
        });

        // add Serilog
        x.UnhandledExceptionPolicy = UnhandledExceptionPolicyCode.TakeNoAction;
        x.OnException(e => Log.Error(e, "Unexpected exception occurred!"));
        x.UseSerilog();

        // run as local network or service
        //x.RunAsLocalSystem();

        // set console options
        x.SetDisplayName("Runner");
        x.SetServiceName("Runner.Service");
        x.EnableShutdown();

        // add recovery option
        x.EnableServiceRecovery(r =>
        {
            r.RestartService(1);
            r.OnCrashOnly();
            r.SetResetPeriod(1);
        });

        x.StartManually();
    });

    host.Run();
} 
catch (Exception ex)
{
    Log.Error(ex, "Runner failed init!");
}