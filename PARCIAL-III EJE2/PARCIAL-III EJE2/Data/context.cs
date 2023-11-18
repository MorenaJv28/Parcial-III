using Microsoft.EntityFrameworkCore;
using PARCIAL_III_EJE2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_III_EJE2.Data
{
    public class context : DbContext
    {
        public DbSet<notas> notas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BERA_JOVEL\\BERAJOVEL;Database=PROGRA;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }
}
