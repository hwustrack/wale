using System.Threading;
using System.Threading.Tasks;

namespace Library.Clients
{
    /// <summary>
    /// Interface for a client that runs various functions.
    /// </summary>
    public interface IWebAccessibleLibraryClient
    {
        /// <summary>
        /// Make a request to the default Azure Function.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>A greeting</returns>
        Task<string> Function1(CancellationToken cancellationToken);

        /// <summary>
        /// Make a request to Azure Functions to get the most frequent element in the given array using linq.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The most frequent element in the given array</returns>
        Task<int> GetMostFrequentElementInArrayLinq(int[] nums, CancellationToken cancellationToken);
    }
}