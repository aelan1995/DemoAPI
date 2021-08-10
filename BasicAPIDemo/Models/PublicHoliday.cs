using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAPIDemo.Models
{
    public class PublicHoliday
    {
        public string PublicholidayID { get; set; }
        public string date { get; set; }
        public string localName { get; set; }
        public string name { get; set; }
        public string countryCode { get; set; }
        public bool fixedName { get; set; }
        public bool globalName { get; set; }
        public string counties { get; set; }
        public int launchYear { get; set; }
        public string type { get; set; }
    }
}
