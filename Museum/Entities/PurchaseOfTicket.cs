using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Museum.Entities
{
    public class PurchaseOfTicket
    {
        [Key]
        public int PurchaseOfTicketsId { get; set; }
        public int ClientId { get; set; }
        public int EventId { get; set; }
        public int Count { get; set; }
        public string DateOfPurchase { get; set; }
        public int Cost { get; set; }
        
    }
}