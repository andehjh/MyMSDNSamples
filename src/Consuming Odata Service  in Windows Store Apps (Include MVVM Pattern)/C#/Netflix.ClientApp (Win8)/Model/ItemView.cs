// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemView.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the item viewm for help to binding with a view. This should be a item inside of a list of itens in a group view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Model
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Netflix.ClientApp.Properties;

    /// <summary>
    /// Defines the item viewm for help to binding with a view. This should be a item inside of a list of itens in a group view.
    /// </summary>
    public class ItemView : INotifyPropertyChanged
    {
        /// <summary>
        /// The group
        /// </summary>
        private GroupView _group;

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>
        /// The group.
        /// </value>
        public GroupView Group
        {
            get
            {
                return _group;
            }

            set
            {
                _group = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The object that represent the real item.</returns>
        public virtual object GetItem()
        {
            return null;
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