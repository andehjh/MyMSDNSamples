// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringFormatConverter.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the StringFormatConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Converters
{
    using System;
    using Windows.UI.Xaml.Data;

    /// <summary>
    /// The string format converter.
    /// </summary>
    public class StringFormatConverter : IValueConverter
    {
        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The value converted</returns>
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            return string.Format(parameter.ToString(), value, culture);
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The value that was converted back</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            return value;
        }
    }
}