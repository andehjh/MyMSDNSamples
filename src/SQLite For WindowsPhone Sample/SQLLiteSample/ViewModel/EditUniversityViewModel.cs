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

    public class EditUniversityViewModel : ViewModelBase
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
        /// The university.
        /// </summary>
        private University _university;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditUniversityViewModel"/> class.
        /// </summary>
        /// <param name="dataService">
        /// The data service.
        /// </param>
        /// <param name="navigationService">
        /// The navigation service.
        /// </param>
        public EditUniversityViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            _university = null;
            LoadDataCommand = new RelayCommand(async () => await LoadDataAsync());
            SaveCommand =new RelayCommand(SaveUniversity);
            CancelCommand =new RelayCommand(_navigationService.GoBack);
        }

        /// <summary>
        /// Gets or sets the cancel command.
        /// </summary>
        public ICommand CancelCommand { get; set; }

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
        public ICommand SaveCommand { get; set; }

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
        /// Loads the data.
        /// </summary>
        /// <returns></returns>
        public async Task LoadDataAsync()
        {
            try
            {
                var guid = _navigationService.QueryString["university"];
                University = await this._dataService.LoadUniversityByIdAsync(guid);
            }
            catch (KeyNotFoundException)
            {
                University = new University();
            }
        }

        /// <summary>
        /// The save university.
        /// </summary>
        private async void SaveUniversity()
        {
            if(University!=null && !string.IsNullOrEmpty(University.Name))
            {
                await _dataService.UpdateUniversityAsync(University);
                _navigationService.GoBack();
            }
        }
    }
}
