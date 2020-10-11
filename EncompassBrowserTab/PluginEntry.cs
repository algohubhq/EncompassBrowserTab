using EncompassBrowserTab.Objects;
using EncompassBrowserTab.Objects.Dependencies;
using EllieMae.Encompass.ComponentModel;

namespace EncompassBrowserTab
{
    [Plugin]
    public class PluginEntry
    {
        public PluginEntry()
        {

            DependencyLoader.LoadDependencies();

            Plugins.Start();
        }
    }
}
