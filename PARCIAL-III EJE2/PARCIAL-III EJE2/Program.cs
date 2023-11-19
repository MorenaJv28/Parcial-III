using PARCIAL_III_EJE2.DAO;
using PARCIAL_III_EJE2.Data;
using PARCIAL_III_EJE2.Models;
using PARCIAL_III_EJE2.BL;
using Microsoft.Extensions.Options;

notas nota = new notas();
Prom promedios = new Prom();
Crdnotas db = new Crdnotas();
Promedio logi = new Promedio();

bool vali1 = true;
int idWidth = 9;
int nomWidth = 20;
int parWidth = 15;
int labWidth = 15;
int finalWidth = 9;

Console.WriteLine("\tBienvenido al registro de notas");

while (vali1 == true)
{
    try
    {
        Console.Write("\n\tMenu  \n1- Agregar  \n2- Actualizar  \n3- Ver lista de notas \n4- Eliminar \n5- Salir \n-> ");
        var Option = int.Parse(Console.ReadLine());

        switch (Option)
        {
            case 1:
                Console.WriteLine("\n\tAgregar notas");
                try
                {
                    Console.Write("\nIngrese el nombre del estudiante: ");
                    nota.estudiante = Console.ReadLine();
                    Console.Write("\nIngresa la nota del primer laboratorio: ");
                    promedios.LAB1 = double.Parse(Console.ReadLine());
                    Console.Write("\nIngresa la nota del segundo laboratorio: ");
                    promedios.LAB2 = double.Parse(Console.ReadLine());
                    Console.Write("\nIngresa la nota del tercer laboratorio: ");
                    promedios.LAB3 = double.Parse(Console.ReadLine());
                    Console.Write("\nIngresa la nota del primer parcial: ");
                    promedios.PARCIAL1 = double.Parse(Console.ReadLine());
                    Console.Write("\nIngresa la nota del segundo parcial: ");
                    promedios.PARCIAL2 = double.Parse(Console.ReadLine());
                    Console.Write("\nIngresa la nota del tercer parcial: ");
                    promedios.PARCIAL3 = double.Parse(Console.ReadLine());
                    nota.laboratorios = logi.CalcularLab(promedios);
                    nota.parciales = logi.CalcularParcial(promedios);
                    nota.final = logi.CalcularNotaFinal(promedios);
                    db.CreateNota(nota);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n\tError \nDetalles: {ex.Message}");
                }
                break;


            case 2:
                try
                {
                    Console.WriteLine("\t\nActualizar notas\n");
                    Console.WriteLine($"\n{"Codigo".PadRight(idWidth)} {"Nombres".PadRight(nomWidth)} {"Laboratorios".PadRight(labWidth)} {"Parciales".PadRight(parWidth)} {"Nota final".PadRight(finalWidth)}");
                    Console.WriteLine(new string('-', idWidth + nomWidth + labWidth + parWidth + finalWidth + 8));
                    foreach (var i in db.Viewnota())
                    {
                        Console.WriteLine($"{i.id.ToString().PadRight(idWidth)} {i.estudiante.PadRight(nomWidth)} {i.laboratorios.ToString().PadRight(labWidth)} {i.parciales.ToString().PadRight(parWidth)} {i.final.ToString().PadRight(finalWidth)}   |");
                    }
                    Console.Write("\nIngrese el codigo que desea actualizar: ");
                    var buscar = db.notasindivi(int.Parse(Console.ReadLine()));

                    if (buscar == null)
                    {
                        Console.WriteLine("Codigo no existente");
                    }
                    else
                    {
                        Console.Write(@$"
Ingresa el campo que  actualizara

1- Estudiante 
2- Laboratorio 
3- Parcial 
4- Nota Final

=> ");
                        var Lector = int.Parse(Console.ReadLine());
                        switch (Lector)
                        {
                            case 1:
                                Console.Write("Ingrese el estudiante: ");
                                buscar.estudiante = Console.ReadLine();
                                break;

                            case 2:
                                Console.Write("\nIngresa la nota del primer laboratorio: ");
                                promedios.LAB1 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngresa la nota del segundo laboratorio: ");
                                promedios.LAB2 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngresa la nota del tercer laboratorio: ");
                                promedios.LAB3 = double.Parse(Console.ReadLine());
                                buscar.laboratorios = logi.CalcularLab(promedios);
                                buscar.final = Math.Round(buscar.parciales + buscar.laboratorios, 2);
                                break;

                            case 3:
                                Console.Write("\nIngresa la nota del primer parcial: ");
                                promedios.PARCIAL1 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngresa la nota del segundo parcial: ");
                                promedios.PARCIAL2 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngresa la nota del tercer parcial: ");
                                promedios.PARCIAL3 = double.Parse(Console.ReadLine());
                                buscar.parciales = logi.CalcularParcial(promedios);
                                buscar.final = Math.Round(buscar.parciales + buscar.laboratorios, 2);
                                break;

                            case 4:
                                Console.Write("\nIngresa la nota del primer laboratorio: ");
                                promedios.LAB1 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngresa la nota del segundo laboratorio: ");
                                promedios.LAB2 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngresa la nota del tercer laboratorio: ");
                                promedios.LAB3 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngresa la nota del primer parcial: ");
                                promedios.PARCIAL1 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngresa la nota del segundo parcial: ");
                                promedios.PARCIAL2 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngresa la nota del tercer parcial: ");
                                promedios.PARCIAL3 = double.Parse(Console.ReadLine());
                                buscar.laboratorios = logi.CalcularLab(promedios);
                                buscar.parciales = logi.CalcularParcial(promedios);
                                buscar.final = logi.CalcularNotaFinal(promedios);
                                break;
                        }
                        db.UpdateNota(buscar, Lector);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\t Error \nDetalles: {ex.Message}");
                }
                break;

            case 3:
                try
                {
                    var listarNotas = db.Viewnota();

                    Console.WriteLine($"\n{"Codigo".PadRight(idWidth)} {"Nombres".PadRight(nomWidth)} {"Laboratorios".PadRight(labWidth)} {"Parciales".PadRight(parWidth)} {"Nota final".PadRight(finalWidth)}");
                    Console.WriteLine(new string('-', idWidth + nomWidth + labWidth + parWidth + finalWidth + 8));

                    foreach (var i in db.Viewnota())
                    {
                        Console.WriteLine($"{i.id.ToString().PadRight(idWidth)} {i.estudiante.PadRight(nomWidth)} {i.laboratorios.ToString().PadRight(labWidth)} {i.parciales.ToString().PadRight(parWidth)} {i.final.ToString().PadRight(finalWidth)}   |");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\t Error \nDetalles: {ex.Message}");
                }
                break;

            case 4:
                try
                {

                    Console.WriteLine("\n\tEliminar Notas");
                    Console.WriteLine($"\n{"Codigo".PadRight(idWidth)} {"Nombres".PadRight(nomWidth)} {"Laboratorios".PadRight(labWidth)} {"Parciales".PadRight(parWidth)} {"Nota final".PadRight(finalWidth)}");
                    Console.WriteLine(new string('-', idWidth + nomWidth + labWidth + parWidth + finalWidth + 8));

                    foreach (var i in db.Viewnota())
                    {
                        Console.WriteLine($"{i.id.ToString().PadRight(idWidth)} {i.estudiante.PadRight(nomWidth)} {i.laboratorios.ToString().PadRight(labWidth)} {i.parciales.ToString().PadRight(parWidth)} {i.final.ToString().PadRight(finalWidth)}   |");
                    }
                    Console.Write("\nIngresa el código del registro a eliminar: ");

                    var notasindivi = int.Parse(Console.ReadLine());

                    if (notasindivi == null)
                    {
                        Console.WriteLine("El registro no existe");
                    }
                    else
                    {
                        Console.WriteLine(db.DeleteNota(notasindivi));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\t Error \nDetalles: {ex.Message}");
                }
                break;

            case 5:
                vali1 = false;
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\t Error \nDetalles: {ex.Message}");
    }
}