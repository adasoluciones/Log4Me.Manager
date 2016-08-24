using Ada.Framework.Development.Log4Me.Entities;
using System;
using System.Collections.Generic;

namespace Ada.Framework.Development.Log4Me.Manager.Business
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public interface ILogNegocio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="methodGUID"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        MetodoTO ObtenerEjecucion(string methodGUID, Func<RegistroInLineTO, bool> filtro = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="threadGUID"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        MetodoTO ObtenerFlujo(string threadGUID, Func<RegistroInLineTO, bool> filtro = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="threadGUID"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        IList<RegistroInLineTO> ObtenerFlujoInLine(string threadGUID, Func<RegistroInLineTO, bool> filtro = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="methodGUID"></param>
        /// <returns></returns>
        string ObtenerThreadGUID(string methodGUID);
    }
}
