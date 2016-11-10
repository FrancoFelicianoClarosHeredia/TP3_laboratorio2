using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno:PersonaGimnacio
    {
        public enum EEstadoCuenta
        {
            MesPrueba,
            Deudor,
            AlDia,
        }

        private Gimnasio.EClases _claseQueToma;
        private Alumno.EEstadoCuenta _estadoCuenta;


        public Alumno(int id, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido,dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido,string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, Alumno.EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            
            this._estadoCuenta = estadoCuenta;
        }



        protected override string MostrarDatos()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine(ToString());

            aux.AppendLine(ParticiparEnClase());
            
            aux.AppendLine("CUOTA" + this._estadoCuenta.ToString());

            return aux.ToString();
        }


        public override string ToString()
        {
            return MostrarDatos();
        }

        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (!Object.Equals(a,null))
            {
                if(a._claseQueToma== clase)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (!Object.Equals(a, null))
            {
                if (a._claseQueToma != clase)
                {
                    return true;
                }
            }

            return false;
        }

        protected override string ParticiparEnClase()
        {
            return "Participa En Clase De: " + this._claseQueToma.ToString();
        }

    }



}
