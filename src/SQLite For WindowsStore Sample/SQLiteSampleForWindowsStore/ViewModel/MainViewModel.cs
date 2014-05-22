namespace SQLLiteSample.ViewModel
{
    using System;
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
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The data service
        /// </summary>
        private readonly IDataService _dataService;

        /// <summary>
        /// The navigation service
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// The message box service.
        /// </summary>
        private readonly IMessageBoxService _messageBoxService;

        /// <summary>
        /// The selected university
        /// </summary>
        private University _selectedUniversity;

        /// <summary>
        /// The universities
        /// </summary>
        private IList<University> _universities;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, INavigationService navigationService, IMessageBoxService messageBoxService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            _messageBoxService = messageBoxService;
            LoadDataCommand = new RelayCommand(async ()=> await LoadData());
            AddCommand = new RelayCommand(AddUniversity);
            UpdateCommand =new RelayCommand(UpdateUniverity);
            DeleteCommand = new RelayCommand(async () => await DeleteUniversity());
            SeeStudentsCommand = new RelayCommand(SeeStudents);
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
        /// Gets the see students command.
        /// </summary>
        /// <value>
        /// The see students command.
        /// </value>
        public ICommand SeeStudentsCommand { get; private set; }

        /// <summary>
        /// Gets or sets the selected university.
        /// </summary>
        /// <value>
        /// The selected university.
        /// </value>
        public University SelectedUniversity
        {
            get
            {
                return this._selectedUniversity;
            }
            set
            {
               Set("SelectedUniversity", ref _selectedUniversity, value);
            }
        }

        /// <summary>
        /// Gets or sets the universities.
        /// </summary>
        /// <value>
        /// The universities.
        /// </value>
        public IList<University> Universities
        {
            get
            {
                return this._universities;
            }
            set
            {
                Set("Universities", ref _universities, value);
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
        public async Task LoadData()
        {
            Universities = await _dataService.LoadUniversitiesAsync();
        }

        /// <summary>
        /// Adds the university.
        /// </summary>
        private void AddUniversity()
        {
            _navigationService.NavigateTo(typeof(CreateUniversityPage));
        }

        /// <summary>
        /// Deletes the university.
        /// </summary>
        private async Task DeleteUniversity()
        {
            if (SelectedUniversity != null)
            {
                await _dataService.DeleteUniversityAsync(SelectedUniversity);
                await LoadData();
            }
            else
            {
                await this._messageBoxService.ShowAsync("Select one university.", "SQLite Sample");
            }
        }

        /// <summary>
        /// Updates the univerity.
        /// </summary>
        private async void UpdateUniverity()
        {
            if (SelectedUniversity != null)
            {
                _navigationService.NavigateTo(typeof(EditUniversityPage), SelectedUniversity);
            }
            else
            {
                await _messageBoxService.ShowAsync("Select one university.", "SQLite Sample");
            }
        }


        /// <summary>
        /// Sees the students.
        /// </summary>
        private async void SeeStudents()
        {
            if (SelectedUniversity != null)
            {
                _navigationService.NavigateTo(typeof(SeeStudentsPage),SelectedUniversity);
            }
            else
            {
                await _messageBoxService.ShowAsync("Select one university.", "SQLite Sample");
            }
        }
    }
}