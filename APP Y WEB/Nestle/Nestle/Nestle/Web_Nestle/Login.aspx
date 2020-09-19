<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Xpress.Login" %>
<!DOCTYPE html>

<html class="no-js h-100" lang="en">
<head runat="server">
    <title>Tienda</title>
     <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <meta name="description" content="A high-quality &amp; free Bootstrap admin dashboard template pack that comes with lots of templates and components.">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="styles/bootstrap-social.css" rel="stylesheet" />
  <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
<link href="https://netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet">
<script src="https://netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
<script src="https://code.jquery.com/jquery-1.11.1.min.js"></script>
    <style>
/* BASIC */
.btnIngresar{
        margin-bottom: 6px;

}
.btn-primary {
    color: #fff;
    background-color:#FF7C02 !important; /*#0676f8;*/
    border-color: #FF7C02 !important;
}
html {
  /*background-color: #56baed;*/
}

body {
  font-family: "Poppins", sans-serif;
  height: 100vh;
}

a {
  color: #92badd;
  display:inline-block;
  text-decoration: none;
  font-weight: 400;
}

h2 {
  text-align: center;
  font-size: 16px;
  font-weight: 600;
  text-transform: uppercase;
  display:inline-block;
  margin: 40px 8px 10px 8px; 
  color: #cccccc;
}



/* STRUCTURE */

.wrapper {
  display: flex;
  align-items: center;
  flex-direction: column; 
  justify-content: center;
  width: 100%;
  min-height: 100%;
  padding: 20px;
}

#formContent {
  -webkit-border-radius: 10px 10px 10px 10px;
  border-radius: 10px 10px 10px 10px;
  background: #fff;
  padding: 30px;
  width: 90%;
  max-width: 450px;
  position: relative;
  padding: 0px;
  -webkit-box-shadow: 0 30px 60px 0 rgba(0,0,0,0.3);
  box-shadow: 0 30px 60px 0 rgba(0,0,0,0.3);
  text-align: center;
}

#formFooter {
  background-color: #f6f6f6;
  border-top: 1px solid #dce8f1;
  padding: 25px;
  text-align: center;
  -webkit-border-radius: 0 0 10px 10px;
  border-radius: 0 0 10px 10px;
}



/* TABS */

h2.inactive {
  color: #cccccc;
}

h2.active {
  color: #0d0d0d;
  border-bottom: 2px solid #5fbae9;
}



/* ANIMATIONS */

/* Simple CSS3 Fade-in-down Animation */
.fadeInDown {
  -webkit-animation-name: fadeInDown;
  animation-name: fadeInDown;
  -webkit-animation-duration: 1s;
  animation-duration: 1s;
  -webkit-animation-fill-mode: both;
  animation-fill-mode: both;
}

@-webkit-keyframes fadeInDown {
  0% {
    opacity: 0;
    -webkit-transform: translate3d(0, -100%, 0);
    transform: translate3d(0, -100%, 0);
  }
  100% {
    opacity: 1;
    -webkit-transform: none;
    transform: none;
  }
}

@keyframes fadeInDown {
  0% {
    opacity: 0;
    -webkit-transform: translate3d(0, -100%, 0);
    transform: translate3d(0, -100%, 0);
  }
  100% {
    opacity: 1;
    -webkit-transform: none;
    transform: none;
  }
}

/* Simple CSS3 Fade-in Animation */
@-webkit-keyframes fadeIn { from { opacity:0; } to { opacity:1; } }
@-moz-keyframes fadeIn { from { opacity:0; } to { opacity:1; } }
@keyframes fadeIn { from { opacity:0; } to { opacity:1; } }

.fadeIn {
  opacity:0;
  -webkit-animation:fadeIn ease-in 1;
  -moz-animation:fadeIn ease-in 1;
  animation:fadeIn ease-in 1;

  -webkit-animation-fill-mode:forwards;
  -moz-animation-fill-mode:forwards;
  animation-fill-mode:forwards;

  -webkit-animation-duration:1s;
  -moz-animation-duration:1s;
  animation-duration:1s;
}

.fadeIn.first {
  -webkit-animation-delay: 0.4s;
  -moz-animation-delay: 0.4s;
  animation-delay: 0.4s;
}

.fadeIn.second {
  -webkit-animation-delay: 0.6s;
  -moz-animation-delay: 0.6s;
  animation-delay: 0.6s;
}

.fadeIn.third {
  -webkit-animation-delay: 0.8s;
  -moz-animation-delay: 0.8s;
  animation-delay: 0.8s;
}

.fadeIn.fourth {
  -webkit-animation-delay: 1s;
  -moz-animation-delay: 1s;
  animation-delay: 1s;
}

/* Simple CSS3 Fade-in Animation */
.underlineHover:after {
  display: block;
  left: 0;
  bottom: -10px;
  width: 0;
  height: 2px;
  /*background-color: #56baed;*/
  content: "";
  transition: width 0.2s;
}

.underlineHover:hover {
  color: #0d0d0d;
}

.underlineHover:hover:after{
  width: 100%;
}

h1{
    color:#0655ca;;
}

/* OTHERS */

*:focus {
    outline: none;
} 

#icon {
  width:70%;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
<div class="wrapper fadeInDown" style="    margin-top: 30px;">
  <div id="formContent">
    <!-- Tabs Titles -->

    <!-- Icon --><br style="clear:both"/>
    <div class="fadeIn first">  
      <img src="images/logoxmarket.png" id="icon" alt="User Icon"  style="   
    margin-top: 37px;"/>
     <br style="
  clear:both"/>  
         <%--<img src="images/logoxmarket.png" width="165"/>--%>
     
    </div><br style="clear:both"/>
    <!-- Login Form --><br style="clear:both;"/>  <br style="clear:both;"/>  <br style="clear:both;"/>  
         <div class="input-group" style="    margin-left: 8px;margin-right:8px;">
                        <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                        <input id="txtuser" type="text" runat="server" autocomplete="off" class="form-control" name="Usuario" value="" placeholder="Usuario">                                        
                    </div>
      <br style="clear:both"/>
        <div class="input-group" style="    margin-left: 8px;margin-right:8px;">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                        <input id="txtpassword" runat="server" type="password"  autocomplete="off" class="form-control" name="Contraseña" placeholder="Contraseña">
        </div>  
      
      <br style="clear:both"/>
        <div class="">
                        <!-- Button -->
                        <div class="col-sm-12">                            
                         <asp:Button   class="btn btn-primary  btnIngresar" Width="100%" runat="server" id="btnRegistro" Text ="Ingresar" OnClick="btnRegistro_Click1" ></asp:Button>
                          <br style="clear:both;"/>  <br style="clear:both;"/>   <br style="clear:both;"/> 
                 </div>
                    </div>

    <!-- Remind Passowrd -->
    <div id="formFooter">
      <a class="underlineHover" href="#"></a>
    </div>

  </div>
    </form>
</body>
</html>
