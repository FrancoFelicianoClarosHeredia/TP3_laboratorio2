using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    public class Xml<T>:IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    ser.Serialize(writer, datos);

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
        


        public bool leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader read = new XmlTextReader(archivo))
                {
                    XmlSerializer sur = new XmlSerializer(typeof(T));

                    datos = (T)sur.Deserialize(read);

                    return true;
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                datos = default(T);
                return false;
            }
        }
    }
}
