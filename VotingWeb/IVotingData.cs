using Microsoft.ServiceFabric.Services.Remoting;
using System.Threading.Tasks;

namespace VotingDataInterface
{
    public interface IVotingData : IService
    {
        Task<string> Echo(string caller);
    }
}
