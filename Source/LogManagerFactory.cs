using Ada.Framework.Development.Log4Me.Manager.Business;

namespace Ada.Framework.Development.Log4Me.Manager
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public static class LogManagerFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="origen"></param>
        /// <returns></returns>
        public static ILogNegocio ObtenerLogManagerFactory(OrigenDato origen)
        {
            return new LogNegocio(origen);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="origen"></param>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public static ILogNegocio ObtenerLogManagerFactory(OrigenDato origen, string ruta)
        {
            return new LogNegocio(origen, ruta);
        }
    }
}
