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
                notas.laboratorios = nota.laboratorios;
                notas.final = nota.final;

                db.Add(notas);
                db.SaveChanges();

                Console.WriteLine($"La nota de {notas.estudiante} ha sido guardada");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar \nDetalles: {ex}");

            }
        }

        public void UpdateNota(notas nota, int Lector)
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
                    if (Lector == 1)
                    {
                        buscar.estudiante = nota.estudiante;
                    }

                    else if (Lector == 2)
                    {
                        buscar.parciales = nota.parciales;
                    }

                    else if (Lector == 3)
                    {
                        buscar.laboratorios = nota.laboratorios;
                    }

                    else if (Lector == 4)
                    {
                        buscar.final = nota.final;
                    }
                    db.Update(nota);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar \nDetalles: {ex}");

            }

        }
        public string DeleteNota( int id)
        {
            var buscar = notasindivi(id);

            if (buscar == null)
            {
                Console.WriteLine("\nEl estudiante no existe");
            }
            else
            {
                string respuesta;
                do
                {
                    Console.WriteLine("¿Desea eliminar este estudiante? (Si/No)");
                    respuesta = Console.ReadLine();

                    if (respuesta.Equals("Si", StringComparison.OrdinalIgnoreCase))
                    {
                        db.notas.Remove(buscar);
                        db.SaveChanges();
                        Console.WriteLine("\nEliminación exitosa");
                    }
                    else if (!respuesta.Equals("No", StringComparison.OrdinalIgnoreCase)) 
                    {
                        Console.WriteLine("Respuesta no válida. Ingrese 'Si' para eliminar o 'No' para cancelar.");
                    }
                } while (!respuesta.Equals("Si", StringComparison.OrdinalIgnoreCase) && !respuesta.Equals("No", StringComparison.OrdinalIgnoreCase));
            }
            return string.Empty;

        }
    }
}
             
