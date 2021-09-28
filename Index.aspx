<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PruebaDescarga.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prueba de descarga</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <button type="button" id="generar">Generar archivo</button>
        </div>
        <div id="enlace"></div>
    </form>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            // Llama al manejador que genera el archivo y guarda su ruta en una variable de sesión para habilitar la descarga.
            $("#generar").click(function () {
                $.ajax({
                    url: "/GenerarArchivo.ashx",
                    success: function(resultado) {
                        if (resultado) {
                            $("#enlace").prepend("<a href='/DescargarArchivo.ashx' class='enlaceDescarga'>Descargar (este enlace sólo puede ser usado una vez)</a>");
                        } else {
                            alert("Ocurrió un error generando el archivo.");
                        }
                    }
                });
            });

            // Este es un selector "vivo", se aplica a elementos que aún no existen en la página. Se encarga de eliminar el enlace de
            // descarga una vez usado.
            $(this.body).on("click", ".enlaceDescarga", function() {
                $(".enlaceDescarga").remove();
            });
        });
    </script>
</body>
</html>
