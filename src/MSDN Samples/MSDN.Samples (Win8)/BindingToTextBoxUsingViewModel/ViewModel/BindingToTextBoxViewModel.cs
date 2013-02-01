namespace MSDN.Samples.BindingToTextBoxUsingViewModel.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    using CharmFlyoutLibrary;

    using MSDN.Samples.Annotations;

    using Windows.UI;
    using Windows.UI.Xaml.Media;

    public class BindingToTextBoxViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The background color.
        /// </summary>
        private SolidColorBrush _background;

        /// <summary>
        /// The foreground color.
        /// </summary>
        private SolidColorBrush _foreground;

        /// <summary>
        /// The yellow SolidColorBrush.
        /// </summary>
        private SolidColorBrush _yellow;

        /// <summary>
        /// The green SolidColorBrush.
        /// </summary>
        private SolidColorBrush _green;

        /// <summary>
        /// The blue SolidColorBrush.
        /// </summary>
        private SolidColorBrush _blue;

        /// <summary>
        /// The red SolidColorBrush.
        /// </summary>
        private SolidColorBrush _red;

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingToTextBoxViewModel" /> class.
        /// </summary>
        public BindingToTextBoxViewModel()
        {
            _yellow = new SolidColorBrush(Colors.Yellow);
            _green = new SolidColorBrush(Colors.Green);
            _blue = new SolidColorBrush(Colors.Blue);
            _red = new SolidColorBrush(Colors.Red);
            _foreground = _yellow;
            _background = _red;
            ChangeForegroundColorCommand = new RelayCommand(ChangeForeground);
            ChangeBackgroundColorCommand = new RelayCommand(ChangeBackground);
        }

        private void ChangeBackground(object obj)
        {
            Background = Background == _red ? _blue : _red;
        }

        private void ChangeForeground(object obj)
        {
            Foreground = Foreground == _yellow ? _green : _yellow;
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the background.
        /// </summary>
        public SolidColorBrush Background
        {
            get
            {
                return _background;
            }

            set
            {
                _background = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the foreground.
        /// </summary>
        public SolidColorBrush Foreground
        {
            get
            {
                return _foreground;
            }

            set
            {
                _foreground = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the change foreground color command.
        /// </summary>
        /// <value>
        /// The change foreground color command.
        /// </value>
        public ICommand ChangeForegroundColorCommand { get; private set; }

        /// <summary>
        /// Gets the change background color command.
        /// </summary>
        /// <value>
        /// The change background color command.
        /// </value>
        public ICommand ChangeBackgroundColorCommand { get; private set; }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
