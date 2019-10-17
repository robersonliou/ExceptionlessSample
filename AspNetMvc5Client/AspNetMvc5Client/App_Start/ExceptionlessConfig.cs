using AspNetMvc5Client.Plugins;
using Exceptionless;
using Exceptionless.Models;

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

            //AddLogSubmissionPlugin();
            config.AddPlugin<LogSubmissionPlugin>();
        }

        private static void AddLogSubmissionPlugin()
        {
            ExceptionlessClient.Default.Configuration.AddPlugin("cancel log submission", 100, context =>
            {
                var enableLogSubmission = context.Client.Configuration.Settings.GetBoolean("enableLogSubmission", true);

                if (context.Event.Type == Event.KnownTypes.Log && !enableLogSubmission)
                {
                    context.Cancel = true;
                }
            });
        }
    }
}