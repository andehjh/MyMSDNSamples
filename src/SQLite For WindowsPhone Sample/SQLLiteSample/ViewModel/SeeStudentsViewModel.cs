namespace SQLLiteSample.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    using SQLLiteSample.Model;
    using SQLLiteSample.Service;

    /// <summary>
    /// The see students view model
    /// </summary>
    public class SeeStudentsViewModel : ViewModelBase
    {
        /// <summary>
        /// The message box service
        /// </summary>
        private readonly IMessageBoxService _messageBoxService;

        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// The data service.
        /// </summary>
        private IDataService _dataService;

        /// <summary>
        /// The selected student
        /// </summary>
        private Student _selectedStudent;

        /// <summary>
        /// The students
        /// </summary>
        private IList<Student> _students;

        /// <summary>
        /// The university.
        /// </summary>
        private University _university;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeeStudentsViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="dataService">The data service</param>
        /// <param name="messageBoxService">The message box service.</param>
        public SeeStudentsViewModel(INavigationService navigationService, IDataService dataService, IMessageBoxService messageBoxService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _messageBoxService = messageBoxService;
            LoadDataCommand = new RelayCommand(async () => await LoadDataAsync());
            AddCommand = new RelayCommand(AddStudent);
            UpdateCommand = new RelayCommand(UpdateStudent);
            DeleteCommand = new RelayCommand(async () => await DeleteStudentAsync());
        }

        /// <summary>
        /// Gets the add command.
        /// </summary>
        /// <value>
        /// The add command.
        /// </value>
        public ICommand AddCommand { get; private set; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>
        /// The delete command.
        /// </value>
        public ICommand DeleteCommand { get; private set; }

        /// <summary>
        /// Gets the load data command.
        /// </summary>
        /// <value>
        /// The load data command.
        /// </value>
        public ICommand LoadDataCommand { get; private set; }

        /// <summary>
        /// Gets or sets the selected student.
        /// </summary>
        public Student SelectedStudent
        {
            get
            {
                return this._selectedStudent;
            }
            set
            {
                Set("SelectedStudent", ref _selectedStudent, value);
            }
        }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        public IList<Student> Students
        {
            get
            {
                return this._students;
            }
            set
            {
                Set("Students", ref _students, value);
            }
        }

        /// <summary>
        /// Gets or sets the university.
        /// </summary>
        public University University
        {
            get
            {
                return _university;
            }
            set
            {
                Set("University", ref _university, value);
            }
        }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <value>
        /// The update command.
        /// </value>
        public ICommand UpdateCommand { get; private set; }

        /// <summary>
        /// Loads the data async.
        /// </summary>
        /// <returns></returns>
        public async Task LoadDataAsync()
        {
            try
            {
                var guid = _navigationService.QueryString["university"];
                University = await _dataService.LoadUniversityByIdAsync(guid);
                Students = await _dataService.LoadStudentsByUniversityAsync(University);
            }
            catch (KeyNotFoundException)
            {

            }
        }

        /// <summary>
        /// Adds the student.
        /// </summary>
        private void AddStudent()
        {
            _navigationService.NavigateTo(new Uri(string.Format("/CreateStudentPage.xaml?university={0}", University.Id.ToString()), UriKind.Relative));
        }

        /// <summary>
        /// Deletes the student.
        /// </summary>
        public async Task DeleteStudentAsync()
        {
            if (SelectedStudent != null)
            {
                await _dataService.DeleteStudentAsync(SelectedStudent);
                await LoadDataAsync();
            }
            else
            {
                _messageBoxService.Show("Select one student.");
            }
        }

        /// <summary>
        /// Updates the student.
        /// </summary>
        private void UpdateStudent()
        {
            if (SelectedStudent != null)
            {
                _navigationService.NavigateTo(new Uri(string.Format("/EditStudentPage.xaml?student={0}", SelectedStudent.Id.ToString()), UriKind.Relative));
            }
            else
            {
                _messageBoxService.Show("Select one student.");
            }
        }
    }
}
