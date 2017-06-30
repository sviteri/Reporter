<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TDCAdicional.aspx.cs" Inherits="Reportes._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .exito_div{
            color: green;
        }
    </style>
  <div class="">
        <h2>Generador de Reportes</h2>
        <p>Campaña Tarjeta de Credito Adicional <strong>Banco Pichincha</strong></p>

        <asp:LinkButton ID="btn_generar_Reporte" ClientIDMode="Static" runat="server" CssClass="btn btn-success" 
            OnClick="btn_generar_Reporte_Click" >
           <i class="fa fa-print" aria-hidden="true"></i> Generar reporte
        </asp:LinkButton>
      <div  id="div_cargando" style="display: none" >
            <img src="Content/Images/cargando3.gif" width="100" height="100" />
        </div>

      <asp:GridView ID="gv_test" runat="server"></asp:GridView>

        
    
        <div class="alert alert-success" runat="server" visible="false" id="div_mensaje">
            <asp:Label Text="" runat="server" ID="lbl_mensaje" />
        </div>
    </div>

    <asp:Label Text="" runat="server" ID="lbl_fecha" />

    <div id="message" class="alert alert-primary" style="display: none">
    <div id="message-screen-mask" class="ui-widget-overlay ui-front "></div>
    <div id="message-text" class="alert alert-primary ">please wait...</div>
</div>
    

    <script>

        $(window).ready(function () {
            $('#btn_generar_Reporte').on('click', function (event) {
                $('#div_cargando').fadeIn();
                console.log("cargando");
            });
        });

        $(function () { 
            $('#btn_generar_Reporte').click(function () {
                ShowDownloadMessage();
                setTimeout('hide_cargando()', 7000);
            });
        })

        function ShowDownloadMessage() {
            $('#message-text').removeClass("exito_div");
            $('#message-text').text('Estamos Generando su reporte por favor espere lo descargaremos cuando este listo.');
            $('#message').show();
            window.addEventListener('focus', HideDownloadMessage, false);
        }

        function HideDownloadMessage() {
            window.removeEventListener('focus', HideDownloadMessage, false);
            $('#message-text').addClass("exito_div");
           // $('#message-text').html('<i class="fa fa-check" aria-hidden="true"></i> Reporte generado con exito');
            //hide_cargando();
            //$('#message').hide();
        }

        function hide_cargando() {
            $('#div_cargando').hide();
        }

        
    </script>
</asp:Content>
