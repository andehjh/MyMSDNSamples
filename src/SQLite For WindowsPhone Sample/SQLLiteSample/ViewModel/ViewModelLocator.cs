/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:SQLLiteSample"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

namespace SQLLiteSample.ViewModel
{
    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight.Ioc;

    using Microsoft.Practices.ServiceLocation;

    using SQLLiteSample.Service;

    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<IDataService>())
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }

            if (!SimpleIoc.Default.IsRegistered<IMessageBoxService>())
            {
                SimpleIoc.Default.Register<IMessageBoxService, MessageBoxService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EditUniversityViewModel>();
            SimpleIoc.Default.Register<CreateUniversityViewModel>();
            SimpleIoc.Default.Register<SeeStudentsViewModel>();
            SimpleIoc.Default.Register<EditStudentViewModel>();
            SimpleIoc.Default.Register<CreateStudentViewModel>();
        }

        /// <summary>
        /// Gets the edit student view model.
        /// </summary>
        /// <value>
        /// The edit student view model.
        /// </value>
        public EditStudentViewModel EditStudentViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditStudentViewModel>();
            }
        }

        /// <summary>
        /// Gets the create student view model.
        /// </summary>
        /// <value>
        /// The create student view model.
        /// </value>
        public CreateStudentViewModel CreateStudentViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CreateStudentViewModel>();
            }
        }

        /// <summary>
        /// Gets the main.
        /// </summary>
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// Gets the edit university view model.
        /// </summary>
        public EditUniversityViewModel EditUniversityViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditUniversityViewModel>();
            }
        }

        /// <summary>
        /// Gets the create university view model.
        /// </summary>
        public CreateUniversityViewModel CreateUniversityViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CreateUniversityViewModel>();
            }
        }

        /// <summary>
        /// Gets the see students view model.
        /// </summary>
        /// <value>
        /// The see students view model.
        /// </value>
        public SeeStudentsViewModel SeeStudentsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SeeStudentsViewModel>();
            }
        }
        

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}