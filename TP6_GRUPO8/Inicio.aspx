<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP6_GRUPO8.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="Styles.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblGrupo" runat="server" Text="Grupo N° 8"></asp:Label>
            <br />
            <br />
            <br />
        </div>
        <div class="Ejercicios-container">
            <div id="ej1">
                <asp:HyperLink ID="hpEjercicio1" class="link" runat="server" NavigateUrl="~/Ejercicio1.aspx">Ejercicio 1</asp:HyperLink>
            </div>
            <div id="ej2">
                 <asp:HyperLink ID="hpEjercicio2" class="link" runat="server" NavigateUrl="~/Ejercicio2.aspx">Ejercicio 2</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
