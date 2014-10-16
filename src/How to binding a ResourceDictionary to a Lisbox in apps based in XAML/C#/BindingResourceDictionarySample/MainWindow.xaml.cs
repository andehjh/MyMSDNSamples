using System.Windows.Media;
using FirstFloor.ModernUI.Presentation;

namespace BindingResourceDictionarySample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            AppearanceManager.Current.AccentColor = Colors.Orange;
        }
    }
}
