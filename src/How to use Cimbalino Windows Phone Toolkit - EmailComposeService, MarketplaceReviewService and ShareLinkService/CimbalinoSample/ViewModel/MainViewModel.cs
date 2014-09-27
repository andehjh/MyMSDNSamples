namespace CimbalinoSample.ViewModel
{
    using Cimbalino.Phone.Toolkit.Helpers;
    using Cimbalino.Phone.Toolkit.Services;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The email compose service.
        /// </summary>
        private readonly IEmailComposeService _emailComposeService;

        /// <summary>
        /// The marketplace review service.
        /// </summary>
        private readonly IMarketplaceReviewService _marketplaceReviewService;

        /// <summary>
        /// The share link service.
        /// </summary>
        private readonly IShareLinkService _shareLinkService;

        /// <summary>
        /// The public application url.
        /// </summary>
        private readonly string _appUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="emailComposeService">
        /// The email Compose Service.
        /// </param>
        /// <param name="marketplaceReviewService">
        /// The marketplace review service
        /// </param>
        /// <param name="shareLinkService">
        /// The share Link Service.
        /// </param>
        public MainViewModel(
            IEmailComposeService emailComposeService,
            IMarketplaceReviewService marketplaceReviewService,
            IShareLinkService shareLinkService)
        {
            _emailComposeService = emailComposeService;
            _marketplaceReviewService = marketplaceReviewService;
            _shareLinkService = shareLinkService;

            RateCommand = new RelayCommand(this.Rate);
            SendFeedbackCommand = new RelayCommand(this.SendFeedback);
            ShareToMailCommand = new RelayCommand(this.ShareToMail);
            ShareSocialNetworkCommand = new RelayCommand(this.ShareSocialNetwork);
            _appUrl = string.Concat("http://windowsphone.com/s?appid=8df00038-1b7a-406b-b33f-37a78b17348c");
        }

        /// <summary>
        /// Gets the rate command.
        /// </summary>
        public ICommand RateCommand { get; private set; }

        /// <summary>
        /// Gets the send feedback command.
        /// </summary>
        public ICommand SendFeedbackCommand { get; private set; }

        /// <summary>
        /// Gets the share social network command.
        /// </summary>
        public ICommand ShareSocialNetworkCommand { get; private set; }

        /// <summary>
        /// Gets the share to e-mail command.
        /// </summary>
        public ICommand ShareToMailCommand { get; private set; }

        /// <summary>
        /// The rate.
        /// </summary>
        private void Rate()
        {
            _marketplaceReviewService.Show();
        }

        /// <summary>
        /// The send feedback.
        /// </summary>
        private void SendFeedback()
        {
            const string To = "saramgsilva@gmail.com";
            const string Subject = "My Feedback";
            var body = "This the body";
            _emailComposeService.Show(To, Subject, body);
        }

        /// <summary>
        /// The share social network.
        /// </summary>
        private void ShareSocialNetwork()
        {
            const string Message = "This application is amazing, should try it! See in";
            _shareLinkService.Show("Cimbalino Toolkit Sample", Message, new Uri(_appUrl, UriKind.Absolute));
        }

        /// <summary>
        /// The share to mail.
        /// </summary>
        private void ShareToMail()
        {
            const string Subject = "Cimbalino Toolkit Sample";
            var body = string.Concat("This application is amazing, you should try it! See in", _appUrl);
            _emailComposeService.Show(Subject, body);
        }
    }
}
    
