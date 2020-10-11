using Newtonsoft.Json;
using System.Collections.Generic;

namespace EncompassBrowserTab.Objects.Models
{
    public class RuleLockCDO
    {
        [JsonProperty("Rules")]
        public List<RuleLockInfo> Rules { get; set; }
    }
}
