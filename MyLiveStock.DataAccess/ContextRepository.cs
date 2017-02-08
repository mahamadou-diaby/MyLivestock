using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entity.Transactions;
using Entity;

namespace MyLiveStock.DataAccess
{
    public class ContextRepository : DbContext
    {
        public DbSet<Rabbit> Rabbits { get; set; }
        public DbSet<Productrice> Productrice { get; set; }
        public DbSet<MiseBas> MiseBas { get; set; }
        public DbSet<Saillie> Saillies { get; set; }
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Death> Deaths { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}
