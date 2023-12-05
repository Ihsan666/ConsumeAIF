using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafaItemDetails.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmpID { get; set; }
        public bool isRetail { get; set; }
        public DateTime dbo { get; set; }
        public DateTime EmpStartDate { get; set; }
        public string department { get; set; }
    }
}