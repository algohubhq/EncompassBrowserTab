using EllieMae.Encompass.Client;
using System;

namespace EncompassBrowserTab.Objects.Interface
{
    public interface IDataExchangeReceived
    {
        void DataExchangeReceived(object sender, DataExchangeEventArgs e);
    }
}
