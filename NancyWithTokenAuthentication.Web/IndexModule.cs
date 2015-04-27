using Nancy;

namespace NancyWithTokenAuthentication.Web
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
            : base("")
        {

            Get["/"] = parameters => GetReponse(parameters);
        }

        private Response GetReponse(dynamic parameters)
        {
            return Response.AsFile("index.html");
        }
    }
}