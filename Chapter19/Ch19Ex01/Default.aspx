<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ch19Ex01._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="cardGameTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Player 1</asp:TableHeaderCell>
            <asp:TableHeaderCell>Player 2</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="player1TextBox" runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="player2TextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
               <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidatorplayer1TextBox" 
                    runat="server" style="color:Red;"
                    ErrorMessage="A name for Player 1 is required." 
                    ControlToValidate="player1TextBox">
                </asp:RequiredFieldValidator>
            </asp:TableCell>
            <asp:TableCell>
               <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidatorplayer2TextBox" 
                    runat="server" style="color:Red;"
                    ErrorMessage="A name for Player 2 is required." 
                    ControlToValidate="player2TextBox">
                </asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Button ID="dealHandButton" runat="server" Text="Deal Hand" 
        OnClick="dealHandButton_Click" />
    <br />
    <asp:Label ID="dealtHandLabel" runat="server" Visible="false" 
        Text="Here are the cards." />
    <asp:Table ID="dealtHandsTable" runat="server" Visible="false" />
</asp:Content>