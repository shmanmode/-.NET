<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default12.aspx.cs" Inherits="Default12" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmpNo" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="EmpNo" HeaderText="EmpNo" ReadOnly="True" SortExpression="EmpNo" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Basic" HeaderText="Basic" SortExpression="Basic" />
                    <asp:BoundField DataField="DeptNo" HeaderText="DeptNo" SortExpression="DeptNo" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VikramConnectionString %>" SelectCommand="SELECT * FROM [Employees] WHERE ([DeptNo] = @DeptNo)">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="10" Name="DeptNo" QueryStringField="DeptNo" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
