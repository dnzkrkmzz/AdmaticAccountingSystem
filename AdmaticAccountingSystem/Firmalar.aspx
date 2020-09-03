<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Firmalar.aspx.cs" Inherits="AdmaticAccountingSystem.Firmalar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        th{
            font-weight: bold;
            font-size:small;
        }
        td{
            color:darkslategray;
        }
    </style>
    <script type="text/javascript">

        function confirmDel() {
            var onay = confirm("Bu firmayı silmek istediğinizden emin misiniz?");
            if (onay) {
                return true;
            }
            else {
                return false;
            }
        }

        jQuery(document).ready(function ($) {
            var $table1 = jQuery('#table-1');

            // Initialize DataTable
            $table1.DataTable({
                "aLengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                "bStateSave": true
            });

            // Initalize Select Dropdown after DataTables is created
            $table1.closest('.dataTables_wrapper').find('select').select2({
                minimumResultsForSearch: -1
            });

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
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6 col-sm-8 clearfix">
            <ul class="user-info pull-left pull-none-xsm">
                <li class="profile-info dropdown">
                    <h1>Firmalar</h1>
                </li>
            </ul>
        </div>
        <div class="col-md-6 col-sm-4 clearfix hidden-xs">
            <ul class="list-inline links-list pull-right">
                <li>
                    <asp:Button runat="server" ID="btnDisariAktar" CssClass="btn btn-default" Text="Dışarı Aktar" OnClick="btnDisariAktar_Click" /> &nbsp;
                    <a class="ajax" id="colorboxa" href="YeniMusteri.aspx"><div class="btn btn-default">Yeni Firma</div></a>
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
                    <th>Kısa Ad</th>                   
                    <th>Yetkili Kişi</th>
                    <th>Telefon</th>
                    <th>Mail Adresi</th>
                    <th>Vadesi Gelen Tahsilat</th>
                    <th>Toplam Tahsilat</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rptFirma" OnItemCommand="rptFirma_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%#DataBinder.Eval(Container.DataItem,"FirmaUnvan") == null ? "" : DataBinder.Eval(Container.DataItem,"FirmaUnvan") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"KisaAd") == null ? "" : DataBinder.Eval(Container.DataItem,"KisaAd") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"YetkiliKisi") == null ? "" : DataBinder.Eval(Container.DataItem,"YetkiliKisi") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"TelNo") == null ? "" : DataBinder.Eval(Container.DataItem,"TelNo") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"Mail") == null ? "" : DataBinder.Eval(Container.DataItem,"Mail") %></td>
                            <td style="color:red"><%#String.Format("{0:0.00}",(DataBinder.Eval(Container.DataItem,"VadesiGelen") == null ? "" : DataBinder.Eval(Container.DataItem,"VadesiGelen"))) %></td>
                            <td><%#String.Format("{0:0.00}",(DataBinder.Eval(Container.DataItem,"ToplamTahsilat") == null ? "" : DataBinder.Eval(Container.DataItem,"ToplamTahsilat"))) %></td>
                            <td>
                                <a href="FirmaDetay.aspx?Firma=<%#DataBinder.Eval(Container.DataItem,"ID") %>"><div class="btn btn-link">Detay</div></a>
                                &nbsp;
                                <a class="ajax" id="colorboxa" href="YeniMusteri.aspx?ID=<%#DataBinder.Eval(Container.DataItem,"ID") %>"><div class="btn btn-default">Duzenle</div></a>
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
