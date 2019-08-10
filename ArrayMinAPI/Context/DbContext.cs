using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ArrayMinAPI.Context
{
    public class DBContext : DbContext
    {
        public DbSet<Models.RequestLog> RequestLogs { get; set; }
    }
}