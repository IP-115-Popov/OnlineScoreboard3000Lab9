using Avalonia.Animation;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineScoreboard3000.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool checkYesterday;
        private bool checkToday;
        private bool checkTomorrow;

        public MainWindowViewModel()
        {
            CheckYesterday = false;
            CheckToday = true;
            CheckTomorrow = false;
        }
        public bool CheckYesterday
        {
            get => checkYesterday;
            set
            {
                this.RaiseAndSetIfChanged(ref checkYesterday, value);
                if (CheckYesterday == true)
                {
                    CheckToday = false;
                    CheckTomorrow = false;
                }
            }
        }
        public bool CheckToday
        {
            get => checkToday;
            set 
            {
                this.RaiseAndSetIfChanged(ref checkToday, value);
                if (CheckToday == true)
                {
                    CheckYesterday = false;
                    CheckTomorrow = false;
                }
            }
        }
        public bool CheckTomorrow
        {
            get => checkTomorrow;
            set
            {
                this.RaiseAndSetIfChanged(ref checkTomorrow, value);
                if (CheckTomorrow == true)
                {
                    CheckYesterday = false;
                    CheckToday = false;
                }
            }
        }

    }
}
