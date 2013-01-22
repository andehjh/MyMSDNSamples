// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeServiceManager.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the FakeServiceManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Netflix.ClientApp.Model;

    using Windows.UI.Xaml.Media.Imaging;

    /// <summary>
    /// The fake service manager.
    /// </summary>
    public class FakeServiceManager : IServiceManager
    {
        /// <summary>
        /// The bitmap soure
        /// </summary>
        private readonly BitmapImage _bitmapSoure;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeServiceManager" /> class.
        /// </summary>
        public FakeServiceManager()
        {
           _bitmapSoure = new BitmapImage(new Uri("ms-appx:///Images/FakeImage.png"));
        }

        /// <summary>
        /// Creates the items.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>the list of mytitles</returns>
        public IEnumerable CreateItems(int number)
        {
            var myTitles = new List<MyTitle>();
            for (var i = 0; i < number; i++)
            {
                myTitles.Add(new MyTitle
                        {
                            Name = string.Concat("Fake Name ", i),
                            AvailableFrom = DateTime.Now,
                            Rating = 0,
                            Image = _bitmapSoure
                        });
            }

            return myTitles;
        }

        /// <summary>
        /// Loads the new dvd movies async.
        /// </summary>
        /// <returns>
        /// Represents an asynchronous operation that return an IEnumerable.
        /// </returns>
        public async Task<IEnumerable> LoadNewDVDMoviesAsync()
        {
            return await Task.Run(() => CreateItems(20));
        }

        /// <summary>
        /// Loads the top dvd movies async.
        /// </summary>
        /// <returns>
        /// Represents an asynchronous operation that return an IEnumerable.
        /// </returns>
        public async Task<IEnumerable> LoadTopDVDMoviesAsync()
        {
            return await Task.Run(() => CreateItems(20));
        }
    }
}
