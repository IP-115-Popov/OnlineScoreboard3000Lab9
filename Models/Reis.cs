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
        private string firmImage;
        private string name;
        private string appointment;
        private string departure;
        private string arrival;
        private string sector;
        private string status;

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
        public string Departure
        {
            get => departure;
            set => SetAndRaise(ref departure, value);
        }
        public string Arrival
        {
            get => arrival;
            set => SetAndRaise(ref arrival, value);
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
    }
}
