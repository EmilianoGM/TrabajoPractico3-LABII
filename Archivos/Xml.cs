using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivos<T>
    {
        /// <summary>
        /// Serializa datos en una archivo xml
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se guardan los datos</param>
        /// <param name="datos">Datos a serializar</param>
        /// <returns>Devuelve TRUE si lo completo, FALSE en caso contrario</returns>
        public bool Guardar(string archivo, T datos)
        {
            if (!string.IsNullOrEmpty(archivo) && !Object.Equals(datos, null))
            {
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    StreamWriter streamWriter = new StreamWriter(archivo);
                    xmlSerializer.Serialize(streamWriter, datos);
                    streamWriter.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return false;
        }

        /// <summary>
        /// Deserializa datos de una archivo xml
        /// </summary>
        /// <param name="archivo">>Ruta del archivo</param>
        /// <param name="datos">Datos deserializados</param>
        /// <returns>Devuelve TRUE si lo completo, FALSE en caso contrario</returns>
        public bool Leer(string archivo, out T datos)
        {
            if (!string.IsNullOrEmpty(archivo))
            {


                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    StreamReader streamReader = new StreamReader(archivo);
                    datos = (T)xmlSerializer.Deserialize(streamReader);
                    streamReader.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            datos = default(T);
            return false;
        }
    }
}
