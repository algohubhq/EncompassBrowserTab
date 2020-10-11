using Newtonsoft.Json;
using System.Collections.Generic;

namespace EncompassBrowserTab.Objects.Models
{
    public class AutoMailerCDORoot
    {
        [JsonProperty("Triggers")]
        public List<MailTrigger> Triggers { get; set; }

        public AutoMailerCDORoot()
        {
            Triggers = new List<MailTrigger>();
        }
    }
}
