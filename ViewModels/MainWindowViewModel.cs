using Avalonia.Animation;
using OnlineScoreboard3000.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace OnlineScoreboard3000.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool checkDeparture;
        private bool checkArrival;
        private bool checkYesterday;
        private bool checkToday;
        private bool checkTomorrow;
        private ObservableCollection<Reis> reisList;
        public MainWindowViewModel()
        {
            CheckDeparture = true;
            CheckArrival = false;
            CheckYesterday = false;
            CheckToday = true;
            CheckTomorrow = false;
            ReisList = new ObservableCollection<Reis>();
            //ReisList.Add(new Reis());
            using (ReisDataBaseContext db = new ReisDataBaseContext())
            {
                db.Reises.Add(new Reis()
                {
                    FirmImage = "iMAGE",
                    Name = "S5 5211",
                    Appointment = "Благовещенск",
                    DepartureTime = new DateTime(2015, 7, 20, 18, 30, 25),
                    ArrivalTime = new DateTime(2015, 7, 20, 18, 30, 25),
                    Sector = "A",
                    Status = "Вылетел",
                    Company = "Аллроса",
                    TypeVS = "В-737",
                    Reseption = 12,
                    StartOfRegistration = new DateTime(2015, 7, 20, 18, 30, 25),
                    Boarding = new DateTime(2015, 7, 20, 18, 30, 25),
                    BoardingGateSector = 3,
                });
                db.SaveChanges();
            }
            using (ReisDataBaseContext db = new ReisDataBaseContext())
            {
                var reises = db.Reises.ToList();
                foreach(Reis i in reises)
                {
                    ReisList.Add(i);
                }
            }
        }
        public bool CheckDeparture
        {
            get => checkDeparture;
            set
            {
                this.RaiseAndSetIfChanged(ref checkDeparture, value);
                if (CheckDeparture == true)
                {
                    CheckArrival = false;
                }
            }
        }
        public bool CheckArrival
        {
            get => checkArrival;
            set
            {
                this.RaiseAndSetIfChanged(ref checkArrival, value);
                if (CheckArrival == true)
                {
                    CheckDeparture = false;
                }
            }
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
        private ObservableCollection<Reis> ReisList
        {
            get => reisList;
            set
            {
                this.RaiseAndSetIfChanged(ref reisList, value);
            }
        }
    }
}
