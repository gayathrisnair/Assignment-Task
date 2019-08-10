using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ArrayMinAPI.Models
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string Input { get; set; }
        public decimal Output { get; set; }
        internal static void ConfigureModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestLog>().ToTable("RequestLog", "dbo");
            modelBuilder.Entity<RequestLog>()
                .HasKey(e => new { e.Id });
        }
    }
    

}