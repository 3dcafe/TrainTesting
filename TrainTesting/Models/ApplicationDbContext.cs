using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TrainTesting.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() :base ("DbConnection"){ }
        public DbSet<BaseRequest> Requests { get; set; }
        public DbSet<UrlParseData> UrlParseDatas { get; set; }
    }
}
