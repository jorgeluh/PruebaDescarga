namespace PruebaDescarga
{
    using System.Net;
    using System.Web;
    using System.Web.SessionState;

    /// <summary>
    /// Manejador que permite descargar el archivo sólo si ya fue generado y se cuenta con una sesión válida.
    /// </summary>
    public class DescargarArchivo : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            // TODO: validar la sesión del usuario.
            if (context.Session["Sesion"] == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            string direccionArchivo = (string)context.Session["ArchivoGenerado"];

            // Si el archivo se encuentra generado, hace una redirección hacia la verdadera ubicación del archivo y la elimina para que no
            // se pueda volver a acceder.

            // TODO: aún es necesario eliminar físicamente el archivo luego de un tiempo prudente para permitir la descarga.
            if (!string.IsNullOrEmpty(direccionArchivo))
            {
                context.Session.Remove("ArchivoGenerado");

                context.Response.StatusCode = (int)HttpStatusCode.Redirect;
                context.Response.Headers.Add("Location", direccionArchivo);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }    
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}