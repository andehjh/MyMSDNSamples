namespace SQLLiteSample.ViewModel
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    using SQLLiteSample.Model;
    using SQLLiteSample.Service;

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
            LoadDataCommand = new RelayCommand(async ()=> await LoadDataAsync());
            SaveCommand =new RelayCommand(async ()=> await SaveStudentAsync());
            CancelCommand =new RelayCommand(_navigationService.GoBack);
        }

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
        /// Gets the load data command.
        /// </summary>
        /// <value>
        /// The load data command.
        /// </value>
        public ICommand LoadDataCommand { get; private set; }
        
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
        public async Task LoadDataAsync()
        {
           try
            {
                var guid = _navigationService.QueryString["student"];
                Student = await _dataService.LoadStudentbyIdAsync(guid);
            }
            catch (KeyNotFoundException)
            {
                Student = new Student();
            }
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
