using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Museum.Entities;

namespace Museum.Models
{
    public class MContext:DbContext
    {

      
            public DbSet<Client> Clients { get; set; }
            public DbSet<Event> Events { get; set; }
            public DbSet <PurchaseOfTicket> PurchaseOfTickets { get; set; }
            public DbSet<Photo> Photos { get; set; }
        
    }
}