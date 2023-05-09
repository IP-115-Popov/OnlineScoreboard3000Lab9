using Avalonia.Animation;
using Microsoft.EntityFrameworkCore;
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
            /* using (ReisDataBaseContext db = new ReisDataBaseContext())
             {
                 db.Reises.Add(new Reis()
                 {
                     FirmImage = "",
                     Name = "S5 5211",
                     Appointment = "Благовещенск",
                     DepartureTime = new DateTime(2023, 7, 20, 18, 30, 25),
                     ArrivalTime = new DateTime(2023, 7, 20, 18, 30, 25),
                     Sector = "A",
                     Status = "Вылетел",
                     Company = "Алроса",
                     TypeVS = "В-737",
                     Reseption = 12,
                     StartOfRegistration = new DateTime(2023, 7, 20, 18, 30, 25),
                     Boarding = new DateTime(2023, 7, 20, 18, 30, 25),
                     BoardingGateSector = 3,
                 });
                 db.Reises.Add(new Reis()
                 {
                     FirmImage = "",
                     Name = "S5 5211",
                     Appointment = "Благовещенск",
                     DepartureTime = new DateTime(2023, 7, 20, 18, 30, 25),
                     ArrivalTime = new DateTime(2023, 7, 20, 18, 30, 25),
                     Sector = "A",
                     Status = "Вылетел",
                     Company = "S7 Airlines",
                     TypeVS = "В-737",
                     Reseption = 12,
                     StartOfRegistration = new DateTime(2023, 7, 20, 18, 30, 25),
                     Boarding = new DateTime(2023, 7, 20, 18, 30, 25),
                     BoardingGateSector = 3,
                 });
                 db.SaveChanges();
             }*/
            Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
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
                    Update();
                }
            }
        }
        public ObservableCollection<Reis> ReisList
        {
            get => reisList;
            set
            {
                this.RaiseAndSetIfChanged(ref reisList, value);
            }
        }
        public void Update()
        {
            if (ReisList != null) ReisList.Clear();
            using (ReisDataBaseContext db = new ReisDataBaseContext())
            {
                var reises = db.Reises.AsQueryable();
                if (reises != null) return;
                if (CheckDeparture)
                {
                    if (CheckYesterday)
                    {
                    reises = reises.Where(p => p.DepartureTime.Day == DateTime.Now.AddDays(-1).Day);
                    }
                    else if (CheckToday)
                    {
                    reises = reises.Where(p => p.DepartureTime.Day == DateTime.Now.Day);
                    }
                    else if (CheckTomorrow)
                    {
                    reises = reises.Where(p => p.DepartureTime.Day == DateTime.Now.AddDays(1).Day);
                    }
                }
                else if (CheckArrival)
                {
                    if (CheckYesterday)
                    {
                        reises = reises.Where(p => p.ArrivalTime.Day == DateTime.Now.AddDays(-1).Day);
                    }
                    else if (CheckToday)
                    {
                        reises = reises.Where(p => p.ArrivalTime.Day == DateTime.Now.Day);
                    }
                    else if (CheckTomorrow)
                    {
                        reises = reises.Where(p => p.ArrivalTime.Day == DateTime.Now.AddDays(1).Day);
                    }
                   
                }
                foreach (Reis i in reises.ToList()) ReisList.Add(i);
            }
        }  
    }
}
