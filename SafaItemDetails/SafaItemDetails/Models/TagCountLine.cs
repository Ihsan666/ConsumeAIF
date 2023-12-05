using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafaItemDetails.Models
{
    public class TagCountLine
    {
        public string JournalId { get; set; }
        public string BatchId { get; set; }
        public double Qty { get; set; }
        public string Barcode { get; set; }
        public string ItemId { get; set; }

    }
}