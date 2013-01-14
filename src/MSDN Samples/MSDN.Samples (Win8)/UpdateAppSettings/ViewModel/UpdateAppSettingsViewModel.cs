namespace MSDN.Samples.UpdateAppSettings.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    using GalaSoft.MvvmLight.Command;

    using MSDN.Samples.Annotations;
    using MSDN.Samples.UpdateAppSettings.Model;

    /// <summary>
    /// The update app settings view model.
    /// </summary>
    public class UpdateAppSettingsViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The my settings.
        /// </summary>
        private MySetting _mySettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAppSettingsViewModel"/> class.
        /// </summary>
        public UpdateAppSettingsViewModel()
        {
            this._mySettings = new MySetting();
            this.ResetValueCommand = new RelayCommand(this.ResetSettings);
            this.IncrementValueCommand = new RelayCommand(this.IncrementValue);
        }

        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the increment value command.
        /// </summary>
        /// <value>
        /// The increment value command.
        /// </value>
        public ICommand IncrementValueCommand { get; set; }

        /// <summary>
        /// Gets or sets the reset value command.
        /// </summary>
        /// <value>
        /// The reset value command.
        /// </value>
        public ICommand ResetValueCommand { get; set; }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public MySetting Settings
        {
            get
            {
                return this._mySettings;
            }

            set
            {
                this._mySettings = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Increments the value.
        /// </summary>
        private void IncrementValue()
        {
            Settings.Value++;
        }

        /// <summary>
        /// Resets the settings.
        /// </summary>
        private void ResetSettings()
        {
            Settings.Value = 0;
        }
    }
}
