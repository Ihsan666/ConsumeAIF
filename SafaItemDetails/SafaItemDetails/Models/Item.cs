using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafaItemDetails.Models
{
    public class Item
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public object Stock { get; set; }
    }
}