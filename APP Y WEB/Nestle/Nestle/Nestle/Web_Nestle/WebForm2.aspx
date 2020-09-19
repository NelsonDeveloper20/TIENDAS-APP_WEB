<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Web_Nestle.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Js/jQuery.js"></script>
<script src="Js/notify.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <button type="button" onclick="setTimeout(myFunction, 3000);">activar nuevo</button>
    </div>
        <script>
            function myFunction() {
                $.notify("Hello World");
            }
        </script>
    </form>
</body>
</html>
