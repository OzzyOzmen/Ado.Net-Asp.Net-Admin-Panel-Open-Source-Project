<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdminPanel.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Admin Panel | Log in</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="Content/css/AdminLTE.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="plugins/iCheck/square/blue.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body class="hold-transition login-page">
    <div class="login-box">
        <div class="login-logo">
            <a href="/Login.aspx"><b>Admin</b>Panel</a>
        </div>
        <!-- /.login-logo -->
        <div class="login-box-body">
            <p class="login-box-msg"><%=AdminPanel.Resources.Index.Logintostartyoursession %></p>

            <form id="form1" runat="server" method="post">
                <div class="form-group has-feedback">
                    <input type="text" runat="server" id="txtUserName" class="form-control" placeholder="Username">
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <input type="password" runat="server" id="txtPassword" class="form-control" placeholder="Password">
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="row">
                    <div class="col-xs-8">
                        <div class="checkbox icheck">
                            <label>
                                <input type="checkbox">
                                <%=AdminPanel.Resources.Index.RememberMe %>
                            </label>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-xs-4">
                        <input type="submit" runat="server" class="btn btn-primary btn-block btn-flatt" id="BtnLogin" onserverclick="BtnLogin_ServerClick" name="name" value='Login' />
                    </div>

                    <!-- /.col -->
                </div>
            </form>



        </div>
        <!-- /.login-box-body -->
            <!-- /.login-box -->
        <!-- /.demo information -->
          <div class="login-box">
        <div class="login-logo">
          
        </div>
        <!-- /.login-logo -->
        <div class="login-box-body">
                 <div class="form-group has-feedback">
                        <p>
                            <asp:Label ID="lblgirisbilgileri" runat="server" Text="Demo Giriş Bilgileri " ForeColor="gray" Font-Size="Medium" Font-Bold="true"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="lblkullaniciadi" runat="server" Text="Kullanici Adı : " ForeColor="gray" Font-Size="Small" Font-Bold="true"></asp:Label>


                            <asp:Label ID="lblkadi" runat="server" Text="" ForeColor="Red" Font-Size="Small" Font-Bold="true"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="lblkullanicisifresi" runat="server" Text="Kullanici Şifresi :" ForeColor="gray" Font-Size="Small" Font-Bold="true"></asp:Label>


                            <asp:Label ID="lblksifre" runat="server" Text="" ForeColor="Red" Font-Size="Small" Font-Bold="true"></asp:Label>
                        </p>
                    </div>
                    <!-- /.col -->
               



        </div>
        <!-- /.demo information -->
    </div>


    <!-- jQuery 3 -->
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
</script>
</body>
</html>
