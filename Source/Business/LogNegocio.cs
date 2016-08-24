using Ada.Framework.Development.Log4Me.Entities;
using Ada.Framework.Development.Log4Me.Entities.Mapper;
using Ada.Framework.Development.Log4Me.Manager.DAO;
using System;
using System.Collections.Generic;

namespace Ada.Framework.Development.Log4Me.Manager.Business
{
    internal class LogNegocio : ILogNegocio
    {
        private ILogDAO dao;

        public LogNegocio(OrigenDato origen)
        {
            dao = LogDAOFactory.ObtenerDAO(origen);
        }

        public LogNegocio(OrigenDato origen, string ruta)
        {
            dao = LogDAOFactory.ObtenerDAO(origen, ruta);
        }

        public MetodoTO ObtenerFlujo(string threadGUID, Func<RegistroInLineTO, bool> filtro = null)
        {
            return new LogEntityMapper().Convertir(ObtenerFlujoInLine(threadGUID), filtro);
        }

        public MetodoTO ObtenerEjecucion(string methodGUID, Func<RegistroInLineTO, bool> filtro = null)
        {
            return new LogEntityMapper().Convertir(dao.ObtenerEjecucionInLine(methodGUID), filtro);
        }
        
        public string ObtenerThreadGUID(string methodGUID)
        {
            return dao.ObtenerThreadGUID(methodGUID);
        }

        public IList<RegistroInLineTO> ObtenerFlujoInLine(string threadGUID, Func<RegistroInLineTO, bool> filtro = null)
        {
            return dao.ObtenerFlujoInLine(threadGUID, filtro);
        }
    }
}
