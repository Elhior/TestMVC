using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UsersMVC.Models;

namespace UsersMVC.DAL
{
    public class UserContext: DbContext
    {
        public UserContext() : base("UserContext")
        {
        }

        public DbSet<User> User { get; set; }
    }
}