using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exceptionless.Models;
using Exceptionless.Plugins;

namespace AspNetMvc5Client.Plugins
{
    [Priority(100)]
    public class LogSubmissionPlugin : IEventPlugin
    {
        public void Run(EventPluginContext context)
        {
            var enableLogSubmission = context.Client.Configuration.Settings.GetBoolean("enableLogSubmission", true);

            if (context.Event.Type == Event.KnownTypes.Log && !enableLogSubmission)
            {
                context.Cancel = true;
            }
        }
    }
}