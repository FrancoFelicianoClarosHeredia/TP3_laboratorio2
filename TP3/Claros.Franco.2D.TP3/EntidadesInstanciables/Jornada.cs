using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.IO;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        private Jornada() 
        {
            _alumnos= new List<Alumno>();
        }



        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public static bool operator +(Jornada j, Alumno a)
        {
            if (!Object.Equals(j, null) && !Object.Equals(a, null))
            {
                foreach (Alumno item in j._alumnos)
                {
                    if (a != item)
                    {
                        j._alumnos.Add(a);
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            if (!Object.Equals(j, null) && !Object.Equals(a, null))
            {
                if (a == j._clase)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public override string ToString()
        {
            StringBuilder aux = new StringBuilder();

            foreach (Alumno item in this._alumnos)
            {
                aux.AppendLine(item.ToString());
            }


            aux.AppendLine("Clase: "+this._clase.ToString());

            aux.AppendLine("ISTRUCTOR: "+ this._instructor.ToString());

            return aux.ToString();
        }

        public static void Guardar(Jornada j)
        {
            if (!Object.Equals(j, null))
            {
                Texto tex = new Texto();

                tex.guardar(@"C:\ArchivoNuevo.txt", j.ToString());
            }
        }



    }
}
