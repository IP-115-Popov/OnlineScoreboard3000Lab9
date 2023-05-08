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
        //
        private string firmImage;
        private string name;
        private string appointment;
        private string departureTime;
        private string arrivalTime;
        private string sector;
        private string status;
        //
        private string company;
        private string typeVS;
        private string reseption;
        private string startOfRegistration;
        private string boarding;
        private string boardingGateSector;
        public Reis()
        {
        }
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
        public string DepartureTime
        {
            get => departureTime;
            set => SetAndRaise(ref departureTime, value);
        }
        public string ArrivalTime
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
        public string Reseption
        {
            get => reseption;
            set => SetAndRaise(ref reseption, value);
        }
        public string StartOfRegistration
        {
            get => startOfRegistration;
            set => SetAndRaise(ref startOfRegistration, value);
        }
        public string Boarding
        {
            get => boarding;
            set => SetAndRaise(ref boarding, value);
        }
        public string BoardingGateSector
        {
            get => boardingGateSector;
            set => SetAndRaise(ref boardingGateSector, value);
        }
    }
}
