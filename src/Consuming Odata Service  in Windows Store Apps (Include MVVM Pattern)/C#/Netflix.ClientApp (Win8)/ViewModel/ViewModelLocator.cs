// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelLocator.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   This class contains static references to all the view models in the
//   application and provides an entry point for the bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.ViewModel
{
    using GalaSoft.MvvmLight.Ioc;

    using Microsoft.Practices.ServiceLocation;

    using Netflix.ClientApp.Services;

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
           
            if (!SimpleIoc.Default.IsRegistered<IServiceManager>())
            {
                // For use the fake data do:
                // SimpleIoc.Default.Register<IServiceManager, FakeServiceManager>();
                SimpleIoc.Default.Register<IServiceManager, ServiceManager>();
            }

            SimpleIoc.Default.Register<TitlesViewModel>();
        }

        /// <summary>
        /// Gets the titles view model.
        /// </summary>
        public TitlesViewModel TitlesViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TitlesViewModel>();
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