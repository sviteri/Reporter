<%@ Page Title="" Language="C#" MasterPageFile="~/formularios/IESS/IESS.Master" AutoEventWireup="true" CodeBehind="IESSBienvenida.aspx.cs" Inherits="Reportes.formularios.IESS.IESSBienvenida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Bienvenida</h3>
    <p>Modulo de reportes IESS</p>

    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-primary">
              <div class="panel-heading">
                <h3 class="panel-title">Reportes Diarios</h3>
              </div>
              <div class="panel-body">
                  <ul>
                      <li><a href="#"  data-toggle="modal" data-target="#myModal">
                  Reporte Diario de Agendamiento IN
                </a></li>
                      <li><a>Reporte Mensual</a></li>
                  </ul>
                 
              </div>
            </div>
        </div>
        <div class="col-md-6"></div>
    </div>
   

   

     


   

<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Reporte Diario de Agendamiento IN</h4>
      </div>
      <div class="modal-body">
       <table class="table">
        <tr>
            <td>Fecha:</td>
            <td>
                <asp:TextBox ID="txt_fecha" runat="server" CssClass="datepicker form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBoxList ID="chk_ubicaciones" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0" Text="Quito 30"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Quito 32"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Guayaquil"></asp:ListItem>
                    
                </asp:CheckBoxList>
            </td>
            <td>
                
            </td>
        </tr>
    </table>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
        <asp:Button Text="Generar" runat="server" CssClass="btn btn-primary" OnClick="Unnamed_Click" />
      </div>
    </div>
  </div>
</div>

    
    
    <asp:GridView  ID="gv_prueba" runat="server" 
        CssClass="table table-condenced"  
        BorderColor="Transparent">
    </asp:GridView>
</asp:Content>
