using Ada.Framework.Data.DBConnector;
using Ada.Framework.Data.DBConnector.Connections;
using Ada.Framework.Data.DBConnector.Entities.DataBase;
using Ada.Framework.Data.DBConnector.Queries;
using Ada.Framework.Development.Log4Me.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ada.Framework.Development.Log4Me.Manager.DAO.DataBase
{
    internal class DataBaseDAO : ILogDAO
    {
        private ConexionTO db = ConfiguracionBaseDatosFactory.ObtenerConfiguracionDeBaseDatos().ObtenerConexion("Log");

        private ConexionBaseDatos Conexion 
        { 
            get
            {
                ConexionBaseDatos retorno = ConexionBaseDatosFactory.ObtenerConexionBaseDatos(db);
                retorno.AutoConectarse = true;
                return retorno;
            }
        }
        
        public string ObtenerThreadGUID(string methodGUID)
        {
            Query query = Conexion.CrearQuery();

            query.Consulta = string.Format("SELECT [ThreadGUID] FROM Log WHERE MethodGUID='{0}'", methodGUID);

            string retorno = query.Obtener<string>().Respuesta;

            return retorno;
        }

        public IList<RegistroInLineTO> ObtenerFlujoInLine(string threadGUID, Func<RegistroInLineTO, bool> filtro = null)
        {
            IList<RegistroInLineTO> retorno;

            Query query = Conexion.CrearQuery();

            query.Consulta = string.Format(
                                @"SELECT [ThreadGUID]
                                          ,[MethodGUID]
                                          ,[Clase]
                                          ,[Metodo]
                                          ,[Tipo]
                                          ,[Fecha]
                                          ,[NombreVariable]
                                          ,[TipoVariable]
                                          ,[ValorVariable]
                                          ,[StackTrace]
                                          ,[Data]
                                          ,[TipoExcepcion]
                                          ,[Mensaje]
                                          ,[Nivel]
                                          ,[CorrelativoMetodo] 
                                FROM
                                            Log
                                WHERE
                                            ThreadGUID='{0}'",
                            threadGUID);
            if (filtro == null)
            {
                filtro = (c => true);
            }
            retorno = query.Consultar<RegistroInLineTO>().Select(c => c.Respuesta).Where(filtro).ToList();
            
            return retorno;
        }

        public IList<RegistroInLineTO> ObtenerEjecucionInLine(string methodGUID, Func<RegistroInLineTO, bool> filtro = null)
        {
            IList<RegistroInLineTO> retorno;

            Query query = Conexion.CrearQuery();

            query.Consulta = string.Format(
                                @"SELECT [ThreadGUID]
                                          ,[MethodGUID]
                                          ,[Clase]
                                          ,[Metodo]
                                          ,[Tipo]
                                          ,[Fecha]
                                          ,[NombreVariable]
                                          ,[TipoVariable]
                                          ,[ValorVariable]
                                          ,[StackTrace]
                                          ,[Data]
                                          ,[TipoExcepcion]
                                          ,[Mensaje]
                                          ,[Nivel]
                                          ,[CorrelativoMetodo] 
                                FROM
                                            Log
                                WHERE
                                            MethodGUID='{0}'",
                            methodGUID);

            if (filtro == null)
            {
                filtro = (c => true);
            }
            retorno = query.Consultar<RegistroInLineTO>().Select(c => c.Respuesta).Where(filtro).ToList();

            return retorno;
        }
    }
}
