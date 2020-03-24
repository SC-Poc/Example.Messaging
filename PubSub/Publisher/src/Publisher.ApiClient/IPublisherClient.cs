using Swisschain.Examples.Publisher.ApiContract;

namespace Swisschain.Examples.Publisher.ApiClient
{
    public interface IPublisherClient
    {
        Monitoring.MonitoringClient Monitoring { get; }
    }
}
