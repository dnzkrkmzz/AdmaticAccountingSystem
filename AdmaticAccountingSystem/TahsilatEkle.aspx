<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TahsilatEkle.aspx.cs" Inherits="AdmaticAccountingSystem.TahsilatEkle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="js/jquery-ui/css/no-theme/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="css/font-icons/entypo/css/entypo.css" />
    <link rel="stylesheet" href="//fonts.googleapis.com/css?family=Noto+Sans:400,700,400italic" />
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/neon-core.css" />
    <link rel="stylesheet" href="css/neon-theme.css" />
    <link rel="stylesheet" href="css/neon-forms.css" />
    <link rel="stylesheet" href="css/custom.css" />
    <script src="js/jquery-1.11.3.min.js"></script>

    <script src="js/jquery.mask.js"></script>
    <script src="js/jquery.maskMoney.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtSiraNo').mask('0000000000');
            $('#txtVade').mask('000');
            $('#txtTutar').maskMoney();
            $('#txtNMeblag').maskMoney();
            $('#txtCMeblag').maskMoney();
            $('#dpFDT').mask('00.00.0000');
            $('#dpNFDT').mask('00.00.0000');
            $('#dpCTarih').mask('00.00.0000');
            $('#dpCVadeTarihi').mask('00.00.0000');

            if ($("#dpFDT").length) {
                $('#dpFDT').datepicker({
                    timepicker: false,
                    format: 'dd.mm.yyyy'
                });
            }

            if ($("#dpNFDT").length) {
                $('#dpNFDT').datepicker({
                    timepicker: false,
                    format: 'dd.mm.yyyy'
                });
            }

            if ($("#dpCTarih").length) {
                $('#dpCTarih').datepicker({
                    timepicker: false,
                    format: 'dd.mm.yyyy'
                });
            }

            if ($("#dpCVadeTarihi").length) {
                $('#dpCVadeTarihi').datepicker({
                    timepicker: false,
                    format: 'dd.mm.yyyy'
                });
            }
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
            else if (aid == 'btnNakitKaydet') {
                parent.jQuery.colorbox.close();
            }
            else if (aid == 'btnCekKaydet') {
                parent.jQuery.colorbox.close();
            }
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row" runat="server" id="dvTahsilat" visible="false" style=" background-color:whitesmoke; margin: 2px;">
            <div style="text-align: center">
                <h4><b>
                    <asp:Label runat="server" ID="lblTahsilat"><i class="entypo-down-open-big"></i>Tahsilat Ekle</asp:Label></b></h4>
            </div>

            <div class="col-md-6">
                <ul class="nav nav-tabs bordered">
                    <!-- available classes "bordered", "right-aligned" -->
                    <li class="active">
                        <a href="#nakit" data-toggle="tab">
                            <span class="visible-xs"><b>Nakit Tahsilat</b></span>
                            <span class="hidden-xs"><b>Nakit Tahsilat</b></span>
                        </a>
                    </li>
                    <li>
                        <a href="#cek" data-toggle="tab">
                            <span class="visible-xs"><b>Çek Tahsilat</b></span>
                            <span class="hidden-xs"><b>Çek Tahsilat</b></span>
                        </a>
                    </li>
                </ul>

                <div class="tab-content">
                    <div class="tab-pane active" runat="server" id="nakit">
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-5">
                                    <div class="input-group">
                                        <label for="field-7" class="control-label">Tarih</label>
                                        <asp:TextBox runat="server" ID="dpNFDT" CssClass="form-control datepicker"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-5">
                                    <label for="field-6" class="control-label">Hesap</label><br />
                                    <asp:DropDownList runat="server" ID="drpNHesap" CssClass="dropdown-toggle">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-5">
                                    <label for="field-4" class="control-label">Meblağ</label>
                                    <asp:TextBox runat="server" ID="txtNMeblag" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-5">
                                    <label for="field-5" class="control-label">Açıklama</label>
                                    <asp:TextBox runat="server" ID="txtNAciklama" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-5">
                                    <a onclick="CloseColorbox(this)" id="nContinue" href="#" class="btn btn-default">
                                        <div>Vazgeç</div>
                                    </a>
                                    <asp:Button runat="server" ID="btnNakitKaydet" Text="Tahsilat Yap" OnClick="btnNakitKaydet_Click" OnClientClick="return CloseColorbox(this)" CssClass="btn btn-info blockquote-blue" />
                                </div>
                            </div>
                        </div>                       
                    </div>
                    <div class="tab-pane" id="cek">
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-5">
                                    <div class="input-group">
                                        <label for="field-7" class="control-label">Tarih</label>
                                        <asp:TextBox runat="server" ID="dpCTarih" CssClass="form-control datepicker"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-5">
                                    <div class="input-group">
                                        <label for="field-7" class="control-label">Vade Tarihi</label>
                                        <asp:TextBox runat="server" ID="dpCVadeTarihi" CssClass="form-control datepicker"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-5">
                                    <label for="field-6" class="control-label">Hesap</label><br />
                                    <asp:DropDownList runat="server" ID="drpCHesap" CssClass="dropdown-toggle">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-5">
                                    <label for="field-4" class="control-label">Meblağ</label>
                                    <asp:TextBox runat="server" ID="txtCMeblag" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-5">
                                    <label for="field-5" class="control-label">Açıklama</label>
                                    <asp:TextBox runat="server" ID="txtCAciklama" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-5">
                                    <a onclick="CloseColorbox(this)" id="cContinue" href="#" class="btn btn-default">
                                        <div>Vazgeç</div>
                                    </a>
                                    <asp:Button runat="server" ID="btnCekKaydet" Text="Tahsilat Yap" OnClick="btnCekKaydet_Click" OnClientClick="return CloseColorbox(this)" CssClass="btn btn-blue" />
                                </div>
                            </div>
                        </div>  
                    </div>
                    <div class="row" style="background-color: lightgray;">
                            <div class="form-group">
                                <div class="col-md-5">
                                    <asp:Label  runat="server" CssClass="control-label" style="color:black;font-weight:bold;font-size:larger;">Gecikmiş Tahsilat</asp:Label>
                                    <asp:Label runat="server" ID="lblGecikmisTahsilat" style="color:red;font-weight:bold;font-size:larger;float:right"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-5">
                                    <asp:Label runat="server" CssClass="control-label">Yapılacak Tahsilat</asp:Label>
                                    <asp:Label runat="server" ID="lblYapilacakTahsilat" style="float:right"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-5">
                                    <asp:Label  runat="server" CssClass="control-label" style="color:black;font-weight:bold;font-size:larger;">Toplam Tahsilat</asp:Label>
                                    <asp:Label runat="server" ID="lblToplamTahsilat" style="color:dodgerblue;font-weight:bold;font-size:larger;float:right"></asp:Label>
                                </div>
                            </div>
                        </div>
                </div>
            </div>


        </div>
        <div runat="server" id="dvYeniDuzenle" visible="false" class="panel-body" style="background-color: whitesmoke; margin: 2px;">
            <div style="text-align: center">
                <h4><b>
                    <asp:Label runat="server" ID="lblBaslik"></asp:Label></b></h4>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-4" class="control-label">Seri No</label>
                    <asp:TextBox runat="server" ID="txtSeriNo" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-5" class="control-label">Sıra No</label>
                    <asp:TextBox runat="server" ID="txtSiraNo" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-6" class="control-label">Tutar(KDV Hariç)</label>
                    <asp:TextBox runat="server" ID="txtTutar" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-6" class="control-label">Vade</label>
                    <asp:TextBox runat="server" ID="txtVade" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-6" class="control-label">İşlem Türü</label><br />
                    <asp:DropDownList runat="server" ID="drpIslemTuru" CssClass="dropdown-toggle">
                        <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                        <asp:ListItem Value="1">Satış Faturası</asp:ListItem>
                        <asp:ListItem Value="2">Tahsilat</asp:ListItem>
                        <asp:ListItem Value="3">Fiş/Fatura</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-4" class="control-label">Açıklama</label>
                    <asp:TextBox runat="server" ID="txtAciklama" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-5" class="control-label">Reklam Hizmet Bilgisi</label>
                    <asp:TextBox runat="server" ID="txtRHB" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label for="field-6" class="control-label">Etiket</label>
                    <asp:TextBox runat="server" ID="txtEtiket" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <div class="input-group">
                        <label for="field-7" class="control-label">Fatura Düzenlenme Tarihi</label>
                        <asp:TextBox runat="server" ID="dpFDT" CssClass="form-control datepicker"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <a onclick="CloseColorbox(this)" id="aContinue" href="#" class="btn btn-default">
                        <div>Kapat</div>
                    </a>
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
