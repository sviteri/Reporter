<%@ Page Title="" Language="C#" MasterPageFile="~/formularios/IESS/IESS.Master" AutoEventWireup="true" CodeBehind="IESSBienvenida.aspx.cs" Inherits="Reportes.formularios.IESS.IESSBienvenida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Bienvenida</h3>
    <p>Modulo de reportes IESS</p>
    
    <asp:GridView Visible="false" ID="gv_prueba" runat="server" CssClass="table table-condenced" AutoGenerateColumns="false" BorderColor="Transparent">
        <Columns>
            <asp:BoundField DataField="GestionId" HeaderText="ID" />
            <asp:BoundField DataField="ContactAddress" HeaderText="Numero" />
            <asp:BoundField DataField="FHGestion" HeaderText="Gestion" />
            <asp:BoundField DataField="Agente" HeaderText="Agente" />
            <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
            <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
        </Columns>
    </asp:GridView>
</asp:Content>
