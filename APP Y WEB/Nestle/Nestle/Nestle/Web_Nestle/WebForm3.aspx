<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Web_Nestle.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="jsFecha/jquery2_2_4.js">    </script>
<script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <style>
        /*pie chart nelson*/
        .pieChart {
            position: relative;
            font-size: 80px;
            width: 1em;
            height: 1em;
            display: block;
        }

        .percent {
            position: absolute;
            top: 1.05em;
            left: 0;
            width: 3.33em;
            font-size: 0.3em;
            text-align: center;
        }

        .slice {
            position: absolute;
            width: 1em;
            height: 1em;
            clip: rect(0px,1em,1em,0.5em);
        }

            .slice.gt50 {
                clip: rect(auto, auto, auto, auto);
            }

            .slice > .pie {
                border: 0.1em solid #66EE66;
                position: absolute;
                width: 0.8em; /* 1 - (2 * border width) */
                height: 0.8em; /* 1 - (2 * border width) */
                clip: rect(0em,0.5em,1em,0em);
                -moz-border-radius: 0.5em;
                -webkit-border-radius: 0.5em;
                border-radius: 0.5em;
            }

        .pieBack {
            border: 0.1em solid #EEEEEE;
            position: absolute;
            width: 0.8em;
            height: 0.8em;
            -moz-border-radius: 0.5em;
            -webkit-border-radius: 0.5em;
            border-radius: 0.5em;
        }

        .slice > .pie.fill {
            -moz-transform: rotate(180deg) !important;
            -webkit-transform: rotate(180deg) !important;
            -o-transform: rotate(180deg) !important;
            transform: rotate(180deg) !important;
        }
        /*end*/
    </style>
</head>
<body>
    <script>
        jQuery(document).ready(function ($) {
            $('#GridView1 .pieChart').each(function (index, value) {
                var percent = $(this).text();
                var deg = 360 / 100 * percent;
                $(this).html('<div class="percent">' + Math.round(percent) + '%' + '</div><div class="pieBack"></div><div ' + (percent > 50 ? ' class="slice gt50"' : 'class="slice"') + '><div class="pie"></div>' + (percent > 50 ? '<div class="pie fill"></div>' : '') + '</div>');
                $(this).find('.slice .pie').css({
                    '-moz-transform': 'rotate(' + deg + 'deg)',
                    '-webkit-transform': 'rotate(' + deg + 'deg)',
                    '-o-transform': 'rotate(' + deg + 'deg)',
                    'transform': 'rotate(' + deg + 'deg)'
                });
            });
        });
    </script>
    <form id="form1" runat="server">

        <asp:Button ID="Button1" runat="server" Text="EXPORT" OnClick="Button1_Click" />
        <asp:Panel runat="server" ID="Panel1">
            <center>  <table>
            <tr>
                <td>
                    <asp:Image ID="Image1" ImageUrl="http://3.19.108.54/nestle/iconos/logo_azulexport.png"
                        runat="server" />
              
                </td>
            </tr>
        </table>
            </center>
            <br />
            <br />
            <br />
            <br />

            <asp:GridView ID="GridView2" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
                runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Item" HeaderText="Item" ItemStyle-Width="100px">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Width="100px">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </asp:Panel>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>

                <asp:BoundField DataField="CodigoTxt" HeaderText="CodigoTxt" />
                <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" />
                <asp:BoundField DataField="Por_Visitar" HeaderText="Por Visitar" />
                <asp:BoundField DataField="Visitados" HeaderText="Visitados" />
                <asp:BoundField DataField="Cantidad_Pedidos" HeaderText="Cantidad Pedidos" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
                <asp:BoundField HeaderText="Cantidad_Pedidos" ItemStyle-CssClass="pieChart" HeaderStyle-Width="100px">

                    <HeaderStyle Width="100px"></HeaderStyle>

                    <ItemStyle CssClass="pieChart"></ItemStyle>
                </asp:BoundField>

            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </form>
</body>
</html>
