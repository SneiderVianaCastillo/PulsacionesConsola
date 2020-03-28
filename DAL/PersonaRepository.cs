using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class PersonaRepository
    {
        List<Persona> personas;
        private string  ruta=@"Persona.txt";
        public void Guardar(Persona persona)
        {
            FileStream file = new FileStream(ruta,FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{persona.Identificacion};{persona.Nombre};{persona.Sexo};{persona.Edad};{persona.Pulsaciones}");
            escritor.Close();
            file.Close();
         }
        public List<Persona> Consultar()
        {
            personas = new List<Persona>();
            string linea = string.Empty;
            FileStream filestream = new FileStream(ruta,FileMode.OpenOrCreate,FileAccess.Read);
            StreamReader lector = new StreamReader(filestream);
            while ((linea = lector.ReadLine()) != null)
            {
                Persona persona = Mapear(linea);
                personas.Add(persona);
            }
            lector.Close();
            filestream.Close();
            return personas;
        }
        public Persona Mapear(string linea)
        {
            Persona persona = new Persona();
            char delimiter = ';';
            string[] MatrizPersona = linea.Split(delimiter);
            persona.Identificacion = MatrizPersona[0];
            persona.Nombre = MatrizPersona[1];
            persona.Sexo = MatrizPersona[2];
            persona.Edad = Convert.ToInt32(MatrizPersona[3]);
            persona.Pulsaciones = Convert.ToDecimal(MatrizPersona[4]);
            return persona;
        }
        public Persona Buscar(string identificacion)
        {
            

            foreach (var item in personas)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }

            return null;
        }
        public void Eliminar(Persona personaEliminar)
        {
            personas.Clear();
            personas = Consultar();
            personas.Remove(personaEliminar);
            FileStream source = new FileStream(ruta, FileMode.Create);
            source.Close();
            foreach (var item in personas)
            {
                if (personaEliminar.Identificacion != item.Identificacion)
                {
                    Guardar(item);
                }


            }

        }
        public void Modificar(Persona persona)
        {
            personas.Clear();
            personas = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in personas)
            {
                if (persona.Identificacion != item.Identificacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(persona);
                }
            }
        }
    }
}
