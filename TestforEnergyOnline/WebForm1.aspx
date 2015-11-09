<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestforEnergyOnline.WebForm1" %>

<%@ Register TagPrefix="sow" TagName="sowheader" Src="~/header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Details</title>
    <style type="text/css">
        *
        {
            margin: 0px;
            padding: 0;
        }
        
        body
        {
            font-family: Sans-Serif;
        }
        
        #pgBackgrd
        {
            width: 600px;
            margin: 0 auto;
            background-color: #F1F1F1;
        }
        
        h1 { font-size: 20px; margin: 12px; text-align: center; }
        h3 { font-size: 18px; margin-bottom: 4px; margin-top: 12px; }
        #Save, #Update { display: block;  }
        input[type="text"] { }
        
        label
        {
            display: block;
            font-size: 13px;
            font-weight: bold;
            margin: 3px 0;
        }
        
        input 
        {
            margin-bottom: 12px;
            width: 350px; 
            padding:6px;
            border-radius: 3px; 
        }
        
        #main { margin: 10px; padding: 10px; }
        
        .style1
        {
            width: 124px;
        }
        
        .empName
        {
            text-transform: capitalize;
        }
    </style>
</head>
<body>
    <div id="pgBackgrd">
        <div id="main">
            <h1>
                Employee details
            </h1>
            <form id="form1" runat="server">
            <div>
                <asp:Panel ID="Panel1" runat="server">
                    <label>
                        Employee Name</label>
                    <asp:TextBox ID="txtName" runat="server" OnTextChanged="txtName_TextChanged" placeHolder="Last Name, First Name"></asp:TextBox>
                    <label>
                        Job Title</label>
                    <asp:TextBox ID="txtJob" runat="server" placeHolder="Job description" OnTextChanged="txtJob_TextChanged"></asp:TextBox>
                    <label>
                        Salary</label>
                    <asp:HiddenField ID="txtEmpNo" runat="server" />
                    <asp:TextBox ID="txtSalary" runat="server" placeHolder="Per annum in $"></asp:TextBox>
                    <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />
                    <asp:Button ID="Update" runat="server" Text="Update" Visible="false" OnClick="Update_Click" />
                </asp:Panel>
            </div>
            <h3>
                Details of Current Employees</h3>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                AllowSorting="True" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                CellPadding="4" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="EmpName" ItemStyle-CssClass="empName" />
                    <asp:BoundField DataField="JobTitle" HeaderText="Job" />
                    <asp:BoundField DataField="Salary" HeaderText="Salary" />
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ID") %>'
                                OnClick="lnkEmpEdit_Click">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ID") %>'
                                OnClick="lnkEmpDelete_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DbCompanyConnectionString %>"
                SelectCommand="SELECT * FROM [Emp]"></asp:SqlDataSource>
            </form>
        </div>
        <sow:sowheader ID="Sowheader1" runat="server" />
    </div>
</body>
</html>
