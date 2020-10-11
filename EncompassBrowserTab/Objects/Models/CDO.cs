using Newtonsoft.Json;

namespace EncompassBrowserTab.Objects.Models
{
    public class CDO
    {
        [JsonProperty("PluginSettings")]
        public SettingsCDO PluginSettings { get; set; }
    }
}
