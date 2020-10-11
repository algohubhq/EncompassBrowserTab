using EllieMae.Encompass.BusinessObjects;

namespace EncompassBrowserTab.Objects.Interface
{
    public interface ICommitted
    {
        void Committed(object sender, PersistentObjectEventHandler e);
    }
}
