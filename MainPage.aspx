<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebOzyrys.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ozyrys</title>
    <meta http-equiv="X-UA-Compatible" content="IE-edge"/>
    <meta name="description" content="Serwis internetowy aplikacji Ozyrys"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="author" content="Adam Osmański"/>
    <link rel="stylesheet" href="./Style.css"/>
    <link rel="shortcut icon" href="World.ico" />
    <script>
        history.pushState("login", "", "login");
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-top: 15%;">
            <table class="table">
                <tr>
                    <td colspan="2" style="text-align:center; font-weight:bold;">Logowanie do systemu Ozyrys</td>
                    
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lab_login" runat="server" Text="Mail: "></asp:Label>
                    </td>
                    <td>
                         <asp:TextBox ID="txt_User" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>                
                    <td class="auto-style1">
                        <asp:Label ID="lab_pass" runat="server" Text="Hasło: "></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox type="password" ID="txt_pass" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td></td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button CssClass="buttons" ID="btn_login" runat="server" Text="Zaloguj" OnClick="btn_login_Click" Width="124px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="ErrorLab" runat="server" Text="Nieprawidłowy mail lub hasło"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" >
                        <asp:LinkButton ID="Recovery_Pass" runat="server" OnClick="Recovery_Pass_Click">Przypomnij hasło</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="data_ozyrys" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
        </body>
</html>
