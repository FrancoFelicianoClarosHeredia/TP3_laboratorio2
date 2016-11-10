using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero,
        }

        private string _apellido;
        private string _nombre;
        private int _dni;
        private ENacionalidad _nacionalidad;

        #region propiedades

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }

        public int DNI
        {
            get { return this._dni; }

            set
            {
                    this._dni = ValidarDni(this._nacionalidad, value);                      
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }

            set { this._nacionalidad = value; }
        }

        public string Nombre
        {

            get { return this._nombre; }

            set
            {
                this._nombre = value;
            }
        }

        public string StringToDNI
        {
            set { this._dni = ValidarDni(this._nacionalidad, value); }
        }

        #endregion

        #region constructores

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this._dni = ValidarDni(nacionalidad,dni);
           
        }

        public Persona(string nombre, string apellido, string dni,  ENacionalidad nacionalidad)
            
        {
            this._dni = ValidarDni(nacionalidad, dni);
        }

        public Persona(string nombre,string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        #endregion


        #region metodos

        public int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            try
            {
                if (dni > 0 && dni < 89999999 && nacionalidad == ENacionalidad.Argentino)
                {
                    return dni;
                }
            }
            catch (Exception ex)
            {
                
                throw new DniInvalidoException(String.Format("Error",dni), ex);
                
            }
            finally
            {
                
            }

            return 0;

        }

        public int ValidarDni(ENacionalidad nacionalidad, string dni)
        {
            int aux = int.Parse(dni);

            try
            {
                if (aux > 0 && aux < 89999999 && nacionalidad == ENacionalidad.Argentino)
                {
                    return aux;
                }
            }
            catch (Exception ex)
            {
                throw new DniInvalidoException("error",ex);
                
            }
            return -1;
        }

        public string ValidarNombreApellido(string dato)
        {
            Regex rgx = new Regex("^[a-zA-Z]");

            if (!rgx.IsMatch(dato))
            {
                return dato;
            }

            return this._nombre;
        }

        public override string ToString()
        {
            StringBuilder Aux= new StringBuilder();

            Aux.AppendLine("Nombre y Apellido: "+this._nombre +" "+this._apellido );
            Aux.AppendLine("DNI:"+this._dni);
            Aux.AppendLine("Nacionalidad: "+this._nacionalidad.ToString());

            return Aux.ToString();
        }

        #endregion
    }


}
