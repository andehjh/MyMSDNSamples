// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NetFlixItemTemplateSelector.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the netflix item template selector
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.TemplateSelector
{
    using System;

    using Netflix.ClientApp.Helpers;
    using Netflix.ClientApp.Model;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Defines the netflix item template selector
    /// </summary>
    public class NetFlixItemTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// When implemented by a derived class, returns a specific DataTemplate for a given item or container.
        /// </summary>
        /// <param name="item">The item to return a template for.</param>
        /// <param name="container">The parent container for the templated item.</param>
        /// <returns>
        /// The template to use for the given item and/or container.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The information for define the data template is not valid.</exception>
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var itemView = item as ItemView;

            // If you are using the FakeServiceManager or used the ServiceManager.ConvertToMyTitles
            // use it:
            if (itemView != null && itemView.Group.Id == NameDefinitions.NewDVDMoviesId)
            {
                return (DataTemplate)Application.Current.Resources["MyNewDVDMoviesItemTemplate"];
            }

            if (itemView != null && itemView.Group.Id == NameDefinitions.TopDVDMoviesId)
            {
                return (DataTemplate)Application.Current.Resources["MyTopDVDMoviesItemTemplate"];
            }

            // If you are using the ServiceManager but did not converted Title in MyTitles 
            // use it:
            // if (itemView != null && itemView.Group.Id == NameDefinitions.NewDVDMoviesId)
            // {
            //    return (DataTemplate)Application.Current.Resources["NewDVDMoviesItemTemplate"];
            // }

            // if (itemView != null && itemView.Group.Id == NameDefinitions.TopDVDMoviesId)
            // {
            //    return (DataTemplate)Application.Current.Resources["TopDVDMoviesItemTemplate"];
            // }
            throw new ArgumentOutOfRangeException();
        }
    }
}
