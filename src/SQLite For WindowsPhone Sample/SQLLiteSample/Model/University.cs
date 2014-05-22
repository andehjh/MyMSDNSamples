namespace SQLLiteSample.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using GalaSoft.MvvmLight;

    using SQLite;

    /// <summary>
    /// The university class.
    /// </summary>
    [Table("University")]
    public class University : ObservableObject
    {
        /// <summary>
        /// The id.
        /// </summary>
        private Guid _id;

        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="University" /> class.
        /// </summary>
        public University()
        {
           Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [PrimaryKey]
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                Set("Id", ref _id, value);
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                Set("Name", ref _name, value);
            }
        }
    }
}
