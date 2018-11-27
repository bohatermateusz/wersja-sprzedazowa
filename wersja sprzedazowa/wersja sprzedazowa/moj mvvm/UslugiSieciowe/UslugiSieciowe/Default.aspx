<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UslugiSieciowe.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UslugiSieciowe</title>
    <style type="text/css">
        body { color: #000000; background-color: white;
               font-family: Verdana, sans-serif; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>OsobyApp</h3>
        Usługa sieciowa: <a href="~/WebService/Osoby.asmx"
            runat="server">WebService/Osoby.asmx</a>
    </div>
    </form>
</body>
</html>

