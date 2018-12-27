<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default6.aspx.cs" Inherits="Default6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333" OnItemDataBound="DataList1_ItemDataBound">
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="DeptNo"></asp:Label>
                    <asp:Label ID="lblDeptNo" runat="server" Text='<%# Bind("DeptNo") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="DeptName"></asp:Label>
                    <asp:Label ID="lblDeptName" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                    <br />
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            </asp:DataList>
        </div>
    </form>
</body>
</html>
