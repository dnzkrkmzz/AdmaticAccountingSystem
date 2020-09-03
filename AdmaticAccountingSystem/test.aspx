<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="AdmaticAccountingSystem.test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        th {
            font-weight: bold;
            font-size: small;
        }

        td {
            color: black;
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
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Firmalar</h2>

        <br />

        <table class="table table-bordered datatable" id="table-1">
            <thead>
                <tr>
                    <th>Firma Ünvan</th>
                    <th>Kısa Ad</th>
                    <th>Vergi No</th>
                    <th>Vergi Dairesi</th>
                    <th>Adres</th>
                    <th>Yetkili Kişi</th>
                    <th>Telefon</th>
                    <th>Mail Adresi</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rptFirma" OnItemCommand="rptFirma_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%#DataBinder.Eval(Container.DataItem,"FirmaUnvan") == null ? "" : DataBinder.Eval(Container.DataItem,"FirmaUnvan") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"KisaAd") == null ? "" : DataBinder.Eval(Container.DataItem,"KisaAd") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"VergiNo") == null ? "" : DataBinder.Eval(Container.DataItem,"VergiNo") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"VergiDairesi") == null ? "" : DataBinder.Eval(Container.DataItem,"VergiDairesi") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"Adres") == null ? "" : DataBinder.Eval(Container.DataItem,"Adres") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"YetkiliKisi") == null ? "" : DataBinder.Eval(Container.DataItem,"YetkiliKisi") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"TelNo") == null ? "" : DataBinder.Eval(Container.DataItem,"TelNo") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"Mail") == null ? "" : DataBinder.Eval(Container.DataItem,"Mail") %></td>
                            <td>
                                <a href="javascript:;" onclick="jQuery('#Duzenle-<%#DataBinder.Eval(Container.DataItem,"ID") %>').modal('show', {backdrop: 'static'});" class="btn btn-default">Duzenle</a>
                                &nbsp;
                                    <asp:Button runat="server" ID="btnSil" Text="Sil" CssClass="btn btn-red" OnClientClick="return confirmDel();" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID") %>' CommandName="Sil" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>


</asp:Content>
