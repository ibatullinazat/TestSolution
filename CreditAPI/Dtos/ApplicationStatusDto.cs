using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditAPI.Dtos
{
    public class ApplicationStatusDto
    {
        public int Id { get; set; }
        public string ApplicationNum { get; set; }
        public DateTime? ScoringDate { get; set; }
        public bool ScoringStatus { get; set; }
    }
}
