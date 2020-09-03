<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="FirmaDetay.aspx.cs" Inherits="AdmaticAccountingSystem.FirmaDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        th {
            font-weight: bold;
            font-size: small;
        }

        tr {
            color: darkslategray;
        }
    </style>
    <script type="text/javascript">

        function confirmDel() {
            var onay = confirm("Bu faturayı silmek istediğinizden emin misiniz?\nBu işlem geri alınamaz!");
            if (onay) {
                return true;
            }
            else {
                return false;
            }
        }

        $(document).ready(function () {
            $(".ajax").colorbox(
            {
                iframe: true,
                width: "400px",
                height: "800px",
                scrolling: false,
                onClosed: function () {
                    location.reload(true);
                }
            });

            $('#ContentPlaceHolder1_txtSiraNo').mask('0000000000');
            $('#ContentPlaceHolder1_txtVade').mask('000');
            $('#ContentPlaceHolder1_txtTutar').maskMoney();

            $('#ContentPlaceHolder1_txtDSiraNo').mask('0000000000');
            $('#ContentPlaceHolder1_txtDVade').mask('000');
            $('#ContentPlaceHolder1_txtDTutar').maskMoney();

            $('#ContentPlaceHolder1_dpFDT').mask('00.00.0000');

            if ($("#ContentPlaceHolder1_dpFDT").length) {
                $('#ContentPlaceHolder1_dpFDT').datepicker({
                    timepicker: false,
                    format: 'd.m.Y'
                });
            }
        });

        jQuery(document).ready(function ($) {
            var $table1 = jQuery('#table-1');

            var $table2 = jQuery('#table-2');


            $table1.DataTable({
                "aLengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                "bStateSave": true
            });


            $table1.closest('.dataTables_wrapper').find('select').select2({
                minimumResultsForSearch: -1
            });

            $table2.DataTable({
                "aLengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                "bStateSave": true
            });


            $table2.closest('.dataTables_wrapper').find('select').select2({
                minimumResultsForSearch: -1
            });

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" EnablePageMethods="true"></asp:ScriptManager>



    <div class="row">
        <div class="col-md-6 col-sm-8 clearfix">
            <ul class="user-info pull-left pull-none-xsm">
                <li class="profile-info dropdown">
                    <h1>Firma Detay -
                        <asp:Label runat="server" ID="lblKisaAd"></asp:Label>
                    </h1>
                </li>
            </ul>
        </div>
        <div class="col-md-6 col-sm-4 clearfix hidden-xs">
            <ul class="list-inline links-list pull-right">
                <li>
                    <asp:Button runat="server" ID="btnDisariAktarVadesiGelen" CssClass="btn btn-default" Text="Dışarı Aktar" OnClick="btnDisariAktarVadesiGelen_Click" />
                </li>
            </ul>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-md-12">
            <table class="table table-bordered datatable" id="table-1">
                <thead>
                    <tr>
                        <th>Firma Ünvan</th>
                        <th>Vade Tarihi</th>
                        <th>Vadesi Gelen Tutar</th>
                        <th>Toplam Tahsilat(KDV Dahil)</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rptFirmaDetay">
                        <ItemTemplate>
                            <tr>
                                <td><%#DataBinder.Eval(Container.DataItem,"KisaAd") %></td>
                                <td>
                                    <asp:Label runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"kalanGun")) < 0 ? "red" : "darkslategray") %>' Text='<%#Convert.ToInt32(DataBinder.Eval(Container.DataItem,"kalanGun")) < 0 ? (Convert.ToInt32(DataBinder.Eval(Container.DataItem,"kalanGun"))*-1).ToString() + " gün geçti" : DataBinder.Eval(Container.DataItem,"kalanGun").ToString() + " gün kaldı" %>'></asp:Label></td>
                                <td><%#String.Format("{0:0.00}",DataBinder.Eval(Container.DataItem,"VadesiGelen")) %></td>
                                <td><%#String.Format("{0:0.00}",DataBinder.Eval(Container.DataItem,"ToplamTutar")) %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-6 col-sm-8 clearfix">
            <ul class="user-info pull-left pull-none-xsm">
                <li class="profile-info dropdown">
                    <h3>Firmaya Kesilen Faturalar</h3>
                </li>
            </ul>
        </div>
        <div class="col-md-6 col-sm-4 clearfix hidden-xs">
            <ul class="list-inline links-list pull-right">
                <li>
                    <asp:Button runat="server" ID="btnDisariAktarFirmaDetay" CssClass="btn btn-default" Text="Dışarı Aktar" OnClick="btnDisariAktarFirmaDetay_Click" />
                    &nbsp;&nbsp;
                    <asp:Label runat="server" ID="lblYeniFatura"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label runat="server" ID="lblTahsilat"></asp:Label>
                    <%--<a class='ajax' id="colorboxa" href="TahsilatEkle.aspx"><div class="btn btn-blue">Tahsilat Yap</div></a>--%>
                </li>
            </ul>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <table class="table table-bordered datatable" id="table-2">
                <thead>
                    <tr>
                        <th>Firma Ünvan</th>
                        <th>Fatura Seri-Sıra No</th>
                        <th>İşlem Türü</th>
                        <th>Açıklama</th>
                        <th>Fatura Tutar(KDV Hariç)</th>
                        <th>KDV</th>
                        <th>Fatura Tutar(KDV Dahil)</th>
                        <th>Fatura Vadesi</th>
                        <%--<th>Reklam Hizmet Bilgisi</th>
                        <th>Etiket</th>--%>
                        <th>Fatura Düzenlenme Tarihi</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rptFaturalar" OnItemCommand="rptFaturalar_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%#DataBinder.Eval(Container.DataItem,"KisaAd") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem,"FaturaSeriNo") %>-<%#DataBinder.Eval(Container.DataItem,"FaturaSiraNo") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem,"IslemAdi") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem,"Aciklama") %></td>
                                <td><%#String.Format("{0:0.00}",DataBinder.Eval(Container.DataItem,"FaturaTutar")) %></td>
                                <td><%#String.Format("{0:0.00}",DataBinder.Eval(Container.DataItem,"KDV")) %></td>
                                <td><%#String.Format("{0:0.00}",DataBinder.Eval(Container.DataItem,"TOPLAMTUTAR")) %></td>
                                <td><%#DataBinder.Eval(Container.DataItem,"FaturaVade") %></td>
                                <%--<td><%#DataBinder.Eval(Container.DataItem,"ReklamHizmetBilgisi") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem,"Etiket") %></td>--%>
                                <td><%#String.Format("{0:dd.MM.yyyy}",DataBinder.Eval(Container.DataItem,"FaturaDuzenlenmeTarihi")) %></td>
                                <td>
                                    <%--<a href="javascript:;" onclick="jQuery('#Duzenle-<%#DataBinder.Eval(Container.DataItem,"ID") %>').modal('show', {backdrop: 'static'});" class="btn btn-default">Duzenle</a>--%>
                                    <a class='ajax' id="colorboxa" href="TahsilatEkle.aspx?ID=<%#DataBinder.Eval(Container.DataItem,"ID") %>">
                                        <div class="btn btn-default">Düzenle</div>
                                    </a>
                                    &nbsp;
                                    <asp:Button runat="server" ID="btnSil" Text="Sil" CssClass="btn btn-red" OnClientClick="return confirmDel();" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID") %>' CommandName="Sil" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
