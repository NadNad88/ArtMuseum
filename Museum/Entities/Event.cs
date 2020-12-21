using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Museum.Entities
{
    public class Event
    
    {
        [Key]
        public int EventId { get; set; }
        public int PhotoId { get; set; }
        public string NameOfEvent { get; set; }
        public string Description { get; set; }
        public int CountOfTickets { get; set; }
        public string DateOfEvent { get; set; }
        public int CostOfTicket { get; set; }
      


    }
}