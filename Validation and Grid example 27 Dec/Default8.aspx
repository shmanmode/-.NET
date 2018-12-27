<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default8.aspx.cs" Inherits="Default8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="EmpNo" DataSourceID="sqldsEmps" ForeColor="#333333" GridLines="None" PageSize="4">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="EmpNo" HeaderText="EmpNo" ReadOnly="True" SortExpression="EmpNo" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Basic" HeaderText="Basic" SortExpression="Basic" />
                    <asp:TemplateField HeaderText="DeptNo" SortExpression="DeptNo">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sqldsDepts" DataTextField="DeptName" DataValueField="DeptNo" SelectedValue='<%# Bind("DeptNo") %>'>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="sqldsDepts" runat="server" ConnectionString="<%$ ConnectionStrings:VikramConnectionString %>" SelectCommand="SELECT * FROM [Departments]"></asp:SqlDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("DeptNo") %>'></asp:Label>
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
            <asp:SqlDataSource ID="sqldsEmps" runat="server" ConnectionString="<%$ ConnectionStrings:VikramConnectionString %>" DeleteCommand="DELETE FROM [Employees] WHERE [EmpNo] = @EmpNo" InsertCommand="INSERT INTO [Employees] ([EmpNo], [Name], [Basic], [DeptNo]) VALUES (@EmpNo, @Name, @Basic, @DeptNo)" SelectCommand="SELECT * FROM [Employees]" UpdateCommand="UPDATE [Employees] SET [Name] = @Name, [Basic] = @Basic, [DeptNo] = @DeptNo WHERE [EmpNo] = @EmpNo">
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
