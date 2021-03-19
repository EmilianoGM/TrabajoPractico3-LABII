using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivos<string>
    {
        /// <summary>
        /// Guarda datos en un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se guardan los datos</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>Devuelve TRUE si lo completo, FALSE en caso contrario</returns>
        public bool Guardar(string archivo, string datos)
        {
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(datos))
            {
                try
                {
                    StreamWriter archivoAGuardar = new StreamWriter(archivo);
                    foreach (char c in datos)
                    {
                        archivoAGuardar.Write(c);
                        if (c == '\n')
                        {
                            archivoAGuardar.WriteLine();
                        }
                    }
                    archivoAGuardar.Close();
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
        /// Lee datos de un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos leidos</param>
        /// <returns>Devuelve TRUE si lo completo, FALSE en caso contrario</returns>
        public bool Leer(string archivo, out string datos)
        {       
            if (!string.IsNullOrEmpty(archivo))
            {
                try
                {
                    string retorno = "";
                    StreamReader archivoALeer = new StreamReader(archivo);
                    while (!archivoALeer.EndOfStream)
                    {
                        retorno += archivoALeer.ReadLine();
                    }
                    archivoALeer.Close();
                    datos = retorno;
                    return true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            datos = "";
            return false;
        }
    }
}
