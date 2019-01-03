<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridView.aspx.cs" Inherits="GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ShowFooter="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                            <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                            <asp:TemplateField FooterText="UserName" HeaderText="UserName" SortExpression="UserName">
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFootUsername" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField FooterText="Password" HeaderText="Password" SortExpression="Password">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFootPassword" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField FooterText="Address" HeaderText="Address" SortExpression="Address">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFootAddress" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField FooterText="MobNo" HeaderText="MobNo" SortExpression="MobNo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMob" runat="server" Text='<%# Bind("MobNo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFootMob" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("MobNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField FooterText="CityId" HeaderText="CityId" SortExpression="CityId">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropCity" runat="server" DataSourceID="SqlDatacity" DataTextField="CityName" DataValueField="CityId">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDatacity" runat="server" ConnectionString="<%$ ConnectionStrings:manmodeConnectionString2 %>" SelectCommand="SELECT * FROM [City]"></asp:SqlDataSource>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="DropFootCity" runat="server" DataSourceID="City" DataTextField="CityName" DataValueField="CityId">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="City" runat="server" ConnectionString="<%$ ConnectionStrings:manmodeConnectionString %>" SelectCommand="SELECT * FROM [City]"></asp:SqlDataSource>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("CityId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField FooterText="PaymentId" HeaderText="PaymentId" SortExpression="PaymentId">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="btnpayment" runat="server" DataSourceID="SqlDataPayment" DataTextField="CityName" DataValueField="CityId">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataPayment" runat="server" ConnectionString="<%$ ConnectionStrings:manmodeConnectionString2 %>" SelectCommand="SELECT * FROM [City]"></asp:SqlDataSource>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="btnFootpayment" runat="server" DataSourceID="Payment" DataTextField="PaymentName" DataValueField="PaymentId">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="Payment" runat="server" ConnectionString="<%$ ConnectionStrings:manmodeConnectionString2 %>" SelectCommand="SELECT * FROM [Payment]"></asp:SqlDataSource>
                                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("PaymentId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnUpdateAll" runat="server" OnClick="btnUpdateAll_Click" Text="UpdateAll" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
