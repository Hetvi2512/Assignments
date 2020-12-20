using SourceControlFinalAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
    }
}