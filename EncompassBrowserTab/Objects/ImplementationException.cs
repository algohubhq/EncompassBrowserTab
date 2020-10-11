using System;

namespace EncompassBrowserTab.Objects
{
    public class ImplementationException: Exception
    {
        public ImplementationException(string EventType, string EventName, string Interface)
        : base($"{EventType} Must Implment {EventName} for {Interface}")
        { }
    }
}
