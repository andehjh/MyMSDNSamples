// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceManager.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The service manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Services.Client;
    using System.Linq;
    using System.Threading.Tasks;

    using Netflix.ClientApp.Extensions;
    using Netflix.ClientApp.Model;
    using Netflix.ClientApp.NetFlixCatalog;

    using Windows.UI.Xaml.Media.Imaging;

    /// <summary>
    /// The service manager.
    /// </summary>
    public class ServiceManager : IServiceManager
    {
        /// <summary>
        /// The _netflix catalog.
        /// </summary>
        private readonly NetflixCatalog _netflixCatalog;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManager"/> class.
        /// </summary>
        public ServiceManager()
        {
            _netflixCatalog = new NetflixCatalog(new Uri("http://odata.netflix.com/v2/Catalog/"), UriKind.Absolute);
        }

        /// <summary>
        /// Loads the new dvd movies async.
        /// </summary>
        /// <returns>
        /// Represents an asynchronous operation that return a IEnumerable.
        /// </returns>
        public async Task<IEnumerable> LoadNewDVDMoviesAsync()
        {
            var query = ((DataServiceQuery<Title>)_netflixCatalog.Titles.Where(title => title.ReleaseYear >= 2012
                                                                            && title.Dvd.Available
                                                                            && title.Type == "Movie")
                                                                       .OrderByDescending(item => item.Dvd.AvailableFrom)
                                                                       .Take(30)).Expand(item => item.Genres).Expand(item => item.Directors);
            var result = await query.ExecuteAsync();

            return ConvertToMyTitles(result);
        }

        /// <summary>
        /// Loads the top dvd movies async.
        /// </summary>
        /// <returns>
        /// Represents an asynchronous operation that return a IEnumerable.
        /// </returns>
        public async Task<IEnumerable> LoadTopDVDMoviesAsync()
        {
            var query = ((DataServiceQuery<Title>)_netflixCatalog.Titles.Where(title => title.ReleaseYear >= 2012
                                                                                        && title.Dvd.Available
                                                                                        && title.Type == "Movie")
                                                                         .OrderByDescending(item => item.AverageRating)
                                                                         .Take(20)).Expand(item => item.Genres).Expand(item => item.Directors);
            var result = await query.ExecuteAsync();

            return ConvertToMyTitles(result);
        }

        /// <summary>
        /// Converts to my titles.
        /// </summary>
        /// <param name="titles">The titles.</param>
        /// <returns>The my titles list.</returns>
        private IEnumerable ConvertToMyTitles(IEnumerable<Title> titles)
        {
            return
                titles.Select(
                    title =>
                    new MyTitle
                    {
                        Name = title.Name,
                        Image = new BitmapImage(new Uri(title.BoxArt.MediumUrl)),
                        AvailableFrom = title.Dvd.AvailableFrom,
                        Rating = title.AverageRating
                    }).ToList();
        }
    }
}
