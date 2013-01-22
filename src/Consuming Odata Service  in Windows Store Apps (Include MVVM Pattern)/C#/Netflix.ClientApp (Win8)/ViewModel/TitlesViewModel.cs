// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TitlesViewModel.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The titles view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.ViewModel
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GalaSoft.MvvmLight;

    using Netflix.ClientApp.Helpers;
    using Netflix.ClientApp.Model;
    using Netflix.ClientApp.Services;

    /// <summary>
    /// The titles view model.
    /// </summary>
    public class TitlesViewModel : ViewModelBase
    {
        /// <summary>
        /// The service manager.
        /// </summary>
        private readonly IServiceManager _serviceManager;

        /// <summary>
        /// The error message.
        /// </summary>
        private string _errorMessage;

        /// <summary>
        /// The groups.
        /// </summary>
        private List<GroupView> _groups;

        /// <summary>
        /// The is to show progress.
        /// </summary>
        private bool _isToShowProgress;

        /// <summary>
        /// Initializes a new instance of the <see cref="TitlesViewModel"/> class. 
        /// </summary>
        /// <param name="serviceManager">
        /// The service Manager.
        /// </param>
        public TitlesViewModel(IServiceManager serviceManager)
        {
            _isToShowProgress = true;
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                RaisePropertyChanged(() => ErrorMessage);
            }
        }

        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        public List<GroupView> Groups
        {
            get
            {
                return _groups;
            }

            set
            {
                _groups = value;
                RaisePropertyChanged(() => Groups);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is to show progress.
        /// </summary>
        public bool IsToShowProgress
        {
            get
            {
                return _isToShowProgress;
            }

            set
            {
                _isToShowProgress = value;
                RaisePropertyChanged(() => IsToShowProgress);
            }
        }
        
        /// <summary>
        /// The load data async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task LoadDataAsync()
        {
            IsToShowProgress = true;

            try
            {
                var newDVDMovies = _serviceManager.LoadNewDVDMoviesAsync();
                var topDVDMovies = _serviceManager.LoadTopDVDMoviesAsync();

                await Task.WhenAll(new Task[] { newDVDMovies, topDVDMovies });

                if (newDVDMovies.IsCompleted && topDVDMovies.IsCompleted)
                {
                    Groups = new List<GroupView>
                                 {
                                     ViewModelHelper.GetGroupView(NameDefinitions.TopDVDMoviesId, NameDefinitions.TopDVDMoviesLabel, topDVDMovies.Result),
                                     ViewModelHelper.GetGroupView(NameDefinitions.NewDVDMoviesId, NameDefinitions.NewDVDMoviesLabel, newDVDMovies.Result)
                                 };
                }
                else
                {
                    ErrorMessage = GetErrorMessage(newDVDMovies, topDVDMovies);
                }

                IsToShowProgress = false;
            }
            catch (Exception exception)
            {
                IsToShowProgress = false;

                // TODO: Define a better message error for the user
                ErrorMessage = exception.Message;
            }
        }
        
        /// <summary>
        /// The get error message.
        /// </summary>
        /// <param name="newTitles">
        /// The new titles.
        /// </param>
        /// <param name="topTitles">
        /// The top titles.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetErrorMessage(Task<IEnumerable> newTitles, Task<IEnumerable> topTitles)
        {
            // TODO for each case should be defined an error message. Is not a good pratice to show a generic message that i will return :)
            // newTitles.IsCanceled - topTitles.IsCanceled - newTitles.IsFaulted topTitles.IsFaulted}
            return "In this moment is not possible to show the information. Please try later or contact the support.";
        }
    }
}