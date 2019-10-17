using Exceptionless;

namespace AspNetMvc5Client
{
    public class ExceptionlessConfig
    {
        public static void Register()
        {
            var config = ExceptionlessClient.Default.Configuration;
            config.ApiKey = "your server api key";
            config.ServerUrl = "http://localhost:5000";
//            config.IncludePrivateInformation = false;
            config.UseSessions();
            config.SetVersion("1.2.3");
        }
    }
}