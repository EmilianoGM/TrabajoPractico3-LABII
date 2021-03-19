using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores
        /// <summary>
        /// Constructor statico de profesor, inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de profesor
        /// </summary>
        public Profesor() : base() { }

        /// <summary>
        /// Constructor parametrizado de profesor, inicializa y agrega clases a clases del dia de forma aleatoria
        /// </summary>
        /// <param name="id">Numero del legajo del profesor</param>
        /// <param name="nombre">Nombre del profesor</param>
        /// <param name="apellido">Apellido del profesor</param>
        /// <param name="dni">DNI del profesor, debe concordar con su nacionalidad</param>
        /// <param name="nacionalidad">Nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Agrega clases a clases del dia de manera aleatoria
        /// </summary>
        private void _randomClases()
        {
            int numeroDeClase;
            int cantidadDeClases = 2;
            Universidad.EClases clase;
            if (!(Object.Equals(clasesDelDia, null)))
            {
                for (int i = 0; i < cantidadDeClases; i++)
                {
                    numeroDeClase = Profesor.random.Next(0, 4);
                    clase = (Universidad.EClases)Enum.ToObject(typeof(Universidad.EClases), numeroDeClase);
                    this.clasesDelDia.Enqueue(clase);
                }
            }
        }

        /// <summary>
        /// Devuelve las clases del dia del profesor en forma de string
        /// </summary>
        /// <returns>Las clases en forma de string</returns>
        protected override string ParticiparEnClase()
        {
            string retorno = "";
            retorno += "CLASES DEL DIA:\n";
            if (!(Object.Equals(clasesDelDia, null)))
            {
                foreach (Universidad.EClases clase in this.clasesDelDia)
                {
                    retorno += clase.ToString() + "\n";
                }
            }
            return retorno;
        }

        /// <summary>
        /// Hace publicos los datos del profesor
        /// </summary>
        /// <returns>Los datos del profesor en forma de string</returns>
        public override string ToString()
        {
            string retorno = "";
            retorno += this.MostrarDatos() + "\n";
            retorno += "\n" + this.ParticiparEnClase();
            return retorno;
        }  
        #endregion

        #region Operadores
        /// <summary>
        /// Compara un profesor y una clase para saber si esta en clases del dia
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Devuelve TRUE si la clase esta en clases del dia del profesor, FALSE en cualquier otro caso</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if (i != null && !(Object.Equals(i.clasesDelDia, null)))
            {
                if (i.clasesDelDia.Contains(clase))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Compara un profesor y una clase para saber si no esta en clases del dia
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Devuelve FALSE si la clase esta en clases del dia del profesor, TRUE en cualquier otro caso</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
        
    }
}
