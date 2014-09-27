// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company="saramgsilva">
//   Copyright (c) 2013 saramgsilva. All rights reserved. 
// </copyright>
// <summary>
//   The login view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using AuthenticationSample.UniversalApps.Services.Interfaces;
using Cimbalino.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using AuthenticationSample.UniversalApps.Views;
using Windows.ApplicationModel.Activation;

namespace AuthenticationSample.UniversalApps.ViewModel
{
    /// <summary>
    /// The login view model.
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILogManager _logManager;
        private readonly IMessageBoxService _messageBox;
        private readonly INetworkInformationService _networkInformationService;
        private readonly INavigationService _navigationService;
        private readonly ISessionService _sessionService;
        private bool _inProgress;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">
        /// The navigation service.
        /// </param>
        /// <param name="sessionService">
        /// The session service.
        /// </param>
        /// <param name="messageBox">
        /// The message box.
        /// </param>
        /// <param name="networkInformationService">
        /// The network connection.
        /// </param>
        /// <param name="logManager">
        /// The log manager.
        /// </param>
        public LoginViewModel(INavigationService navigationService,
            ISessionService sessionService,
            IMessageBoxService messageBox,
            INetworkInformationService networkInformationService,
            ILogManager logManager)
        {
            _navigationService = navigationService;
            _sessionService = sessionService;
            _messageBox = messageBox;
            _networkInformationService = networkInformationService;

            _logManager = logManager;
            LoginCommand = new RelayCommand<string>(LoginAction);
        }

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        /// <value>
        /// The navigation service.
        /// </value>
        public INavigationService NavigationService
        {
            get { return _navigationService; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether in progress.
        /// </summary>
        /// <value>
        /// The in progress.
        /// </value>
        public bool InProgress
        {
            get { return _inProgress; }
            set { Set(() => InProgress, ref _inProgress, value); }
        }

        /// <summary>
        /// Gets the facebook login command.
        /// </summary>
        /// <value>
        /// The facebook login command.
        /// </value>
        public ICommand LoginCommand { get; private set; }

        /// <summary>
        /// Facebook's login action.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        private async void LoginAction(string provider)
        {
            Exception exception = null;
            bool isToShowMessage = false;
            try
            {
                if (!_networkInformationService.IsNetworkAvailable)
                {
                    await _messageBox.ShowAsync("There isn´t network connection.",
                                          "Authentication Sample",
                                          new List<string> { "Ok" });
                    return;
                }
                if (Constants.GoogleClientId.Contains("<") || Constants.GoogleClientSecret.Contains("<"))
                {
                    await _messageBox.ShowAsync("Is missing the google client id and client secret. Search for Constant.cs file.",
                                         "Authentication Sample",
                                         new List<string> { "Ok" });
                    return;
                }
                if (Constants.FacebookAppId.Contains("<"))
                {
                    await _messageBox.ShowAsync("Is missing the facebook client id. Search for Constant.cs file.",
                                         "Authentication Sample",
                                         new List<string> { "Ok" });
                    return;
                }
                InProgress = true;
                var auth = await _sessionService.LoginAsync(provider);
                if (auth == null)
                {
                    return;
                }
                if (!auth.Value)
                {
                    await ShowMessage();
                }
                else
                {
                    _navigationService.Navigate<MainView>();
                    InProgress = false;
                }

                InProgress = false;
            }
            catch (Exception ex)
            {
                InProgress = false;
                exception = ex;
                isToShowMessage = true;
            }
            if (isToShowMessage)
            {
                await _messageBox.ShowAsync("Application fails.",
                                           "Authentication Sample", 
                                            new List<string> { "Ok" });
            }
            if (exception != null)
            {
                await _logManager.LogAsync(exception);
            }
        }

        private async Task ShowMessage()
        {
            await _messageBox.ShowAsync("Wasn´t possible to complete the login.",
               "Authentication Sample",
                new List<string>
                {
                   "Ok" 
                });
        }

#if WINDOWS_PHONE_APP
        public async void Finalize(WebAuthenticationBrokerContinuationEventArgs args)
        {
            var result = await _sessionService.Finalize(args);
            if (!result)
            {
                await ShowMessage();
            }
            else
            {
                _navigationService.Navigate<MainView>();
                InProgress = false;
            }
        }
#endif
    }
}
