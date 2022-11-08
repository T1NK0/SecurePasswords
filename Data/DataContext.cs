using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer("Server = LAPTOP-H8E83SN4; Database = H4_Encryption; User Id=sa; Password=Kode1234!; TrustServerCertificate=True;",
            //    options => options.EnableRetryOnFailure());
            builder.UseSqlServer("Server = LAPTOP-H8E83SN4; Database = H4_Encryption; Trusted_Connection=True; Integrated Security=SSPI; TrustServerCertificate=True;");
        }
    }
}
