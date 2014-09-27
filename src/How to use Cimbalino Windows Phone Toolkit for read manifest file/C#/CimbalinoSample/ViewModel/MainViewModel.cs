using GalaSoft.MvvmLight;

namespace CimbalinoSample.ViewModel
{
    using System.Collections;
    using System.Linq;

    using Cimbalino.Phone.Toolkit.Helpers;
    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The public application url.
        /// </summary>
        private readonly string _appUrl;

        /// <summary>
        /// The application manifest.
        /// </summary>
        private readonly ApplicationManifest _applicationManifest;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="emailComposeService">
        /// The email Compose Service.
        /// </param>
        /// <param name="applicationManifestService">
        /// The application Manifest Service.
        /// </param>
        /// <param name="marketplaceReviewService">
        /// The marketplace review service
        /// </param>
        /// <param name="shareLinkService">
        /// The share Link Service.
        /// </param>
        public MainViewModel(IApplicationManifestService applicationManifestService)
        {
            _applicationManifest = applicationManifestService.GetApplicationManifest();
            _appUrl = string.Concat("http://windowsphone.com/s?appid=", _applicationManifest.App.ProductId);
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return _applicationManifest.App.Title;
            }
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        public string Author
        {
            get
            {
                return _applicationManifest.App.Author;
            }
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        public string Version
        {
            get
            {
                return _applicationManifest.App.Version;
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return _applicationManifest.App.Description;
            }
        }

        /// <summary>
        /// Gets the product ID.
        /// </summary>
        public string ProductID
        {
            get
            {
                return _applicationManifest.App.ProductId;
            }
        }

        /// <summary>
        /// Gets the publisher.
        /// </summary>
        public string Publisher
        {
            get
            {
                return _applicationManifest.App.Publisher;
            }
        }

        /// <summary>
        /// Gets the capabilities.
        /// </summary>
        public IList Capabilities
        {
            get
            {
                return _applicationManifest.App.Capabilities.ToList();
            }
        }
    }
}
