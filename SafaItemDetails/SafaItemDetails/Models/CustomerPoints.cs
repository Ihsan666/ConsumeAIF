using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafaItemDetails.Models
{
    public class CustomerPoints
    {
        public string CustomerId { get; set; }
        public object Points { get; set; }
        public string type { get; set; }
        public string WebOrderId { get; set; }

        public string TransDate { get; set; }
    }
}