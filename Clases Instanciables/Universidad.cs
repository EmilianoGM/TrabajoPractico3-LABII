using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Propiedades
        /// <summary>
        /// Establece o retorna el valor de la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Establece o retorna el valor de la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Establece o retorna el valor de la lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Establece o retorna el valor de una posicion en la lista de jornadas
        /// </summary>
        /// <param name="i">Indice de la posicion</param>
        /// <returns>Devuelve la jornada o null si el indice no es valido</returns>
        public Jornada this[int i]
        {
            get
            {
                if(i > -1 && i < this.jornada.Count())
                {
                    return this.jornada[i];
                }
                return null;
            }
            set
            {
                if (i > -1 && i < this.jornada.Count())
                {
                    this.jornada[i] = value;
                }
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de universidad
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve los datos de una universidad en forma de string
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>Los datos en forma de string</returns>
        private static string MostrarDatos(Universidad uni)
        {
            string retorno = "JORNADA:\n";
            if (!Object.Equals(uni.jornada, null))
            {
                foreach (Jornada jornada in uni.jornada)
                {
                    retorno += jornada.ToString() + "\n";
                }
            }
            return retorno;
        }

        /// <summary>
        /// Hace publicos los datos de la universidad en forma de string
        /// </summary>
        /// <returns>Los datos en forma de string</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Serializa los datos de la universidad en un archivo xml en el directorio de la aplicacion
        /// </summary>
        /// <param name="uni">Universidad a serializar</param>
        /// <returns>TRUE si lo completo</returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> xml = new Xml<Universidad>();
                xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"\Universidad.xml", uni);
                return true;
            } catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            
        }

        /// <summary>
        /// Deserializa datos de una universidad de un archivo xml en el directorio de la aplicacion y los devuelve
        /// </summary>
        /// <returns>La universidad desearializada</returns>
        public static Universidad Leer()
        {
            Universidad retorno;
            try
            {
                Xml<Universidad> xml = new Xml<Universidad>();
                xml.Leer(AppDomain.CurrentDomain.BaseDirectory + @"\Universidad.xml", out retorno);
                return retorno;
            } catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Compara una universidad y un alumno para saber si esta en la misma
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>TRUE si el alumno esta en la lista de alumnos de la universidad, FALSE en cualquier otro caso</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            if (Object.Equals(g.alumnos, null))
            {
                return false;
            }
            return g.alumnos.Contains(a);
        }

        /// <summary>
        /// Compara una universidad y un alumno para saber si no esta en la misma
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>FALSE si el alumno esta en la lista de alumnos de la universidad, TRUE en cualquier otro caso</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara una universidad y un profesor para saber si esta en la misma
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>TRUE si el profesor esta en la lista de profesores de la universidad, FALSE en cualquier otro caso</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            if (Object.Equals(g.profesores, null))
            {
                return false;
            }
            return g.profesores.Contains(i);
        }

        /// <summary>
        /// Compara una universidad y un profesor para saber si no esta en la misma
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>FALSE si el profesor esta en la lista de profesores de la universidad, TRUE en cualquier otro caso</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Crea y agrega a la lista de jornadas, una nueva jornada si hay profesores y alumnos que coincidan con la clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Tipo de clase</param>
        /// <returns>Devuelve la universidad con la jornada agregada si tiene profesor y alumnos</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            bool hayAlumnos = false;
            if (!Object.Equals(g.jornada, null))
            {
                Profesor profesor = g == clase;
                Jornada nuevaJornada = new Jornada(clase, profesor);
                if (!(Object.Equals(g.alumnos, null)))
                {
                    foreach (Alumno alumno in g.alumnos)
                    {
                        if (alumno == clase)
                        {
                            nuevaJornada += alumno;
                            hayAlumnos = true;
                        }
                    }
                    if (hayAlumnos)
                    {
                        g.jornada.Add(nuevaJornada);
                    }
                }
            }
            return g;
        }

        /// <summary>
        /// Agrega alumnos a la lista de alumnos de la universidad, si este ya se encuentra lanza una excepcion
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Devuelve la universidad con el alumno agregado</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (!(Object.Equals(u.alumnos, null)))
            {
                if (u != a)
                {
                    u.alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return u;
        }

        /// <summary>
        /// Agrega profesores a la lista de profesores de la universidad si este no se encuentra en ella
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor a agregar</param>
        /// <returns>Devuelve la universidad con el profesor agregado si pudo</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (!Object.Equals(u.profesores, null))
            {
                if (u != i)
                {
                    u.profesores.Add(i);
                }
            }
            return u;
        }

        /// <summary>
        /// Compara una universidad y una clase, para encontrar un profesor que coincide; lanza una excepcion en caso contrario 
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Tipo de clase</param>
        /// <returns>Devuelve el profesor que puede dar la clase</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            if (!(Object.Equals(u.profesores, null)))
            {
                foreach (Profesor profesor in u.profesores)
                {
                    if (profesor == clase)
                    {
                        return profesor;
                    }
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Compara una universidad y una clase, para encontrar un profesor que no coincida; lanza una excepcion en caso contrario
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Tipo de clase</param>
        /// <returns>Devuelve el primer profesor que no puede dar la clase</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            if (!(Object.Equals(u.profesores, null)))
            {
                foreach (Profesor profesor in u.profesores)
                {
                    if (profesor != clase)
                    {
                        return profesor;
                    }
                }
            }
            throw new SinProfesorException();
        }
        #endregion
    }
}
