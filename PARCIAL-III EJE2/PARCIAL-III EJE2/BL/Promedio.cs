using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PARCIAL_III_EJE2.Models;

namespace PARCIAL_III_EJE2.BL
{
    public class Promedio
    {
        public double CalcularLab(Prom pro)
        {
            double laboratorio = Math.Round(0.4 * ((pro.LAB1 + pro.LAB2 + pro.LAB3) / 3), 2);
            return laboratorio;
        }

        public double CalcularParcial(Prom pro)
        {
            double parcial = Math.Round(0.6 * ((pro.PARCIAL1 + pro.PARCIAL2 + pro.PARCIAL3) / 3), 2);
            return parcial;
        }
        public double CalcularNotaFinal(Prom pro)
        {
            double NF = Math.Round(CalcularLab(pro) + CalcularParcial(pro), 2);
            return NF;
        }

    }

}
