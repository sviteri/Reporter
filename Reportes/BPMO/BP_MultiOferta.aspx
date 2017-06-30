<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BP_MultiOferta.aspx.cs" Inherits="Reportes.BPMO.BP_MultiOferta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Reportes BP Multioferta</h1>
    <p>Genere el reporrte de Multioferta con un solo clic</p>

    <table>
        <tr>
            <td>Limite de registros:</td>
            <td>
                <asp:TextBox ID="txt_limite" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </td>
            <td>Agente:</td>
            <td>
                <asp:TextBox ID="txt_agente" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:LinkButton ID="btn_generar" runat="server" CssClass="btn btn-primary" 
                    OnClick="btn_generar_Click">
                    <i class="fa fa-filter"></i>Generar
                </asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <div class="alert alert-primary">
                    <i class="fa fa-info-circle"></i> Use los filtros solo en caso de que los necesite
                </div>
            </td>
        </tr>
    </table>

    <asp:GridView ID="gv_clientes" runat="server" CssClass="table table-responsive" BorderColor="Transparent" >

    </asp:GridView>
</asp:Content>
