<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default7.aspx.cs" Inherits="Default7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333" OnCancelCommand="DataList1_CancelCommand" OnDeleteCommand="DataList1_DeleteCommand" OnEditCommand="DataList1_EditCommand" OnUpdateCommand="DataList1_UpdateCommand">
                <AlternatingItemStyle BackColor="White" />
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="DeptNo"></asp:Label>
                    <asp:TextBox ID="txtDeptNo" runat="server" Text='<%# Bind("DeptNo") %>'></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="DeptName"></asp:Label>
                    <asp:TextBox ID="txtDeptName" runat="server" Text='<%# Bind("DeptName") %>'></asp:TextBox>
                    <br />
                    <asp:Button ID="Button3" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="Button4" runat="server" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
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
                    <asp:Button ID="Button1" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="Button2" runat="server" CommandName="Delete" Text="Delete" />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            </asp:DataList>
        </div>
    </form>
</body>
</html>
