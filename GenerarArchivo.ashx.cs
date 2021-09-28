namespace PruebaDescarga
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.SessionState;

    /// <summary>
    /// Manejador que simula la generación del archivo. Guarda su ruta en una variable de sesión para poder realizar la descarga.
    /// </summary>
    public class GenerarArchivo : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            // TODO: generar el archivo, esto sólo lo simula. En realidad sólo comprueba que haya algún archivo zip para probar la descarga.
            DirectoryInfo informacionDirectorio = new DirectoryInfo(context.Server.MapPath("~/Archivos"));
            FileInfo informacionArchivo =
                informacionDirectorio.GetFiles().FirstOrDefault(f => ".zip".Equals(f.Extension, StringComparison.OrdinalIgnoreCase));

            context.Response.ContentType = "application/json";
            if (informacionArchivo != null)
            {
                context.Session["ArchivoGenerado"] = $"/Archivos/{informacionArchivo.Name}";
                context.Response.Write("true");
            }
            else
            {
                context.Response.Write("false");
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