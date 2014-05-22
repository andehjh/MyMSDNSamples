namespace SQLLiteSample.ViewModel
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Input;
    
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    using SQLLiteSample.Model;
    using SQLLiteSample.Service;

    using SQLiteSampleForWindowsStore;
    using SQLiteSampleForWindowsStore.Service;

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
            AddCommand = new RelayCommand(AddStudent);
            UpdateCommand = new RelayCommand(UpdateStudent);
            DeleteCommand = new RelayCommand(async () => await DeleteStudentAsync());
            GoBackCommand = new RelayCommand(_navigationService.GoBack);
        }

        /// <summary>
        /// Gets a value indicating whether [can go back].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can go back]; otherwise, <c>false</c>.
        /// </value>
        public bool CanGoBack
        {
            get
            {
                return _navigationService.CanGoBack;
            }
        }

        /// <summary>
        /// Gets the go back command.
        /// </summary>
        /// <value>
        /// The go back command.
        /// </value>
        public ICommand GoBackCommand { get; private set; }

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
        /// Loads the data.
        /// </summary>
        /// <returns></returns>
        public async Task LoadData(University university)
        {
            University = university;
            Students = await _dataService.LoadStudentsByUniversityAsync(university);
        }

        /// <summary>
        /// Adds the student.
        /// </summary>
        private void AddStudent()
        {
            _navigationService.NavigateTo(typeof(CreateStudentPage),University);
        }

        /// <summary>
        /// Deletes the student.
        /// </summary>
        public async Task DeleteStudentAsync()
        {
            if (SelectedStudent != null)
            {
                await _dataService.DeleteStudentAsync(SelectedStudent);
                await LoadData(University);
            }
            else
            {
                _messageBoxService.ShowAsync("Select one student.","SQLite Sample");
            }
        }

        /// <summary>
        /// Updates the student.
        /// </summary>
        private void UpdateStudent()
        {
            if (SelectedStudent != null)
            {
                _navigationService.NavigateTo(typeof(EditStudentPage), SelectedStudent); 
            }
            else
            {
                _messageBoxService.ShowAsync("Select one student.", "SQLite Sample");
            }
        }
    }
}
