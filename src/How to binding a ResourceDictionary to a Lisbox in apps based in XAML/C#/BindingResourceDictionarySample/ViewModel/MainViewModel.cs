using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace BindingResourceDictionarySample.ViewModel
{
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
        private Company _selectedCompany;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Companies = new Dictionary<Company, int>
            {
                {
                    new Company
                    {
                        Name = "Microsoft", Url="www.microsoft.com"
                    }, 1
                },
                {
                    new Company
                    {
                        Name = "Google", Url="www.google.com"
                    }, 2
                },
                {
                    new Company
                    {
                        Name = "Apple", Url="www.apple.com"
                    }, 3
                }
            };
        }

        /// <summary>
        /// Gets or sets the selected company.
        /// </summary>
        /// <value>The selected company.</value>
        public Company SelectedCompany
        {
            get { return _selectedCompany; }
            set { Set(() => SelectedCompany, ref _selectedCompany, value); }
        }

        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        /// <value>The companies.</value>
        public Dictionary<Company, int> Companies { get; set; }
    }
}