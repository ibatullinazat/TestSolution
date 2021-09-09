using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoringAPI.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string ApplicationNum { get; set; }
        public bool ScoringStatus { get; set; }
        public DateTime? ScoringDate { get; set; }
    }
}
