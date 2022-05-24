using ServiceStack;

[assembly: HostingStartup(typeof(PartySpenderAPI.ConfigureAutoQuery))]

namespace PartySpenderAPI
{
    public class ConfigureAutoQuery : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureAppHost(appHost => {
                appHost.Plugins.Add(new AutoQueryFeature {
                    MaxLimit = 1000,
                    //IncludeTotal = true,
                });
            });
    }
}