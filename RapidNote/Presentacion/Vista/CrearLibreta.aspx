﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearLibreta.aspx.cs" Inherits="RapidNote.Presentacion.Vista.CrearLibreta" MasterPageFile="~/SiteMaster/Site.Master" %>
  
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
        #error
        {
            text-align: center;
        }
        #faltandatos
        {
            text-align: center;
        }
        .style1
        {
            color: #CC0000;
        }
    </style>

    <div id="contenido">
        <br />
        
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
       
        <fieldset>
            <legend>Agregar Libreta</legend>
            <table align="center">
                <tr>
                    <td>
                        <asp:Label ID="lnombre" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="nombre" runat="server" Width="208px"></asp:TextBox>
                        <asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Display="Dynamic" ControlToValidate="nombre" ErrorMessage="Falta Ingreso de Email" class="style1" >*</asp:requiredfieldvalidator>
                    </td>
                </tr>
                
                
                <tr>
                    <td colspan="2" align="center">
                    <asp:Label  ID="mensajeError" runat="server" Text="Mensaje error"  Visible="false" 
                     style="text-align: center; color: #CC0000; font-weight: 700; font-style: italic"></asp:Label>
                    </td>
                </tr>
               
                <tr>

                    <td colspan="2" align="right">
                    <asp:Button ID="Cancelar" runat="server" Text="Cancelar" onclick="Cancelar_Click" />
                    &nbsp;
                        <asp:Button ID="registrar" runat="server" Text="Registrar" onclick="registrar_Click"/>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
    </div>
    <table align="center">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="*: Campo obligatorio"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

