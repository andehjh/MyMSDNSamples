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
    /// <summary>
    /// The fake item view.
    /// </summary>
    public class MyTitleItemView : ItemView
    {
        /// <summary>
        /// The item
        /// </summary>
        private MyTitle _item;

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public MyTitle Item
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
