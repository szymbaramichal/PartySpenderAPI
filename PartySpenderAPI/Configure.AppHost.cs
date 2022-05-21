using Funq;
using ServiceStack;
using PartySpenderAPI.ServiceInterface;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using PartySpenderAPI.ServiceModel.Types;

[assembly: HostingStartup(typeof(PartySpenderAPI.AppHost))]

namespace PartySpenderAPI;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        });

    public AppHost() : base("PartySpenderAPI", typeof(PartiesService).Assembly) {}

    public override void Configure(Container container)
    {
        // Configure ServiceStack only IOC, Config & Plugins
        SetConfig(new HostConfig {
            UseSameSiteCookies = true,
        });

        container.Register<IDbConnectionFactory>(c =>
            new OrmLiteConnectionFactory("PartySpender.sqlite", SqliteDialect.Provider));
        using var db = container.Resolve<IDbConnectionFactory>().Open();
        db.DropAndCreateTable<Party>();
    }
}
