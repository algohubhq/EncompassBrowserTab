using EncompassBrowserTab.Objects.Models;

namespace EncompassBrowserTab.Objects.Interface
{
    public interface IAnalysisBase
    {
        AnalysisResult Execute();
        AnalysisResult Search(string Search);
        //object GetObjectsToSearch();
    }
}
