// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogManager.cs" company="saramgsilva">
//   Copyright (c) 2013 saramgsilva. All rights reserved. 
// </copyright>
// <summary>
//   Defines the ILogManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace AuthenticationSample.UniversalApps.Services.Interfaces
{
    /// <summary>
    /// The LogManager interface.
    /// </summary>
    public interface ILogManager
    {
        /// <summary>
        /// The init.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        void Init(string key);

        /// <summary>
        /// The log method.
        /// </summary>
        /// <param name="e">
        /// The exception got.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> object.
        /// </returns>
        Task LogAsync(Exception e);

        /// <summary>
        /// The close async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> object.
        /// </returns>
        Task CloseAsync();
    }
}
