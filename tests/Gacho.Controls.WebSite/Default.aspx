<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gacho.Controls.WebSite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <gc:Text runat="server" Value="Hello World!" /><br />
        <gc:Text runat="server" Value="1 < 2 == true" Encoding="Html" /><br />
        <gc:Text runat="server" Value="<!-- Commentario! -->" Encoding="Raw" />
    </div>
    </form>
</body>
</html>
