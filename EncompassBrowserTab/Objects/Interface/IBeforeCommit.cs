using EllieMae.Encompass.BusinessObjects.Loans;

namespace EncompassBrowserTab.Objects.Interface
{
    public interface IBeforeCommit
    {
        void BeforeCommit(object sender, CancelableEventArgs e);
    }
}
