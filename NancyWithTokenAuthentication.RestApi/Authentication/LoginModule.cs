using Nancy;

namespace NancyWithTokenAuthentication.RestApi.Authentication
{
    public class LoginModule : NancyModule
    {
        public LoginModule() : 
            base("api/login")
        {
            //Post["/loginUser"] =>  
        }
    }
}
