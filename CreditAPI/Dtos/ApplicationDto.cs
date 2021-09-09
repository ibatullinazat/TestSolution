using CreditAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditAPI.Dtos
{
    public class ApplicationDto
    {
        public string ApplicationNum { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string BranchBank { get; set; }
        public string BranchBankAddr { get; set; }
        public int? CreditManagerId { get; set; }
        public PersonDto Applicant { get; set; }
        public RequestedCreditDto RequestedCredit { get; set; }
    }
}
