using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineScoreboard3000.Models
{
    public class Reis : AbstractNotifyPropertyChanged
    {
        public long Id { get; set; }
        //
        private string firmImage;
        private string name;
        private string appointment;
        private DateTime departureTime;
        private DateTime arrivalTime;
        private string sector;
        private string status;
        //
        private string company;
        private string typeVS;
        private int reseption;
        private DateTime startOfRegistration;
        private DateTime boarding;
        private int boardingGateSector;

        public string FirmImage
        {
            get => firmImage;
            set => SetAndRaise(ref firmImage, value);
        }
        public string Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }
        public string Appointment
        {
            get => appointment;
            set => SetAndRaise(ref appointment, value);
        }
        public DateTime DepartureTime
        {
            get => departureTime;
            set => SetAndRaise(ref departureTime, value);
        }
        public DateTime ArrivalTime
        {
            get => arrivalTime;
            set => SetAndRaise(ref arrivalTime, value);
        }
        public string Sector
        {
            get => sector;
            set => SetAndRaise(ref sector, value);
        }
        public string Status
        {
            get => status;
            set => SetAndRaise(ref status, value);
        }
        //
        public string Company
        {
            get => company;
            set => SetAndRaise(ref company, value);
        }
        public string TypeVS
        {
            get => typeVS;
            set => SetAndRaise(ref typeVS, value);
        }
        public int Reseption
        {
            get => reseption;
            set => SetAndRaise(ref reseption, value);
        }
        public DateTime StartOfRegistration
        {
            get => startOfRegistration;
            set => SetAndRaise(ref startOfRegistration, value);
        }
        public DateTime Boarding
        {
            get => boarding;
            set => SetAndRaise(ref boarding, value);
        }
        public int BoardingGateSector
        {
            get => boardingGateSector;
            set => SetAndRaise(ref boardingGateSector, value);
        }
    }
}
