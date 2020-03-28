using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class PersonaService
    {
        private PersonaRepository personaRepository;
        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }
        public void CalcularPulsacion(Persona persona)
        {
            
            if (persona.Sexo.ToUpper().Equals("F"))
            {
                persona.Pulsaciones = (220 - persona.Edad) / 10;
                
            }
            else
            {
                if (persona.Sexo.ToUpper().Equals("M"))
                {
                    persona.Pulsaciones = (210 - persona.Edad) / 10;
                }
                else
                {
                    persona.Pulsaciones = 0;
                }

            }
        }
        public void Guardar(Persona persona)
        {
            personaRepository.Guardar(persona);
        }
        public List<Persona> Consultar()
        {
            return personaRepository.Consultar();
        }
        public  void Modificar(Persona persona)
        {
            personaRepository.Modificar(persona);
        }
        public  Persona BuscarxId(string identificacion)
        {

            return personaRepository.Buscar(identificacion);
        }
        public  string Eliminar(Persona personaEliminar)
        {
            
                if (personaRepository.Buscar(personaEliminar.Identificacion) != null)
                {
                    personaRepository.Eliminar(personaEliminar);
                    return ($"Los Datos de la {personaEliminar.Nombre} se han eliminado Satisfactoriamente");
                }
                else
                {
                    return ($"Lo sentimos, {personaEliminar.Nombre} no se encuentra registrada");
                }
            

        }
    }
}
