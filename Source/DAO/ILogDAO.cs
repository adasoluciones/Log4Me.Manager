using Ada.Framework.Development.Log4Me.Entities;
using System;
using System.Collections.Generic;

namespace Ada.Framework.Development.Log4Me.Manager.DAO
{
    internal interface ILogDAO
    {
        IList<RegistroInLineTO> ObtenerFlujoInLine(string threadGUID, Func<RegistroInLineTO, bool> filtro = null);
        IList<RegistroInLineTO> ObtenerEjecucionInLine(string methodGUID, Func<RegistroInLineTO, bool> filtro = null);
        string ObtenerThreadGUID(string methodGUID);
    }
}
