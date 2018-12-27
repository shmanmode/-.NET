<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default11.aspx.cs" Inherits="Default11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="DeptNo" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="DeptNo" HeaderText="DeptNo" ReadOnly="True" SortExpression="DeptNo" />
                    <asp:BoundField DataField="DeptName" HeaderText="DeptName" SortExpression="DeptName" />
                    <asp:HyperLinkField DataNavigateUrlFields="DeptNo,DeptName" DataNavigateUrlFormatString="Default12.aspx?DeptNo={0}&amp;DeptName={1}" DataTextField="DeptNo" DataTextFormatString="View Emps for DeptNo {0}" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VikramConnectionString %>" SelectCommand="SELECT * FROM [Departments]"></asp:SqlDataSource>
        </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:VikramConnectionString %>" DeleteCommand="DELETE FROM [Employees] WHERE [EmpNo] = @EmpNo" InsertCommand="INSERT INTO [Employees] ([EmpNo], [Name], [Basic], [DeptNo]) VALUES (@EmpNo, @Name, @Basic, @DeptNo)" SelectCommand="SELECT * FROM [Employees]" UpdateCommand="UPDATE [Employees] SET [Name] = @Name, [Basic] = @Basic, [DeptNo] = @DeptNo WHERE [EmpNo] = @EmpNo">
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
    </form>
</body>
</html>
