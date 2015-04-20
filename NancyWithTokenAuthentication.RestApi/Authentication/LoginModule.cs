using Nancy;

namespace NancyWithTokenAuthentication.Authentication
{
    public class LoginModule : NancyModule
    {
        public LoginModule() : 
            base("api/login")
        {

        }
    }
}
