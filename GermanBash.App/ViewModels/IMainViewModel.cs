﻿using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace GermanBash.App.ViewModels
{
    public interface IMainViewModel
    {
        void Update();

        Task UpdateLockScreenAsync();

        void UpdateBackgroundTask();

        string SearchTerm { get; set; }

        bool IsBusy { get; }

        bool IsAwesomeEdition { get; }

        NavigationService NavigationService { set; }

        ICommand SearchCommand { get; }

        ICommand SetLockScreenCommand { get; }

        ICommand BackupCommand { get; }

        ICommand PinToStartCommand { get; }

        ICommand PinToStartProCommand { get; }
    }
}
