using System.Collections.Generic;

namespace EncompassBrowserTab.Objects.Interface
{
    public interface IFactory
    {
        List<ITask> GetTriggers();
    }
}
