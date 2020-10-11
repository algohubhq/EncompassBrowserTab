using EncompassBrowserTab.Objects.Enums;
using System;

namespace EncompassBrowserTab.Objects.Models
{
    public class EncompassLog
    {
        public DateTime? TimeStamp { get; set; }
        public EncompassLogType Type { get; set; }
        public string Message { get; set; }
    }
}
