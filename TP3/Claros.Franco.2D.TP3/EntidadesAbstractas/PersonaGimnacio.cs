using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnacio:Persona
    {
        private int _identificador;

        
        public PersonaGimnacio(int id, string nombre, string apellido,string dni,Persona.ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this._identificador = id;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine(ToString());

            aux.AppendLine("Identificador" + this._identificador.ToString());

            return aux.ToString();
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(PersonaGimnacio p1, PersonaGimnacio p2)
        {
            if (!Object.Equals(p1,null) && !Object.Equals(p2,null))
            {
                Type aux = p1.GetType();
                Type aux2= p2.GetType();

                if(aux==aux2 && p1._identificador==p2._identificador && p1.DNI== p2.DNI)
                {
                    return true;
                }
            }

            return false;
        }

        
        public static bool operator !=(PersonaGimnacio p1, PersonaGimnacio p2)
        {
         return !(p1==p2);   
        }


    }
}
