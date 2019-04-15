using System.Threading;
using System.Threading.Tasks;

namespace Library.Clients
{
    public interface IWebAccessibleLibraryClient
    {
        Task<string> Function1(CancellationToken cancellationToken);

        Task<int> GetMostFrequentElementInArrayLinq(int[] nums, CancellationToken cancellationToken);
    }
}