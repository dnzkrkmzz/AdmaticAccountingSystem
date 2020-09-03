<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YeniMusteri.aspx.cs" Inherits="AdmaticAccountingSystem.YeniMusteri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="js/jquery-ui/css/no-theme/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="css/font-icons/entypo/css/entypo.css" />
    <link rel="stylesheet" href="//fonts.googleapis.com/css?family=Noto+Sans:400,700,400italic" />
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/neon-core.css" />
    <link rel="stylesheet" href="css/custom.css" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/jquery.mask.js"></script>
    <script src="js/jquery.maskMoney.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtTelNo').mask('(000) 000 00 00');
        });

        function CloseColorbox(e) {
            var aid = e.getAttribute("id");

            if (aid == 'aContinue') {
                parent.jQuery.colorbox.close();
            }
            else if (aid == 'btnKaydet') {
                parent.jQuery.colorbox.close();
            }
            else if (aid == 'nContinue') {
                parent.jQuery.colorbox.close();
            }
            else if (aid == 'cContinue') {
                parent.jQuery.colorbox.close();
            }
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div runat="server" id="dvYeniDuzenle" class="panel-body" style="background-color: whitesmoke; margin: 2px;">
            <div style="text-align: center">
                <h4><b><asp:Label runat="server" ID="lblBaslik"></asp:Label></b></h4>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-1" class="control-label">Firma Ünvanı</label>
                    <asp:TextBox runat="server" ID="txtFirmaUnvani" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="field-2" class="control-label">Kısa Ad</label>
                    <asp:TextBox runat="server" ID="txtKisaAd" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-3" class="control-label">Adres</label>
                    <asp:TextBox runat="server" ID="txtAdres" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-4" class="control-label">Yetkili Kişi</label>
                    <asp:TextBox runat="server" ID="txtYetkiliKisi" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-5" class="control-label">Telefon No</label>
                    <asp:TextBox runat="server" ID="txtTelNo" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-6" class="control-label">E-Mail</label>
                    <asp:TextBox runat="server" ID="txtMail" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-7" class="control-label">Vergi No</label>
                    <asp:TextBox runat="server" ID="txtVergiNo" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-8" class="control-label">Vergi Dairesi</label>
                    <asp:TextBox runat="server" ID="txtVergiDairesi" CssClass="form-control"></asp:TextBox>
                </div>
            </div>


            <div class="form-group">
                <div class="col-md-5">
                    <a onclick="CloseColorbox(this)" id="aContinue" href="#" class="btn btn-default"><div>Kapat</div></a>
                    <asp:Button runat="server" ID="btnKaydet" Text="Kaydet" OnClientClick="return CloseColorbox(this)" CssClass="btn btn-info" OnClick="btnKaydet_Click" />
                </div>
            </div>

        </div>



        <script src="js/gsap/TweenMax.min.js"></script>
        <script src="js/jquery-ui/js/jquery-ui-1.10.3.minimal.min.js"></script>
        <script src="js/bootstrap.js"></script>
        <script src="js/resizeable.js"></script>
        <script src="js/neon-api.js"></script>

        <script src="js/bootstrap-datepicker.js"></script>

        <script src="js/bootstrap-timepicker.min.js"></script>
        <script src="js/bootstrap-colorpicker.min.js"></script>
        <script src="js/daterangepicker/daterangepicker.js"></script>
        <script src="js/jquery.multi-select.js"></script>
        <script src="js/icheck/icheck.min.js"></script>

        <script src="js/neon-custom.js"></script>
    </form>
</body>
</html>
