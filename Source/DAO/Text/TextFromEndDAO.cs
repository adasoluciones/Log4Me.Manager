using Ada.Framework.Development.Log4Me.Entities;
using Ada.Framework.Extensions.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ada.Framework.Development.Log4Me.Manager.DAO.Text
{
    internal class TextFromEndDAO : ALogTextDAO
    {
        public TextFromEndDAO() { }
        public TextFromEndDAO(string ruta): base(ruta) { }

        public override IList<RegistroInLineTO> ObtenerFlujoInLine(string threadGUID, Func<RegistroInLineTO, bool> filtro = null)
        {
            IList<RegistroInLineTO> retorno = new List<RegistroInLineTO>();

            long posicionInicial = reader.Length;

            string linea = reader.ReadLineFromEnd(ref posicionInicial);
            string[] registro = linea.Split(';');
            
            while (posicionInicial > 0)
            {
                if (registro.Length == 16)
                {

                    if (registro[0].Trim() == threadGUID)
                    {
                        if ((filtro != null && filtro(CargarRegistro(registro))) || filtro == null)
                        {
                            retorno.Add(CargarRegistro(registro));
                        }

                        //Se compara si el registro iterante corresponde al la ejecución del Inicio del Application_BeginRequest.
                        if (registro[2] == "Application_BeginRequest" && registro[4] == "Inicio")
                        {
                            break;
                        }
                    }
                }

                linea = reader.ReadLineFromEnd(ref posicionInicial);
                registro = linea.Split(';');
            }
            return retorno.OrderBy(c => c.Correlativo).ToList();
        }

        public override string ObtenerThreadGUID(string methodGUID)
        {
            long posicionInicial = reader.Length;

            string linea = reader.ReadLineFromEnd(ref posicionInicial);
            string[] registro = linea.Split(';');

            while (posicionInicial > 0)
            {
                if (registro.Length == 16)
                {
                    if (registro[1].Trim() == methodGUID)
                    {
                        return registro[0].Trim();
                    }
                }

                linea = reader.ReadLineFromEnd(ref posicionInicial);
                registro = linea.Split(';');
            }
            return null;
        }

        public override IList<RegistroInLineTO> ObtenerEjecucionInLine(string methodGUID, Func<RegistroInLineTO, bool> filtro = null)
        {
            IList<RegistroInLineTO> retorno = new List<RegistroInLineTO>();

            long posicionInicial = reader.Length;

            string linea = reader.ReadLineFromEnd(ref posicionInicial);
            string[] registro = linea.Split(';');

            while (posicionInicial > 0)
            {
                if (registro.Length == 16)
                {
                    if (registro[1].Trim() == methodGUID)
                    {
                        if ((filtro != null && filtro(CargarRegistro(registro))) || filtro == null)
                        {
                            retorno.Add(CargarRegistro(registro));
                        }
                        if (registro[4] == "Inicio")
                        {
                            break;
                        }
                    }
                }

                linea = reader.ReadLineFromEnd(ref posicionInicial);
                registro = linea.Split(';');
            }
            return retorno.OrderBy(c => c.Correlativo).ToList();
        }
    }
}
