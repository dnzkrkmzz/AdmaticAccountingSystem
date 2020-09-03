<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AdmaticAccountingSystem.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="author" content="" />

    <link rel="icon" href="images/favicon.ico" />

    <title>AdMatic | Login</title>

    <link rel="stylesheet" href="js/jquery-ui/css/no-theme/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="css/font-icons/entypo/css/entypo.css" />
    <link rel="stylesheet" href="//fonts.googleapis.com/css?family=Noto+Sans:400,700,400italic" />
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/neon-core.css" />
    <link rel="stylesheet" href="css/neon-theme.css" />
    <link rel="stylesheet" href="css/neon-forms.css" />
    <link rel="stylesheet" href="css/custom.css" />

    <script src="js/jquery-1.11.3.min.js"></script>

    <style type="text/css">
        .warning {
            color: #9F6000;
            width: 100%;
            padding: 10px;
            background-color: #FEEFB3;
            -moz-user-select: none;
            background-image: none;
            border: 1px solid transparent;
            border-radius: 4px;
            cursor: pointer;
            display: inline-block;
            font-size: 14px;
            font-weight: normal;
            line-height: 1.42857;
            margin-bottom: 0;
        }
    </style>

</head>
<body class="page-body login-page login-form-fall">
    <form id="form1" runat="server">
        <script type="text/javascript">
            var baseurl = '';
</script>

        <div class="login-container">
            <div class="login-header login-caret">
                <div class="login-content">
                    <a href="www.admatic.com.tr" target="_blank" class="logo">
                        <img src="images/logo.png" width="120" alt="" />
                    </a>
                </div>
            </div>
            <div class="login-progressbar">
                <div></div>
            </div>
            <div class="login-form">
                <div class="login-content">
                    <div class="warning" runat="server" id="dvWarningMessage" visible="false">
                    </div>
                    <br />
                    <div class="form-group">
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="entypo-user"></i>
                            </div>
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="E-Mail"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="entypo-key"></i>
                            </div>
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" placeholder="Şifre"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" CssClass="btn btn-primary btn-block btn-login" ID="btnLogin" Text="Oturum Açın" OnClick="btnLogin_Click" />
                    </div>

                    <div class="login-bottom-links">
                        <a href="extra-forgot-password.html" class="link">Forgot your password?</a>
                    </div>
                </div>
            </div>
        </div>

        <script src="js/gsap/TweenMax.min.js"></script>
        <script src="js/jquery-ui/js/jquery-ui-1.10.3.minimal.min.js"></script>
        <script src="js/bootstrap.js"></script>
        <script src="js/joinable.js"></script>
        <script src="js/resizeable.js"></script>
        <script src="js/neon-api.js"></script>
        <script src="js/jquery.validate.min.js"></script>
        <script src="js/neon-login.js"></script>
        <script src="js/neon-custom.js"></script>
        <script src="js/neon-demo.js"></script>
    </form>
</body>
</html>
