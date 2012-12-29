namespace MSDN.Samples.ButtonChangePictureSample.ViewModel
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Windows.UI.Xaml.Media.Imaging;

    public class ClickToChangePictureViewModel:ViewModelBase
    {
        public BitmapSource _myImage1;
        public BitmapSource _myImage2;
        private string _textToShow;
        private BitmapSource _imageToShow;

        public ClickToChangePictureViewModel()
        {
            _myImage1 = new BitmapImage(new Uri("ms-appx:///Images/110Banana.png"));
            _myImage2 = new BitmapImage(new Uri("ms-appx:///Images/110Lemon.png"));
            ClickCommand = new RelayCommand(ChangeIamges);
            ChangeIamges();
        }

        private void ChangeIamges()
        {
            TextToShow = ImageToShow == _myImage1 ? "Banana" : "Lemon";
            ImageToShow = ImageToShow == _myImage1 ? _myImage2 : _myImage1;
        }

        public string TextToShow
        {
            get { return _textToShow; }
            set { _textToShow = value; RaisePropertyChanged(() => TextToShow); }
        }

        public BitmapSource ImageToShow
        {
            get { return _imageToShow; }
            set { _imageToShow = value; RaisePropertyChanged(() => ImageToShow); }
        }

        public ICommand ClickCommand { get; set; }
    }
}
