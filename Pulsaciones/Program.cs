using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace Pulsaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo continuar;
            
            PersonaService personaService = new PersonaService();
            do
            {
                Console.Clear();
                Persona persona1 = new Persona();
                Console.WriteLine("DIGITE NOMBRE: ");
                persona1.Nombre = Console.ReadLine();
                Console.WriteLine("Digite IDENTIDAD:");
                persona1.Identificacion = Console.ReadLine();
                Console.WriteLine("Digite Sexo:");
                persona1.Sexo = Console.ReadLine();
                Console.WriteLine("Digite EDAD:");
                persona1.Edad = Convert.ToInt32(Console.ReadLine());
              
                personaService.CalcularPulsacion(persona1);
                personaService.Guardar(persona1);
                Console.WriteLine($"SU PULSACION ES: {persona1.Pulsaciones}");
                Console.WriteLine("DESEA CONTUNIAR[S/N]: ");
                continuar = Console.ReadKey();

            } while (continuar.KeyChar==('s') || continuar.KeyChar==('S'));
            Console.WriteLine("--------- LISTA DE PERSONAS----------");
            Console.Clear();
            foreach (var item in personaService.Consultar())
            {
                Console.WriteLine($"IDENTIFICACION: {item.Identificacion} NOMBRE: {item.Nombre} EDAD: {item.Edad} SEXO: {item.Sexo} Pulsaciones: {item.Pulsaciones}");
            }
            
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
            Console.WriteLine("---------Buscar por IDENTIFICACION----------");
            Console.WriteLine("DIGITE IDENTIDAD: ");
            string id = Console.ReadLine();
            Persona persona= personaService.BuscarxId(id);
            Console.WriteLine($"IDENTIFICACION: {persona.Identificacion} NOMBRE: {persona.Nombre} EDAD: {persona.Edad} SEXO: {persona.Sexo} Pulsaciones: {persona.Pulsaciones}");
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
            Console.WriteLine("---------ELIMINAR----------");
            Console.WriteLine("DIGITE IDENTIDAD A ELIMINAR: ");
            string idEliminar = Console.ReadLine();
            Persona personaEliminar = personaService.BuscarxId(idEliminar);
            string mensaje =personaService.Eliminar(personaEliminar);
            Console.WriteLine(mensaje);
            Console.WriteLine("--------- LISTA DE PERSONAS----------");
            Console.Clear();
            foreach (var item in personaService.Consultar())
            {
                Console.WriteLine($"IDENTIFICACION: {item.Identificacion} NOMBRE: {item.Nombre} EDAD: {item.Edad} SEXO: {item.Sexo} Pulsaciones: {item.Pulsaciones}");
            }
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
            Console.WriteLine("---------Modificar----------");
            Console.WriteLine("DIGITE IDENTIDAD A MODUIFICAR: ");
            string idModificar = Console.ReadLine();
            Persona personaModificar = personaService.BuscarxId(idModificar);
            Console.WriteLine($"IDENTIFICACION: {personaModificar.Identificacion} NOMBRE: {personaModificar.Nombre} EDAD: {personaModificar.Edad} SEXO: {personaModificar.Sexo} Pulsaciones: {personaModificar.Pulsaciones}");
            personaModificar.Identificacion = idModificar;
            Console.WriteLine("DIGITE NOMBRE: ");
            personaModificar.Nombre = Console.ReadLine();
            Console.WriteLine("Digite Sexo:");
            personaModificar.Sexo = Console.ReadLine();
            Console.WriteLine("Digite EDAD:");
            personaModificar.Edad = Convert.ToInt32(Console.ReadLine());
            personaService.CalcularPulsacion(personaModificar);
            personaService.Modificar(personaModificar);
            Console.WriteLine("--------- LISTA DE PERSONAS----------");
            Console.Clear();
            foreach (var item in personaService.Consultar())
            {
                Console.WriteLine($"IDENTIFICACION: {item.Identificacion} NOMBRE: {item.Nombre} EDAD: {item.Edad} SEXO: {item.Sexo} Pulsaciones: {item.Pulsaciones}");
            }
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
            
        }
    }
}
