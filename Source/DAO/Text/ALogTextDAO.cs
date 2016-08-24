using Ada.Framework.Development.Log4Me.Entities;
using log4net.Appender;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ada.Framework.Development.Log4Me.Manager.DAO.Text
{
    internal abstract class ALogTextDAO : ILogDAO
    {
        protected FileStream reader;

        public ALogTextDAO()
        {
            IAppender appender = null; // LogFactory.ObtenerAppender();
            reader = new FileStream((appender as FileAppender).File, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        public ALogTextDAO(string ruta)
        {
            reader = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        protected RegistroInLineTO CargarRegistro(string[] registro)
        {
            return new RegistroInLineTO()
            {
                ThreadGUID = registro[0].Trim(),
                MethodGUID = registro[1].Trim(),
                Clase = ReestablecerRegistro(registro[2].Trim()),
                Metodo = ReestablecerRegistro(registro[3].Trim()),
                Tipo = Tipo.ObtenerEnumeracion(registro[4].Trim()) as Tipo,
                Fecha = Convert.ToDateTime(registro[5].Trim()),
                NombreVariable = registro[6].Trim(),
                ValorVariable = ReestablecerRegistro(registro[8].Trim()),
                StackTrace = ReestablecerRegistro(registro[9].Trim()),
                Data = ReestablecerRegistro(registro[10].Trim()),
                TipoExcepcion = registro[11].Trim(),
                Mensaje = ReestablecerRegistro(registro[12].Trim()),
                Nivel = (Nivel)Enum.Parse(typeof(Nivel), string.IsNullOrEmpty(registro[13]) ? "DEBUG" : registro[13].Trim()),
                Correlativo = Convert.ToInt32(registro[14].Trim())
            };
        }

        protected string ReestablecerRegistro(string registro)
        {
            string apertura = ((char)1).ToString();
            string cierre = ((char)2).ToString();

            return registro
                .Replace("<", "[")
                .Replace(">", "]")
                .Replace(apertura, "<")
                .Replace(cierre, ">");
        }

        public abstract IList<RegistroInLineTO> ObtenerFlujoInLine(string threadGUID, Func<RegistroInLineTO, bool> filtro = null);

        public abstract IList<RegistroInLineTO> ObtenerEjecucionInLine(string methodGUID, Func<RegistroInLineTO, bool> filtro = null);

        public abstract string ObtenerThreadGUID(string methodGUID);
    }
}
