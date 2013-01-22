// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SuspensionManagerException.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The suspension manager exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Common
{
    using System;

    /// <summary>
    /// The suspension manager exception.
    /// </summary>
    public class SuspensionManagerException : Exception
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SuspensionManagerException"/> class.
        /// </summary>
        public SuspensionManagerException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuspensionManagerException"/> class.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        public SuspensionManagerException(Exception e)
            : base("SuspensionManager failed", e)
        {
        }

        #endregion Constructors and Destructors
    }
}
