using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Northwind.Data.Entity
{
    class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
            Database.Connection.ConnectionString = "server=.;database=Northwind;trusted_connection=true";
        }
        public DbSet<Category> Categories { get; set; }



    }
}
