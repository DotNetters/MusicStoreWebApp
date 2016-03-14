using System;
using System.Collections.Generic;

namespace MusicStoreWebApp.Entities
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceLine = new HashSet<InvoiceLine>();
        }

        public long InvoiceId { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingState { get; set; }
        public long CustomerId { get; set; }
        public string InvoiceDate { get; set; }
        public string Total { get; set; }

        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
