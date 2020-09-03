<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Faturalar.aspx.cs" Inherits="AdmaticAccountingSystem.Faturalar1" %>
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
                    <h1>Faturalar</h1>
                </li>
            </ul>
        </div>
        <div class="col-md-6 col-sm-4 clearfix hidden-xs">
            <ul class="list-inline links-list pull-right">
                <li>
                    <asp:Button runat="server" ID="btnDisariAktar" CssClass="btn btn-default" Text="Dışarı Aktar" OnClick="btnDisariAktar_Click" /> &nbsp;
                    <a class="ajax" id="colorboxa" href="YeniMusteri.aspx"><div class="btn btn-default">Yeni Fatura Oluştur</div></a>
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
                    <th>Fatura Açıklaması</th>
                    <th>Düzenlenme Tarihi</th>                   
                    <th>Vade Tarihi</th>
                    <th>Kalan Meblağ</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rptFatura" OnItemCommand="rptFatura_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><span style="font-size:small"><%#DataBinder.Eval(Container.DataItem,"Aciklama") == null ? "" : DataBinder.Eval(Container.DataItem,"Aciklama") %></span>
                                <br />
                                <span style="font-size:smaller"><%#DataBinder.Eval(Container.DataItem,"KisaAd") %></span>
                            </td>
                            <td><span style="font-size:small"><%#String.Format("{0:dd.MM.yyyy}",DataBinder.Eval(Container.DataItem,"FaturaDuzenlenmeTarihi")) %></span>
                                <br />
                                <span style="font-size:smaller">Fatura <%#DataBinder.Eval(Container.DataItem,"SeriSiraNo") %></span>
                            </td>
                            <td>bilinmiyor</td>
                            <td>Toplam <%#String.Format("{0:0.00}",(DataBinder.Eval(Container.DataItem,"Toplam") == null ? "" : DataBinder.Eval(Container.DataItem,"Toplam"))) %></td>
                            <td>
                                <a class="ajax" id="colorboxa" href="TahsilatEkle.aspx?ID=<%#DataBinder.Eval(Container.DataItem,"ID") %>"><div class="btn btn-default">Duzenle</div></a>
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
