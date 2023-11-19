using PARCIAL_III_EJE2.Data;
using PARCIAL_III_EJE2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_III_EJE2.DAO
{
    public class Crdnotas
    {
        context db = new context();
        public notas notasindivi(int id)
        {
            var buscar = db.notas.FirstOrDefault(x => x.id == id);
            return buscar;
        }

        public List<notas> Viewnota()
        {
            return db.notas.ToList();
        }

        public void CreateNota(notas nota)
        {
            try
            {
                notas notas = new notas();
                notas.estudiante = nota.estudiante;
                notas.parciales = nota.parciales;
                notas.laboratorio = nota.laboratorio;
                notas.final = nota.final;

                db.Add(notas);
                db.SaveChanges();

                Console.WriteLine($"La nota de {notas.estudiante} ha sido guardada");

            }
            catch (Exception EX)
            {
                Console.WriteLine($"Error al guardar \nDetalles: {EX}");

            }
        }

        public void UpdateNota(notas nota, int L)
        {
            try
            {
                var buscar = notasindivi(nota.id);
                if (buscar == null)
                {
                    Console.WriteLine(" id no existente");
                }

                else
                {
                    if (L == 1)
                    {
                        buscar.estudiante = nota.estudiante;
                    }

                    else if (L == 2)
                    {
                        buscar.parciales = nota.parciales;
                    }

                    else if (L == 3)
                    {
                        buscar.laboratorio = nota.laboratorio;
                    }

                    else if (L == 4)
                    {
                        buscar.final = nota.final;
                    }
                    db.Update(nota);
                    db.SaveChanges();
                }
            }
            catch (Exception EX)
            {
                Console.WriteLine($"Error al actualizar \nDetalles: {EX}");

            }

        }
        public void DeleteNota(int id)
        {
            var buscar = notasindivi(id);

            if (buscar == null)
            {
                Console.WriteLine("\nEl estudiante no existe");
            }
            else
            {
                string R;
                do
                {
                    Console.WriteLine("¿Desea eliminar este estudiante? (Si/No)");
                    R = Console.ReadLine();

                    if (R.Equals("Si", StringComparison.OrdinalIgnoreCase))
                    {
                        db.notas.Remove(buscar);
                        db.SaveChanges();
                        Console.WriteLine("\nEliminación exitosa");
                    }
                    else if (!R.Equals("No", StringComparison.OrdinalIgnoreCase)) 
                    {
                        Console.WriteLine("Respuesta no válida. Ingrese 'Si' para eliminar o 'No' para cancelar.");
                    }
                } while (!R.Equals("Si", StringComparison.OrdinalIgnoreCase) && !R.Equals("No", StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
             
