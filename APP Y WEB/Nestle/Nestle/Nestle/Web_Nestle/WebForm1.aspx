<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web_Nestle.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>nestleee</title>
     <link href="https://use.fontawesome.com/releases/v5.0.6/css/all.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">

<%--    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" >--%>
    
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet"  data-version="1.1.0" href="styles/shards-dashboards.1.1.0.min.css">
    <link rel="stylesheet" href="styles/extras.1.1.0.min.css">
    <%--<link rel="stylesheet" href="https://ordasvit.com/realestatemanager15/templates/realtor/css/style.css" />--%>
    <script async defer src="https://buttons.github.io/buttons.js"></script>
    <link href="styles/realestamanager.css" rel="stylesheet" />
     <style> #close-sidebar:hover{
     color:#007BFF;
 }
 .main-sidebar .nav .nav-item:hover {
    box-shadow: inset 0.1875rem 0 0 #FF7C02 !important;   
    color: #FF7C02 !important;
}

 .btn-primary {
    color: #fff;
    background-color:#FF7C02 !important; /*#0676f8;*/
    border-color: #FF7C02 !important;
}
     </style>
    

    
</head>
<body class="h-100"> 
  <form id="form1" runat="server" method="post">
 
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <ul class="navbar-nav border-left flex-row ">
       <li class="nav-item border-right dropdown notifications">
                  <a class="nav-link nav-link-icon text-center" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <div class="nav-link-icon__wrapper">
                      <i class="material-icons">&#xE7F4;</i>
                    <asp:Label ID="LblCont" CssClass="badge badge-pill badge-danger" style="    margin-left: -12px;" runat="server" Text="0"></asp:Label>
                    </div>
                  </a>
                  <div class="dropdown-menu dropdown-menu-small" aria-labelledby="dropdownMenuLink">
                    <a class="dropdown-item" href="#">
                      <div class="notification__icon-wrapper">
                       <%-- <div class="notification__icon" style="    background-color: #f5f6f8;
    box-shadow: 0 0 0 1px #fff, inset 0 0 3px rgba(0,0,0,.2);
    width: 2.1875rem;
    height: 2.1875rem;
    line-height: 0;
    display: block;
    text-align: center;
    margin: auto;
    border-radius: 50%;">
                          
                        </div>--%>
                      </div>
                      <div class="notification__content">
                    <asp:UpdatePanel ID="updatePanel2" runat="server" UpdateMode="Conditional" 
                    ChildrenAsTriggers="true">
                    <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" Visible="false"></asp:GridView>
                        <asp:DataList ID="DtList" runat="server">
                            <ItemTemplate>
                      
              <b> <div class="notification__icon" style="    background-color: #f5f6f8;    box-shadow: 0 0 0 1px #fff, inset 0 0 3px rgba(0,0,0,.2);    width: 2.1875rem;    height: 2.1875rem;    line-height: 0;    display: block;    text-align: center;    /*margin: auto;*/    border-radius: 50%;">                          
                         <i class="material-icons" style="    color: #818ea3;   line-height: 2.0625rem;    font-size: 1.0625rem;    margin: 0;">&#xE8D1;

                         </i></div><asp:Label ID="lblCName" CssClass="d-none d-md-inline ml-1" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label></b>
                           <br />
                          <%--  <b>Usuario:</b>
                            <asp:Label ID="lblName"   CssClass="d-none d-md-inline ml-1" runat="server" Text='<%# Eval("Usuario") %>'></asp:Label>
                            <br />--%>
                            <b> Fecha:</b>
                            <asp:Label ID="lblCity"  CssClass="d-none d-md-inline ml-1" runat="server" Text=' <%# Eval("FecCrea") %>'></asp:Label>

                            <br />
                        
                            </ItemTemplate>
                        </asp:DataList>
                    <div style="display:none">
                    <asp:Button ID="btnBlock" class="Button" Text="BlockCalls" runat="server"       
                    onclick="Button1_Click" Enabled="True" Width="100px"  />  </div>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnBlock" EventName="Click"/> 
                    </Triggers>
                    </asp:UpdatePanel>
                      </div>
                    </a>
                    <a class="dropdown-item notification__all text-center" href="#"> View all Notifications </a>
                  </div>
                </li>
        </ul>
       
                             <script src="https://code.jquery.com/jquery-3.3.1.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.1/Chart.min.js"></script>
    <script src="https://unpkg.com/shards-ui@latest/dist/js/shards.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Sharrre/2.0.1/jquery.sharrre.min.js"></script>
    <script src="scripts/extras.1.1.0.min.js"></script>
    <script src="scripts/shards-dashboards.1.1.0.min.js"></script>
    <script src="scripts/app/app-blog-overview.1.1.0.js"></script>

        <script src="https://code.jquery.com/jquery-2.2.3.min.js"></script>
        <script src="scripts/jquery.signalR-2.2.0.min.js"></script>
    <script src="/signalr/hubs"></script>


   
        <%--<script src="https://code.jquery.com/jquery-3.3.1.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=" crossorigin="anonymous"></script>--%>
 <%--   <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Sharrre/2.0.1/jquery.sharrre.min.js"></script>
    <script src="scripts/extras.1.1.0.min.js"></script>--%>
 
    <script type="text/javascript">
        $(function () {
            // Click on notification icon for show notification
            $('span.noti').click(function (e) {
                e.stopPropagation();
                $('.noti-content').show();
                var count = 0;
                count = parseInt($('span.count').html()) || 0;
                //only load notification if not already loaded
                if (count > 0) {
                    updateNotification();
                }
                $('span.count', this).html('&nbsp;');
                //$("#LblCont").text(count)
            })
            // hide notifications
            $('html').click(function () {
                $('.noti-content').hide();
            })
            // update notification 
        
            //   recuento de notificaciones de actualización
            function updateNotificationCount() {
                var count = 0;
                count = parseInt($('span.count').html()) || 0;
                count++;
                $('span.count').html(count);
                $("#LblCont").text(count)
                alert('Nuevo Job');
                 document.getElementById("<%=btnBlock.ClientID %>").click();
            }
            // Signalr js código para iniciar hub y enviar recibir notificación
            var notificationHub = $.connection.notificationHub;
            $.connection.hub.start().done(function () {
                console.log('Notification hub started');
            });

            //Método de señalización para enviar un mensaje de servidor al cliente
            notificationHub.client.notify = function (message) {
                if (message && message.toLowerCase() == "added") {
                    updateNotificationCount();
                }
            }

        })
    </script>

    </form>
</body>
</html>
