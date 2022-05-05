<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPanel.aspx.cs" Inherits="WebOzyrys.UserPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Panel Użytkownika</title>
    
    <meta http-equiv="X-UA-Compatible" content="IE-edge"/>
    <meta name="description" content="Serwis internetowy aplikacji Ozyrys"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="author" content="Adam Osmański"/>
    <link rel="stylesheet" href="./Style.css"/>
    <link rel="shortcut icon" href="World.ico" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="nav-bar">
                <table class="table-nav">
                    <tr>
                        <td rowspan="2">
                            <asp:Label ID="lab_title_app" runat="server" Text="Ozyrys online" Font-Bold="true" Font-Size="Medium"></asp:Label>
                        </td>
                        <td></td>
                        <td></td>
                        <td style="width:120px;" rowspan="2">
                            <div align="center">
                                <img src="Asserts/Usersi.png" /><br />
                                <asp:Button ID="btn_kontrahenci" runat="server" Text="Kontrahenci" OnClick="btn_kontrahenci_Click"/>
                            </div>
                        </td>
                        <td style="width:120px;" rowspan="2" align="center"><img style="cursor:pointer;" class="mojedane_img"  src="Asserts/Account_User.png" /><br />
                            <asp:LinkButton ID="btn_moje_dane" runat="server" OnClick="btn_moje_dane_Click">Moje dane</asp:LinkButton>
                        </td>
                        <td rowspan="2" align="center">
                            <asp:Button ID="logout" runat="server" Text="Wyloguj" OnClick="logout_Click" Width="30%" Height="100%"/>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </nav>
        </div>
        <div class="wrapper">
            <div>Strona główna</div>
            <asp:Panel ID="panel_moje_dane" runat="server">                
                <div class="title_data">
                    <p>Moje dane</p>
                </div>
                <div class="dane">
                    <table class="tabelka_dane">
                        <tr style="width:50%;">
                            <td>
                                <p>Imię:</p>
                            </td>

                            <td align="left">
                                <asp:TextBox ID="txt_old_imie" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><p>Nazwisko:</p></td>
                            <td><asp:TextBox ID="txt_old_nazwisko" runat="server" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><p>Pesel:</p></td>
                            <td><asp:TextBox ID="txt_old_pesel" runat="server" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><p>Mail:</p></td>
                            <td><asp:TextBox ID="txt_old_mail" runat="server" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><p>Telefon:</p></td>
                            <td><asp:TextBox ID="txt_old_telefon" runat="server" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><p>Kraj:</p></td>
                            <td><asp:TextBox ID="txt_old_kraj" runat="server" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><p>Miasto:</p></td>
                            <td><asp:TextBox ID="txt_old_city" runat="server" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><p>Adres:</p></td>
                            <td><asp:Textbox ID ="txt_old_adress" runat="server" Width="350px"></asp:Textbox></td>
                        </tr>
                        <tr><td><p> </p></td><td><p> </p></td></tr><tr><td><p> </p></td><td><p> </p></td></tr><tr><td><p> </p></td><td><p> </p></td></tr><tr><td><p> </p></td><td><p> </p></td></tr>
                        <tr class="przyciski_dane">
                            <td align="center">
                                <asp:Button ID="btn_edytuj" runat ="server" OnClick="btn_edytuj_dane_Click" Text="Edytuj Dane" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btn_dane_zapisac" runat="server" Text="Zapisz Dane" OnClick="btn_zapisz_dane_Click" />
                            </td>
                        </tr>
                    </table>
                </div>                
            </asp:Panel>
            <asp:Panel ID="panel_kontrahenci" runat="server">
                <p class="title_kontrahenci">Kontrahenci</p>
                <div class="info_kontrahenci">
                    <asp:Button runat="server" ID="btn_dodaj_kontrahenta" Text="Dodaj Kontrahenta" OnClick="btn_dodaj_kontrahenta_Click" />
                    <asp:Panel ID="panel_dodaj_kh" runat="server">
                        <table style="margin-top:30px">
                            <tr>
                                <td><p>Nip: </p></td>
                                <td><asp:TextBox ID="txt_nip_kh" runat="server"></asp:TextBox></td>
                                <td></td>
                                <td><p>Nazwa firmy: </p></td>
                                <td><asp:TextBox ID="txt_nazwa_kh" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><p>Finansowanie: </p></td>
                                <td><asp:TextBox ID="txt_finansowanie" runat="server"></asp:TextBox></td>
                                <td></td>
                                <td><p>Zakończenie finansowania: </p></td>
                                <td><asp:TextBox ID="txt_koniec_finansowania" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><p>Mail: </p></td>
                                <td><asp:TextBox ID="txt_mail_kh" runat="server"></asp:TextBox></td>
                                <td></td>
                                <td><p>Telefon: </p></td>
                                <td><asp:TextBox ID="txt_phone_kh" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td><asp:Button ID="btn_dodaj_kh_do_umowy" runat="server" Text="Dodaj klienta do umowy" OnClick="Insert_KH_toBase" /></td>
                            </tr>
                        </table> 
                    </asp:Panel>
                    <div class="dane_kontrahent">  
                        <asp:Panel ID="panel_dgv_kontrahent" runat="server">
                            <asp:GridView ID="dgv_kontrahent" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="NIP" HeaderText ="NIP" />
                                    <asp:BoundField DataField="FirmName" HeaderText ="Nazwa Firmy" />
                                    <asp:BoundField DataField="Financing" HeaderText ="Finansowanie" />
                                    <asp:BoundField DataField="FinancingDate" HeaderText ="Koniec Finansowania" />
                                    <asp:BoundField DataField="Mail" HeaderText ="Mail" />
                                    <asp:BoundField DataField="Phone" HeaderText ="Telefon" />
                                </Columns>
                            </asp:GridView>f
                        </asp:Panel>                        
                    </div>
                </div></asp:Panel>
            
        </div>
    </form>
</body>
</html>
