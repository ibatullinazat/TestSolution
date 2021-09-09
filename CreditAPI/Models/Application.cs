using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditAPI.Models
{
    public class Application : BaseModel
    {
        [Required]
        public string ApplicationNum { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string BranchBank { get; set; }
        public string BranchBankAddr { get; set; }
        public int? CreditManagerId { get; set; }

        public bool ScoringStatus { get; set; }
        public DateTime? ScoringDate { get; set; }

        public int ApplicantId { get; set; }
        public Person Applicant { get; set; }
        public int RequestedCreditId { get; set; }
        public RequestedCredit RequestedCredit { get; set; }
    }
}
