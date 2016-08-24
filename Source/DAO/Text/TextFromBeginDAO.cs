using Ada.Framework.Development.Log4Me.Entities;
using Ada.Framework.Extensions.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ada.Framework.Development.Log4Me.Manager.DAO.Text
{
    internal class TextFromBeginDAO : ALogTextDAO
    {
        public TextFromBeginDAO() { }
        public TextFromBeginDAO(string ruta) : base(ruta) { }

        public override IList<RegistroInLineTO> ObtenerFlujoInLine(string threadGUID, Func<RegistroInLineTO, bool> filtro = null)
        {
            IList<RegistroInLineTO> retorno = new List<RegistroInLineTO>();
            long inicio = 0;

            string linea = reader.ReadLine(ref inicio);

            while (!string.IsNullOrEmpty(linea))
            {
                string[] registro = linea.Split(';');

                if (registro.Length == 16)
                {
                    if (registro[0].Trim() == threadGUID)
                    {
                        retorno.Add(CargarRegistro(registro));
                    }
                }

                linea = reader.ReadLine(ref inicio);
            }
            return retorno;
        }

        public override string ObtenerThreadGUID(string methodGUID)
        {
            long inicio = 0;
            string linea = reader.ReadLine(ref inicio);
            while (!string.IsNullOrEmpty(linea))
            {
                string[] registro = linea.Split(';');

                if (registro.Length == 16)
                {
                    if (registro[1].Trim() == methodGUID)
                    {
                        return registro[0].Trim();
                    }
                }

                linea = reader.ReadLine(ref inicio);
            }
            return null;
        }

        public override IList<RegistroInLineTO> ObtenerEjecucionInLine(string methodGUID, Func<RegistroInLineTO, bool> filtro = null)
        {
            IList<RegistroInLineTO> retorno = new List<RegistroInLineTO>();
            long inicio = 0;
            string linea = reader.ReadLine(ref inicio);
            while (!string.IsNullOrEmpty(linea))
            {
                string[] registro = linea.Split(';');

                if (registro.Length == 16)
                {
                    if (registro[1].Trim() == methodGUID)
                    {
                        retorno.Add(CargarRegistro(registro));
                    }
                }

                linea = reader.ReadLine(ref inicio);
            }
            return retorno.OrderBy(c => c.Correlativo).ToList();
        }
    }
}
