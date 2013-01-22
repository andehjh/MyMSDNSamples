// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GroupView.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the group for helps to binding with the view when is needed to group data
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Netflix.ClientApp.Properties;

    /// <summary>
    /// Defines the group for helps to binding with the view when is needed to group data
    /// </summary>
    public class GroupView : INotifyPropertyChanged
    {
        /// <summary>
        /// The id.
        /// </summary>
        private string _id;

        /// <summary>
        /// The label.
        /// </summary>
        private string _label;

        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IList<ItemView> Items { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label
        {
            get
            {
                return _label;
            }

            set
            {
                _label = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the item template key.
        /// </summary>
        /// <value>
        /// The item template key.
        /// </value>
        public string ItemTemplateKey { get; set; }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
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