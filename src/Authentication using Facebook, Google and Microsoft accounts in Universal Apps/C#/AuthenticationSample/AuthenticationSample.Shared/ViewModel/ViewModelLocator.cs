// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelLocator.cs" company="saramgsilva">
//   Copyright (c) 2013 saramgsilva. All rights reserved. 
// </copyright>
// <summary>
//   This class contains static references to all the view models in the
//   application and provides an entry point for the bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using AuthenticationSample.UniversalApps.Services;
using AuthenticationSample.UniversalApps.Services.Interfaces;
using Cimbalino.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace AuthenticationSample.UniversalApps.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            SimpleIoc.Default.Register<IApplicationDataService, ApplicationDataService>();
            SimpleIoc.Default.Register<IMessageBoxService, MessageBoxService>();
            SimpleIoc.Default.Register<ISessionService, SessionService>();
            SimpleIoc.Default.Register<IStorageService, StorageService>();
            SimpleIoc.Default.Register<IMicrosoftService, MicrosoftService>();
            SimpleIoc.Default.Register<IGoogleService, GoogleService>();
            SimpleIoc.Default.Register<IFacebookService, FacebookService>();
            SimpleIoc.Default.Register<INetworkInformationService, NetworkInformationService>();
            SimpleIoc.Default.Register<ILogManager, LogManager>();
            SimpleIoc.Default.Register<IEmailComposeService, EmailComposeService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
        }

        /// <summary>
        /// Gets the main view model.
        /// </summary>
        /// <value>
        /// The main view model.
        /// </value>
        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        /// <summary>
        /// Gets the login view model.
        /// </summary>
        /// <value>
        /// The login view model.
        /// </value>
        public LoginViewModel LoginViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        /// <summary>
        /// The cleanup.
        /// </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}