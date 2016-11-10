using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Instructor:PersonaGimnacio
    {
        public Queue<Gimnasio.EClases> _clasesDelDia;
        static Random _random;

        static Instructor()
        {
            Instructor._random = new Random();
            
        }

        public Instructor(int id, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad)
            : base(id, nombre, apellido,dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            _randomClase();
            _randomClase();
        }

        private void _randomClase()
        {
            _clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 3));
        }

        protected override string ParticiparEnClase()
        {
            
            StringBuilder clase = new StringBuilder();

            for (int i = 0; i < _clasesDelDia.Count; i++)
            {
                clase.AppendLine("CLASES DEL DÍA: " + this._clasesDelDia.Dequeue().ToString());
            }

            return clase.ToString();

        }

        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            if(!Object.Equals(i,null))
            {
                foreach (Gimnasio.EClases item in i._clasesDelDia)
                {
                    if (clase == item)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i==clase);
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(ToString());

            datos.AppendLine(this.ParticiparEnClase());

            return datos.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }


    }
}
