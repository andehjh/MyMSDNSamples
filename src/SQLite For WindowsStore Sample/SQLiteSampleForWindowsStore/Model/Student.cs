
namespace SQLLiteSample.Model
{
    using System;

    using GalaSoft.MvvmLight;

    using SQLite;

    /// <summary>
    /// The student class
    /// </summary>
    [Table("Student")]
    public class Student : ObservableObject
    {
        /// <summary>
        /// The id
        /// </summary>
        private Guid _id;

        /// <summary>
        /// The first name
        /// </summary>
        private string _firstName;

        /// <summary>
        /// The last name
        /// </summary>
        private string _lastName;

        /// <summary>
        /// The age
        /// </summary>
        private int _age;

        /// <summary>
        /// The university id
        /// </summary>
        private Guid _universityId;

        /// <summary>
        /// Initializes a new instance of the <see cref="Student" /> class.
        /// </summary>
        public Student()
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
        /// Gets or sets the first name.
        /// </summary>
        [MaxLength(50)]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                Set("FirstName", ref _firstName, value);
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [MaxLength(50)]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                Set("LastName", ref _lastName, value);
            }
        }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                Set("Age", ref _age, value);
            }
        }

        /// <summary>
        /// Gets or sets the university id.
        /// </summary>
        /// <value>
        /// The university id.
        /// </value>
        public Guid UniversityId
        {
            get
            {
                return _universityId;
            }
            set
            {
                _universityId = value;
            }
        }
    }
}
