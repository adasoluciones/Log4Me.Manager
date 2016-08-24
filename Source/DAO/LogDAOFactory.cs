
namespace Ada.Framework.Development.Log4Me.Manager.DAO
{
    internal static class LogDAOFactory
    {
        internal static ILogDAO ObtenerDAO(OrigenDato origen)
        {
            ILogDAO instancia = null;
            switch (origen)
            {
                case OrigenDato.DataBase:
                    {
                        instancia = new DataBase.DataBaseDAO();
                        break;
                    }
                case OrigenDato.TextFromBegin:
                    {
                        instancia = new Text.TextFromBeginDAO();
                        break;
                    }
                case OrigenDato.TextFromEnd:
                    {
                        instancia = new Text.TextFromEndDAO();
                        break;
                    }
            }
            return instancia;
        }

        internal static ILogDAO ObtenerDAO(OrigenDato origen, string ruta)
        {
            ILogDAO instancia = null;
            switch (origen)
            {
                case OrigenDato.DataBase:
                    {
                        instancia = new DataBase.DataBaseDAO();
                        break;
                    }
                case OrigenDato.TextFromBegin:
                    {
                        instancia = new Text.TextFromBeginDAO(ruta);
                        break;
                    }
                case OrigenDato.TextFromEnd:
                    {
                        instancia = new Text.TextFromEndDAO(ruta);
                        break;
                    }
            }
            return instancia;
        }
    }
}
