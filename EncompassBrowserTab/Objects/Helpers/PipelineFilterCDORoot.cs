using EncompassBrowserTab.Objects.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EncompassBrowserTab.Objects.Helpers
{
    public class PipelineFilterCDORoot
    {
        [JsonProperty("Filters")]
        public List<PipelineFilter> Filters { get; set; }

        public PipelineFilterCDORoot()
        {
            Filters = new List<PipelineFilter>();
        }
    }
}
