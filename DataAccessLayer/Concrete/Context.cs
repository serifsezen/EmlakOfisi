using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Residence> Residences { get; set; }
    }
}
