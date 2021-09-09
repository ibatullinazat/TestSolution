using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditAPI.Dtos
{
    public class RequestedCreditDto
    {
        public int Id { get; set; }
        public int? CreditType { get; set; }
        public decimal? RequestAmount { get; set; }
        public string RequestCurrency { get; set; }
        public decimal? AnnualSalary { get; set; }
        public decimal? MonthlySalary { get; set; }
        public string CompanyName { get; set; }
        public string Comment { get; set; }
    }
}
