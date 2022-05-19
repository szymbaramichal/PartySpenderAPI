using ServiceStack;
using PartySpenderAPI.ServiceModel;

namespace PartySpenderAPI.ServiceInterface;

public class MyServices : Service
{
    public object Any(Hello request)
    {
        return new HelloResponse { Result = $"Hello, {request.Name}!" };
    }
}