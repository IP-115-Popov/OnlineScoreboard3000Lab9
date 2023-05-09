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
            //using (ReisDataBaseContext db = new ReisDataBaseContext())
            //{
            //    Random rnd = new Random();
            //    for (int i = 0; i < 10; i++)
            //    {
            //        db.Reises.Add(new Reis()
            //        {
            //            Name = "5211",
            //            Appointment = "Якутия",
            //            DepartureTime = DateTime.Now.AddDays(rnd.Next(0, 30)),
            //            ArrivalTime = DateTime.Now.AddDays(rnd.Next(0, 30)),
            //            Sector = "С",
            //            Status = "Прилетел",
            //            Company = "S7 Airlines",
            //            TypeVS = "А-737",
            //            Reseption = rnd.Next(0, 20),
            //            StartOfRegistration = DateTime.Now.AddDays(rnd.Next(0, 30)),
            //            Boarding = DateTime.Now.AddDays(rnd.Next(0, 30)),
            //            BoardingGateSector = rnd.Next(0, 20),
            //        });
            //    }
            //    db.SaveChanges();
            //}     
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
                IQueryable<Reis>? reises = null;
                if (CheckDeparture)
                {
                    if (CheckYesterday)
                    {
                        reises = db.Reises.Where(p => p.DepartureTime.Day == DateTime.Now.AddDays(-1).Day);
                    }
                    else if (CheckToday)
                    {
                        reises = db.Reises.Where(p => p.DepartureTime.Day == DateTime.Now.Day);
                    }
                    else if (CheckTomorrow)
                    {
                        reises = db.Reises.Where(p => p.DepartureTime.Day == DateTime.Now.AddDays(1).Day);
                    }
                }
                else if (CheckArrival)
                {
                    if (CheckYesterday)
                    {
                        reises = db.Reises.Where(p => p.ArrivalTime.Day == DateTime.Now.AddDays(-1).Day);
                    }
                    else if (CheckToday)
                    {
                        reises = db.Reises.Where(p => p.ArrivalTime.Day == DateTime.Now.Day);
                    }
                    else if (CheckTomorrow)
                    {
                        reises = db.Reises.Where(p => p.ArrivalTime.Day == DateTime.Now.AddDays(1).Day);
                    }
                }
                if (reises != null) foreach (Reis i in reises.ToList())
                {
                   if (ReisList != null) ReisList.Add(i);
                }
            }
        }  
    }
}
