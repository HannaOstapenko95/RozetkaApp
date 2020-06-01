using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
namespace Rozetka
{
    public class DB : DbContext
    {
        public DB()
        {

        }
        public DB(DbContextOptions<DB> options) : base(options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<Mobile> Mobiles { get; set; }

    }
}
