using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Gimnasio
    {
        public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates,
            Yoga,
        }


        private List<Alumno> _alumnos;
        private List<Instructor> _instructor;
        private List<Jornada> _jornada;

        public Gimnasio()
        {
            this._alumnos= new List<Alumno>();
            this._instructor = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        public Jornada this[int i]
        {
            get { return this._jornada[i]; }

            set { this._jornada[i] = value; }
        }

        public static bool operator ==(Gimnasio g, Alumno a)
        {
            if (!Object.Equals(g,null) && !Object.Equals(a,null))
            {
                try
                {
                    foreach (Alumno item in g._alumnos)
                    {
                        if (item.DNI != a.DNI)
                        {
                            return true;
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new AlumnoRepetidoException();
                }
            }

            return false;
        }

        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g== a);
        }

        public static bool operator ==(Gimnasio g, Instructor i)
        {
            if (!Object.Equals(g,null) && !Object.Equals(i,null))
            {
                foreach (Instructor item in g._instructor)
                {
                    if (item == i)
                    {
                        return true;
                    }
                }
            }


            return false;
        }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g==i);
        }

        public static Instructor operator ==(Gimnasio g, Gimnasio.EClases clase)
        {
            if (!Object.Equals(g,null) && !Object.Equals(clase,null))
            {
                try
                {
                    for (int i = 0; i < g._instructor.Count; i++)
                    {
                        if (g._instructor[i] == clase)
                        {
                            return g._instructor[i];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Excepciones.SinInstructorException();


                }
            }


            return default(Instructor);
        }

        public static Instructor operator !=(Gimnasio g, Gimnasio.EClases clase)
        {
            if (!Object.Equals(g,null) && !Object.Equals(clase,null))
            {
                try
                {
                    for (int i = 0; i < g._instructor.Count; i++)
                    {
                        if (g._instructor[i] != clase)
                        {
                            return g._instructor[i];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Excepciones.SinInstructorException();


                }
            }


            return default(Instructor);
        }


        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (!Object.Equals(g,null) && !Object.Equals(a,null))
            {
                foreach (Alumno item in g._alumnos)
                {
                    if (a.DNI != item.DNI)
                    {
                        g._alumnos.Add(a);
                    }
                }
            }


            return g;
        }

        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {

            if (!Object.Equals(g,null) && !Object.Equals(i,null))
            {
                foreach (Instructor item in g._instructor)
                {
                    if (item.DNI != i.DNI)
                    {
                        g._instructor.Add(i);
                    }
                }
            }

            return g;

        }

        public static Gimnasio operator +(Gimnasio g, Gimnasio.EClases clase)
        {
            if (!Object.Equals(g,null) && !Object.Equals(clase,null))
            {
            try
            {
                if (!Object.Equals(g, null))
                {
                    foreach (Instructor item in g._instructor)
                    {
                        foreach (Gimnasio.EClases item2 in item._clasesDelDia)
                        {
                            if (item2 == clase)
                            {
                                Jornada j = new Jornada(clase, item);
                                g._jornada.Add(j);
                                return g;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
                throw new SinInstructorException();
            }
            }
            return null;
        }

        private string MostrarDatos(Gimnasio gim)
        {
            StringBuilder aux = new StringBuilder();
            if (!Object.Equals(gim,null))
            {
              
            

                    foreach (Alumno item in gim._alumnos)
                    {
                        aux.AppendLine(item.ToString());
                    }

                    foreach (Instructor item in gim._instructor)
                    {
                        aux.AppendLine(item.ToString());
                    }

                    foreach (Jornada item in gim._jornada)
                    {
                        aux.AppendLine(item.ToString());
                    }
                }
                    return aux.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }


        public static void Guardar(Gimnasio gim)
        {
            if (!Object.Equals(gim,null))
            {
                
            
            Xml<Gimnasio> xml = new Xml<Gimnasio>();

            string aux="C:\\Dato.xml";


            xml.guardar(aux, gim);
            }
        }

    }


}
