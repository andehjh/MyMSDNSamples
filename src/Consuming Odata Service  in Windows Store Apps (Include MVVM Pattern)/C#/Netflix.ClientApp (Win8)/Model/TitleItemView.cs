// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyTitleItemView.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The fake item view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Model
{
    using Netflix.ClientApp.NetFlixCatalog;

    /// <summary>
    /// The item view.
    /// </summary>
    public class TitleItemView : ItemView
    {
        /// <summary>
        /// The item
        /// </summary>
        private Title _item;

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public Title Item
        {
            get
            {
                return _item;
            }

            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The object that represent the real item.</returns>
        public override object GetItem()
        {
            return Item;
        }  
    }
}
