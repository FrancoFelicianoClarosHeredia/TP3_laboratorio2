using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EntidadesInstanciables
{
    public class Texto:IArchivo<string>
    {

        public bool guardar(string archivo, string datos)
        {
            try 
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.WriteLine(datos);

                    writer.Close();
                    return true;
                }
            }
                        
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return false;
            }

        }

        public bool leer(string archivo, out string datos)
        {
            string line = "";
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    while ((datos = reader.ReadLine()) != null)
                    {
                        System.Console.WriteLine(line);
                        
                    }
                }
                datos = line;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                datos = default(string);
                return false;
            }
        }
    }
}
