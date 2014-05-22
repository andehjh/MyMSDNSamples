namespace SQLLiteSample.ViewModel
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Input;
    
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    using SQLLiteSample.Model;
    using SQLLiteSample.Service;

    using SQLiteSampleForWindowsStore.Service;

    public class EditStudentViewModel : ViewModelBase
    {
        /// <summary>
        /// The data service.
        /// </summary>
        private readonly IDataService _dataService;

        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// The student
        /// </summary>
        private Student _student;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditStudentViewModel" /> class.
        /// </summary>
        /// <param name="dataService">The data service.</param>
        /// <param name="navigationService">The navigation service.</param>
        public EditStudentViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            _student = null;
            
            SaveCommand =new RelayCommand(async ()=> await SaveStudentAsync());
            CancelCommand =new RelayCommand(_navigationService.GoBack);
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
        /// Saves the student.
        /// </summary>
        /// <returns></returns>
        public async Task SaveStudentAsync()
        {
            if (Student != null && 
               !string.IsNullOrEmpty(Student.FirstName) &&
               !string.IsNullOrEmpty(Student.LastName))
            {
                await _dataService.UpdateStudentAsync(Student);
                _navigationService.GoBack();
            }
        }
        
        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        /// <value>
        /// The save command.
        /// </value>
        public ICommand SaveCommand { get; private set; }

        /// <summary>
        /// Gets or sets the cancel command.
        /// </summary>
        public ICommand CancelCommand { get; private set; }

        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData(Student student)
        {
            Student = student;
        }

        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        public Student Student
        {
            get
            {
                return this._student;
            }
            set
            {
                Set("Student", ref _student, value);
            }
        }
    }
}
