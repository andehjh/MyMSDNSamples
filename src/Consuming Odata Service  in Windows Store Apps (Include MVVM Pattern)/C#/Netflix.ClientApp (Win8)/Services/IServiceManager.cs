// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceManager.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the service manager interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Services
{
    using System.Collections;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the service manager interface
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// Loads the new dvd movies async.
        /// </summary>
        /// <returns>
        /// Represents an asynchronous operation that return a IEnumerable.
        /// </returns>
        Task<IEnumerable> LoadNewDVDMoviesAsync();

        /// <summary>
        /// Loads the top dvd movies async.
        /// </summary>
        /// <returns>Represents an asynchronous operation that return a IEnumerable.</returns>
        Task<IEnumerable> LoadTopDVDMoviesAsync();
    }
}
