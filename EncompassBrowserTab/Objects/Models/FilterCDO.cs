﻿using EllieMae.EMLite.ClientServer.Reporting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EncompassBrowserTab.Objects.Models
{
    public class FilterCDO
    {
        [JsonProperty("Filters")]
        public List<FieldFilter> Filters { get; set; }
    }
}
