using PartySpenderAPI.ServiceModel.Users;
using ServiceStack;

namespace PartySpenderAPI.ServiceModel.Auths;

[Route("/auths/register","POST")]
public class Register : IReturn<UserDTO>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}

[Route("/auths/login", "POST")]
public class Login : IReturn<UserDTO>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
