using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_III_EJE2.Models
{
    public class notas
    {
        public int id {  get; set; }
        public string? estudiante { get; set; }
        public double parciales { get; set; }
        public double laboratorios { get; set; }
        public double final { get; set; }

    }
}
