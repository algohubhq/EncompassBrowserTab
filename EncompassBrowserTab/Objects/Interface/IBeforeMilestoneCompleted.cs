using EllieMae.Encompass.BusinessObjects.Loans;

namespace EncompassBrowserTab.Objects.Interface
{
    public interface IBeforeMilestoneCompleted
    {
        void BeforeMilestoneCompleted(object sender, CancelableMilestoneEventArgs e);
    }
}
