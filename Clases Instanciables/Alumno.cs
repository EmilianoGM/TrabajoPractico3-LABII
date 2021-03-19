using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Constructores
        /// <summary>
        /// Constructor de alumno
        /// </summary>
        public Alumno() : base()
        { }

        /// <summary>
        /// Construcor parametrizado de alumno
        /// </summary>
        /// <param name="id">Numero del legajo del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno, debe concordar con su nacionalidad</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase a la que asiste el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Numero del legajo del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno, debe concordar con su nacionalidad</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase a la que asiste el alumno</param>
        /// <param name="estadoCuenta">Estado de la cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve la clase en las que partipa el alumno
        /// </summary>
        /// <returns>La clase en forma de string</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this.claseQueToma.ToString();
        }

        /// <summary>
        /// Devuelve los datos del alumno en forma de string
        /// </summary>
        /// <returns>Los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            string retorno = "";
            retorno += base.MostrarDatos() + "\n";
            retorno += "\nESTADO DE CUENTA: " + this.estadoCuenta.ToString() + "\n" + this.ParticiparEnClase();
            return retorno;
        }

        /// <summary>
        /// Hace publicos los datos del alumno en forma de string
        /// </summary>
        /// <returns>Los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Compara un alumno con una clase segun si la toma y no es deudor
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Devuelve TRUE si el alumno toma la clase y su estado de cuenta no es deudor, FALSE en cualquier otro caso</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (!(Object.Equals(a, null)))
            {
                if (a.claseQueToma.Equals(clase) && !(a.estadoCuenta.Equals(EEstadoCuenta.Deudor)))
                {
                    return true;
                }
            }          
            return false;
        }

        /// <summary>
        /// Compara un alumno con una clase segun si la toma o no
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Devuelve FALSE si el alumno toma la clase, TRUE en cualquier otro caso</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (!(Object.Equals(a, null)))
            {
                if (!(a.claseQueToma.Equals(clase)))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
