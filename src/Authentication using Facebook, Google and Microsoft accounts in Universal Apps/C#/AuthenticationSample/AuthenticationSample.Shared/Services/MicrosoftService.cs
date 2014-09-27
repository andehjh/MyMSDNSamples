// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MicrosoftService.cs" company="saramgsilva">
//   Copyright (c) 2013 saramgsilva. All rights reserved. 
// </copyright>
// <summary>
//   Defines the MicrosoftService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Live;
using AuthenticationSample.UniversalApps.Services.Interfaces;
using AuthenticationSample.UniversalApps.Services.Model;

// ReSharper disable once CheckNamespace
namespace AuthenticationSample.UniversalApps.Services
{
    /// <summary>
    /// The microsoft service.
    /// </summary>
    public class MicrosoftService : IMicrosoftService
    {
        private readonly ILogManager _logManager;
        private LiveAuthClient _authClient;
        private LiveConnectSession _liveSession;


        /// <summary>
        /// Defines the scopes the application needs.
        /// </summary>
        private List<string> _scopes;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MicrosoftService"/> class.
        /// </summary>
        /// <param name="logManager">
        /// The log manager.
        /// </param>
        public MicrosoftService(ILogManager logManager)
        {
            _scopes = new List<string> { "wl.signin", "wl.basic", "wl.offline_access" };
            _logManager = logManager;
        }

        /// <summary>
        /// The login async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> object.
        /// </returns>
        public async Task<Session> LoginAsync()
        {

            Exception exception = null;
            try
            {
                _authClient = new LiveAuthClient();
                var loginResult = await _authClient.InitializeAsync(_scopes);
                var result = await _authClient.LoginAsync(_scopes);
                if (result.Status == LiveConnectSessionStatus.Connected)
                {
                    _liveSession = loginResult.Session;
                    var session = new Session
                    {
                        AccessToken = result.Session.AccessToken,
                        Provider = Constants.MicrosoftProvider,
                    };

                    return session;
                }

            }
            catch (LiveAuthException ex)
            {
                throw new InvalidOperationException("Login canceled.", ex);
            }

            catch (Exception e)
            {
                exception = e;
            }
             await _logManager.LogAsync(exception);

            return null;
        }

        /// <summary>
        /// The get user info.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> object.
        /// </returns>
        public async Task<IDictionary<string, object>> GetUserInfo()
        {

            Exception exception = null;
            try
            {   
                var liveClient = new LiveConnectClient(_liveSession);
                LiveOperationResult operationResult = await liveClient.GetAsync("me");

                return operationResult.Result;
            }
            catch (LiveConnectException e)
            {
                exception = e;
            }
            await _logManager.LogAsync(exception);

            return null;
        }

        /// <summary>
        /// The logout.
        /// </summary>
        public async void Logout()
        {
 
            if (_authClient == null)
            {
                _authClient = new LiveAuthClient();
                var loginResult = await _authClient.InitializeAsync(_scopes);
            }
            if (_authClient.CanLogout)
            {
                _authClient.Logout();
            }
        }
    }
}
