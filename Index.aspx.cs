namespace PruebaDescarga
{
    using System;
    using System.Web.UI;

    /// <summary>
    /// Página que presenta los controles para generar y descargar el archivo.
    /// </summary>
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Sólo sirve para simular la validación de sesión en la descarga.
            this.Session["Sesion"] = true;
        }
    }
}