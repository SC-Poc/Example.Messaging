using Swisschain.Examples.Publisher.ApiClient.Common;
using Swisschain.Examples.Publisher.ApiContract;

namespace Swisschain.Examples.Publisher.ApiClient
{
    public class PublisherClient : BaseGrpcClient, IPublisherClient
    {
        public PublisherClient(string serverGrpcUrl) : base(serverGrpcUrl)
        {
            Monitoring = new Monitoring.MonitoringClient(Channel);
        }

        public Monitoring.MonitoringClient Monitoring { get; }
    }
}
