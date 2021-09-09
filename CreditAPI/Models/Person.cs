using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditAPI.Models
{
    public class Person : BaseModel
    {
        public Person()
        {
            Applications = new List<Application>();
        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateBirth { get; set; }
        public string CityBirth { get; set; }
        public string AddressBirth { get; set; }
        public string AddressCurrent { get; set; }
        public string INN { get; set; }
        public string SNILS { get; set; }
        public string PassportNum { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
