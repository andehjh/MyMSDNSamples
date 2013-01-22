// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyTitle.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The my title.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Model
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Netflix.ClientApp.Properties;

    using Windows.UI.Xaml.Media.Imaging;

    /// <summary>
    /// The my title.
    /// </summary>
    public class MyTitle : INotifyPropertyChanged
    {
        /// <summary>
        /// The available from (date)
        /// </summary>
        private DateTime? _availableFrom;

        /// <summary>
        /// The image.
        /// </summary>
        private BitmapImage _image;

        /// <summary>
        /// The rating
        /// </summary>
        private double? _rating;

        /// <summary>
        /// The name.
        /// </summary>
        private string _name;

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the available from.
        /// </summary>
        public DateTime? AvailableFrom
        {
            get
            {
                return _availableFrom;
            }

            set
            {
                _availableFrom = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public BitmapImage Image
        {
            get
            {
                return this._image;
            }

            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        public double? Rating
        {
            get
            {
                return _rating;
            }

            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
