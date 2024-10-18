<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Aadil_Asp_Project.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Name :</td>
                    <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td>Age :</td>
                    <td><asp:TextBox ID="txtage" runat="server"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td>Blood Group :</td>
                    <td><asp:RadioButtonList ID="rblbg" runat="server" RepeatColumns="3"></asp:RadioButtonList></td>
                </tr>
                  <tr>
                    <td>Country :</td>
                    <td><asp:DropDownList ID="ddlcountry" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                </tr>
                  <tr>
                    <td>State :</td>
                    <td><asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList></td>
                </tr>
                  <tr>
                    <td></td>
                    <td><asp:Button ID="btninsert" Text="Insert" OnClick="btninsert_Click" runat="server"></asp:Button></td>
                </tr>
                  <tr>
                    <td></td>
                    <td><asp:GridView ID="gvuser" runat="server" OnRowCommand="gvuser_RowCommand" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="User_Id">
                                <ItemTemplate>
                                    <%#Eval ("uid") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="User_Name">
                                <ItemTemplate>
                                    <%#Eval ("uname") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="U_Age">
                                <ItemTemplate>
                                    <%#Eval ("uage") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="User_BG">
                                <ItemTemplate>
                                    <%#Eval ("bgname") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="User_Country">
                                <ItemTemplate>
                                    <%#Eval ("cname") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="User_State">
                                <ItemTemplate>
                                    <%#Eval ("sname") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:Button ID="btndelete" Text="Delete" runat="server" CommandName="A" CommandArgument='<%#Eval ("uid") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField >
                                <ItemTemplate>
                                     <asp:Button ID="btnedit" Text="Edit" runat="server" CommandName="B" CommandArgument='<%#Eval ("uid") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
