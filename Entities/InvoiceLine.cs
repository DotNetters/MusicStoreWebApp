using System;
using System.Collections.Generic;

namespace MusicStoreWebApp.Entities
{
    public partial class InvoiceLine
    {
        public long InvoiceLineId { get; set; }
        public long InvoiceId { get; set; }
        public long Quantity { get; set; }
        public long TrackId { get; set; }
        public string UnitPrice { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Track Track { get; set; }
    }
}
