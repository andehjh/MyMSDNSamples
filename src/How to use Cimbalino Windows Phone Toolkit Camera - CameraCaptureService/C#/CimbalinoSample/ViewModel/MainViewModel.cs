using GalaSoft.MvvmLight;

namespace CimbalinoSample.ViewModel
{
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight.Command;

    using Microsoft.Devices;

    using Windows.Storage.Streams;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The camera capture service
        /// </summary>
        private readonly ICameraCaptureService _cameraCaptureService;

        /// <summary>
        /// The image
        /// </summary>
        private ImageSource _image;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ICameraCaptureService cameraCaptureService)
        {
            _cameraCaptureService = cameraCaptureService;
            CameraCaptureCommand = new RelayCommand(CameraCapture);
        }
        
        /// <summary>
        /// Gets the camera capture command.
        /// </summary>
        /// <value>
        /// The camera capture command.
        /// </value>
        public ICommand CameraCaptureCommand { get; private set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public ImageSource Image
        {
            get
            {
                return _image;
            }
            set
            {
                Set("Image", ref _image, value);
            }
        }

        /// <summary>
        /// Cameras the capture.
        /// </summary>
        private void CameraCapture()
        {
            Image = null;
            _cameraCaptureService.Show(CameraCapetureResult);
        }

        /// <summary>
        /// Cameras the capeture result.
        /// </summary>
        /// <param name="photoResult">The photo result.</param>
        private async void CameraCapetureResult(Microsoft.Phone.Tasks.PhotoResult photoResult)
        {
            if(photoResult.ChosenPhoto!=null)
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.SetSource(photoResult.ChosenPhoto);
                Image = bitmapImage;
            }
        }
    }
}