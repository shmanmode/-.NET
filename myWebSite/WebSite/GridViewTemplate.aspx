<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewTemplate.aspx.cs" Inherits="GridViewTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ShowFooter="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                        &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                <asp:TemplateField FooterText="LoginName" HeaderText="LoginName" ShowHeader="False" SortExpression="LoginName">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLoginName" runat="server" Text='<%# Bind("LoginName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLoginName" runat="server" Text='<%# Bind("LoginName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField FooterText="EmailId" HeaderText="EmailId" ShowHeader="False" SortExpression="EmailId">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmailId" runat="server" Text='<%# Bind("EmailId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmailId" runat="server" Text='<%# Bind("EmailId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField FooterText="Address" HeaderText="Address" ShowHeader="False" SortExpression="Address">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField FooterText="CityId" HeaderText="CityId" ShowHeader="False" SortExpression="CityId">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CityId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList runat="server" DataSourceID="CityId" DataTextField="CityId" DataValueField="CityId">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="CityId" runat="server" ConnectionString="<%$ ConnectionStrings:pooja11ConnectionString %>" SelectCommand="SELECT [CityId] FROM [Customers]"></asp:SqlDataSource>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCityId" runat="server" Text='<%# Bind("CityId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField FooterText="PaymentMode" HeaderText="PaymentMode" ShowHeader="False" SortExpression="PaymentMode">
                    <FooterTemplate>
                        <asp:DropDownList ID="DropPaymentmode" runat="server" DataSourceID="Payment" DataTextField="PaymentMode" DataValueField="PaymentMode">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="Payment" runat="server" ConnectionString="<%$ ConnectionStrings:pooja11ConnectionString %>" SelectCommand="SELECT [PaymentMode] FROM [Customers]"></asp:SqlDataSource>
                        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPaymentMode" runat="server" Text='<%# Bind("PaymentMode") %>'></asp:Label>
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
    </form>
</body>
</html>
