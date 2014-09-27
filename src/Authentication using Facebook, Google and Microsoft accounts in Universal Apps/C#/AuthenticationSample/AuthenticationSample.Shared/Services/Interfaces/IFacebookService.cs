// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFacebookService.cs" company="saramgsilva">
//   Copyright (c) 2013 saramgsilva. All rights reserved. 
// </copyright>
// <summary>
//   The FacebookService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using AuthenticationSample.UniversalApps.Services.Model;

namespace AuthenticationSample.UniversalApps.Services.Interfaces
{
    /// <summary>
    /// The FacebookService interface.
    /// </summary>
    public interface IFacebookService : ISessionProvider
    {
#if WINDOWS_PHONE_APP
        Task<Session> Finalize(Windows.ApplicationModel.Activation.WebAuthenticationBrokerContinuationEventArgs args);
#endif
    }
}
