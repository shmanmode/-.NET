<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default9.aspx.cs" Inherits="Default9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:FormView ID="FormView1" runat="server" AllowPaging="True" CellPadding="4" DataKeyNames="EmpNo" DataSourceID="SqlDataSource1" ForeColor="#333333">
                <EditItemTemplate>
                    EmpNo:
                    <asp:Label ID="EmpNoLabel1" runat="server" Text='<%# Eval("EmpNo") %>' />
                    <br />
                    Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Basic:
                    <asp:TextBox ID="BasicTextBox" runat="server" Text='<%# Bind("Basic") %>' />
                    <br />
                    DeptNo:
                    <asp:TextBox ID="DeptNoTextBox" runat="server" Text='<%# Bind("DeptNo") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <InsertItemTemplate>
                    EmpNo:
                    <asp:TextBox ID="EmpNoTextBox" runat="server" Text='<%# Bind("EmpNo") %>' />
                    <br />
                    Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Basic:
                    <asp:TextBox ID="BasicTextBox" runat="server" Text='<%# Bind("Basic") %>' />
                    <br />
                    DeptNo:
                    <asp:TextBox ID="DeptNoTextBox" runat="server" Text='<%# Bind("DeptNo") %>' />
                    <br />
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </InsertItemTemplate>
                <ItemTemplate>
                    EmpNo:
                    <asp:Label ID="EmpNoLabel" runat="server" Text='<%# Eval("EmpNo") %>' />
                    <br />
                    Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Basic:
                    <asp:Label ID="BasicLabel" runat="server" Text='<%# Bind("Basic") %>' />
                    <br />
                    DeptNo:
                    <asp:Label ID="DeptNoLabel" runat="server" Text='<%# Bind("DeptNo") %>' />
                    <br />
                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                    &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                </ItemTemplate>
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            </asp:FormView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VikramConnectionString %>" DeleteCommand="DELETE FROM [Employees] WHERE [EmpNo] = @EmpNo" InsertCommand="INSERT INTO [Employees] ([EmpNo], [Name], [Basic], [DeptNo]) VALUES (@EmpNo, @Name, @Basic, @DeptNo)" SelectCommand="SELECT * FROM [Employees]" UpdateCommand="UPDATE [Employees] SET [Name] = @Name, [Basic] = @Basic, [DeptNo] = @DeptNo WHERE [EmpNo] = @EmpNo">
                <DeleteParameters>
                    <asp:Parameter Name="EmpNo" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="EmpNo" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Basic" Type="Decimal" />
                    <asp:Parameter Name="DeptNo" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Basic" Type="Decimal" />
                    <asp:Parameter Name="DeptNo" Type="Int32" />
                    <asp:Parameter Name="EmpNo" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
