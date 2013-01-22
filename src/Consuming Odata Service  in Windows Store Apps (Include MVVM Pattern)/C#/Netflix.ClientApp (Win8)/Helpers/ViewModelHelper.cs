// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelHelper.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The view model helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Helpers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Netflix.ClientApp.Model;
    using Netflix.ClientApp.NetFlixCatalog;

    /// <summary>
    /// The view model helper.
    /// </summary>
    public static class ViewModelHelper
    {
        /// <summary>
        /// The get group view.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="label">
        /// The label.
        /// </param>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// The <see cref="GroupView"/>.
        /// </returns>
        public static GroupView GetGroupView(string id, string label, IEnumerable items)
        {
            var groupView = new GroupView
            {
                Id = id,
                Label = label,
                Items = new List<ItemView>()
            };

            foreach (var item in items)
            {
                groupView.Items.Add(GetItem(item, groupView));
            }

            return groupView;
        }

        /// <summary>
        /// The get item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="groupView">
        /// The group view.
        /// </param>
        /// <returns>
        /// The <see cref="ItemView"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        ///  The exception for the cases that the data type is not defined.
        /// </exception>
        private static ItemView GetItem(object item, GroupView groupView)
        {
            if (item is MyTitle)
            {
                return new MyTitleItemView { Group = groupView, Item = item as MyTitle };
            }

            if (item is Title)
            {
                return new TitleItemView { Group = groupView, Item = item as Title };
            }

            throw new NotSupportedException();
        }
    }
}
