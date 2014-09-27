namespace CimbalinoSample.ViewModel
{
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;

    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight;
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The location service
        /// </summary>
        private readonly ILocationService _locationService;

        private bool _isLocationEnable;

        /// <summary>
        /// Define if is start enable
        /// </summary>
        private bool _isStartEnable;

        /// <summary>
        /// Define if is stop enable
        /// </summary>
        private bool _isStopEnable;

        /// <summary>
        /// The latitude
        /// </summary>
        private double _latitude;

        /// <summary>
        /// The logitude
        /// </summary>
        private double _longitude;

        /// <summary>
        /// The status
        /// </summary>
        private LocationServiceStatus _status;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ILocationService locationService)
        {
            IsStartEnable = true;
            IsLocationEnable = true;
            IsStopEnable = false;
            _locationService = locationService;
            _locationService.ReportInterval = 5;
            _locationService.PositionChanged += LocationService_PositionChanged;
            _locationService.StatusChanged += LocationService_StatusChanged;
            StartCommand =new RelayCommand(Start);
            StopCommand =new RelayCommand(Stop);
            LocationCommand = new RelayCommand(GetLocation);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is location enable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is location enable]; otherwise, <c>false</c>.
        /// </value>
        public bool IsLocationEnable
        {
            get
            {
                return this._isLocationEnable;
            }
            set
            {
                Set("IsLocationEnable", ref _isLocationEnable, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is start enable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is start enable]; otherwise, <c>false</c>.
        /// </value>
        public bool IsStartEnable
        {
            get
            {
                return this._isStartEnable;
            }
            set
            {
                Set("IsStartEnable", ref _isStartEnable, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is stop enable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is stop enable]; otherwise, <c>false</c>.
        /// </value>
        public bool IsStopEnable
        {
            get
            {
                return this._isStopEnable;
            }
            set
            {
                Set("IsStopEnable", ref _isStopEnable, value);
            }
        }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                Set("Latitude", ref _latitude, value);
            }
        }

        /// <summary>
        /// Gets or sets the location command.
        /// </summary>
        /// <value>
        /// The get location command.
        /// </value>
        public ICommand LocationCommand { get; private set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The logitude.
        /// </value>
        public double Longitude
        {
            get
            {
                return this._longitude;
            }
            set
            {
                Set("Longitude", ref _longitude, value);
            }
        }

        /// <summary>
        /// Gets or sets the start command.
        /// </summary>
        /// <value>
        /// The start command.
        /// </value>
        public ICommand StartCommand { get; private set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public LocationServiceStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                Set("Status", ref _status, value);
            }
        }
        /// <summary>
        /// Gets or sets the stop command.
        /// </summary>
        /// <value>
        /// The stop command.
        /// </value>
        public ICommand StopCommand { get; private set; }
        /// <summary>
        /// Unregisters this instance from the Messenger class.
        /// <para>To cleanup additional resources, override this method, clean
        /// up and then call base.Cleanup().</para>
        /// </summary>
        public override void Cleanup()
        {
            base.Cleanup();
            _locationService.PositionChanged -= LocationService_PositionChanged;
            _locationService.StatusChanged -= LocationService_StatusChanged;
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        private async void GetLocation()
        {
            var result = await _locationService.GetPositionAsync();
            Longitude = result.Longitude;
            Latitude = result.Latitude;
        }

        /// <summary>
        /// Handles the PositionChanged event of the LocationService control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LocationServicePositionChangedEventArgs"/> instance containing the event data.</param>
        private void LocationService_PositionChanged(object sender, LocationServicePositionChangedEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    Latitude = e.Position.Latitude;
                    Longitude = e.Position.Longitude;
                });
        }
     
        /// <summary>
        /// Handles the StatusChanged event of the _locationService control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LocationServiceStatusChangedEventArgs"/> instance containing the event data.</param>
        private void LocationService_StatusChanged(object sender, LocationServiceStatusChangedEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(delegate { Status = e.Status; });
        }

        /// <summary>
        /// Starts the location service.
        /// </summary>
        private void Start()
        {
            IsStartEnable = false;
            IsStopEnable = true;
            IsLocationEnable = false;
            _locationService.Start();
        }

        /// <summary>
        /// Stops the location service.
        /// </summary>
        private void Stop()
        {
            IsLocationEnable = true;
            IsStartEnable = true;
            IsStopEnable = false;
            _locationService.Stop();
        }
    }
}