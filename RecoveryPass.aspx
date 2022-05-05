<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoveryPass.aspx.cs" Inherits="WebOzyrys.RecoveryPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Odzyskiwanie Hasła</title>
    <meta http-equiv="X-UA-Compatible" content="IE-edge"/>
    <meta name="description" content="Serwis internetowy aplikacji Ozyrys"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="author" content="Adam Osmański"/>
    <link rel="stylesheet" href="./Style.css"/>
    <link rel="shortcut icon" href="World.ico" />

</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-top: 15%;">
            <table class="recover_pass_table">
                <tr>
                    <td colspan="5" align="center">
                        <asp:Label ID="Communicate" runat="server" Text="Wprowadź swój adres mailowy następnie numer telefonu aby otrzymać hasło tymczasowe."></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td align="center" class="auto-style2"><asp:Label ID="lab_email" runat="server" Text="Mail: "></asp:Label></td>
                    <td colspan="2" align="center">                        
                        <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2"><asp:Label ID="lab_phone" runat="server" Text="Numer telefonu: "></asp:Label></td>
                    <td colspan="2" align="center">
                        <asp:TextBox ID="txt_phone_number" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btn_submit" runat="server" Text="Wygeneruj nowe hasło" OnClick="btn_submit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
