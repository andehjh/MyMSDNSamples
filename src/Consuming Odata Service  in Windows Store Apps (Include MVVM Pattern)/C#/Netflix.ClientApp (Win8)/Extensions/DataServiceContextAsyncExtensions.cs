// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataServiceContextAsyncExtensions.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the DataServiceContext Async Extensions
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Extensions
{
    using System.Collections.Generic;
    using System.Data.Services.Client;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the DataServiceContext Async Extensions
    /// </summary>
    public static class DataServiceContextAsyncExtensions
    {
        /// <summary>
        /// This extension method uses the Task-based Asynchronous Pattern (TAP)
        /// to allow the ServiceManager to execute an OData query without blocking the UI.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>the task of the enumerable of the type TResult</returns>
        public static async Task<IEnumerable<TResult>> ExecuteAsync<TResult>(this DataServiceQuery<TResult> query)
        {     
            return await Task.Factory.FromAsync<IEnumerable<TResult>>(query.BeginExecute(null, null), query.EndExecute);
        }
    }    
}