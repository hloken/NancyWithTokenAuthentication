using Nancy;

namespace NancyWithTokenAuthentication.Web
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters => Response.AsFile("index.html");
        }
    }
}