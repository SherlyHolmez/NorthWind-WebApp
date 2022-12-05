<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NorthWind_WebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <table class="nav-justified">
            <tr>
                <td style="width: 401px; background-color: #66CCFF;" class="modal-sm">
                    <strong>
                    <asp:Label ID="Label1" runat="server" Text="Customer ID"></asp:Label>
                    </strong>
                </td>
                <td style="width: 64px">&nbsp;</td>
                <td style="width: 66px">
                    <asp:TextBox ID="CustomerIDTextBox" runat="server" Width="231px" MaxLength="6"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 401px; background-color: #66CCFF;" class="modal-sm">
                    <strong>
                    <asp:Label ID="Label2" runat="server" Text="Company Name"></asp:Label>
                    </strong>
                </td>
                <td style="width: 64px">&nbsp;</td>
                <td style="width: 66px">
                    <asp:TextBox ID="CompanyNameTextBox" runat="server" Width="231px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="AddButton" runat="server" Text="Add" Width="82px" OnClick="AddButtonClick" />
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit" Width="82px" OnClick="SubmitButtonClick" />
                </td>
            </tr>
            <tr>
                <td style="width: 401px; height: 26px; background-color: #66CCFF;">
                    <strong>
                    <asp:Label ID="Label3" runat="server" Text="Customer Name"></asp:Label>
                    </strong>
                </td>
                <td style="width: 64px; height: 26px;"></td>
                <td style="width: 66px; height: 26px;">
                    <asp:TextBox ID="CustomerNameTextBox" runat="server" Width="231px"></asp:TextBox>
                </td>
                <td style="height: 26px">
                    <asp:Button ID="UpdateButton" runat="server" OnClick="UpdateButtonClick" Text="Update" Width="82px" />
                </td>
            </tr>
            <tr>
                <td style="width: 401px; height: 19px; background-color: #66CCFF;">
                    <strong>
                    <asp:Label ID="Label4" runat="server" Text="Contact Title"></asp:Label>
                    </strong>
                </td>
                <td style="width: 64px; height: 19px"></td>
                <td style="width: 66px; height: 19px">
                    <asp:TextBox ID="CustomerTitleTextBox" runat="server" Width="231px"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    <asp:Button ID="DeleteButton" runat="server" OnClick="DeleteButtonClick" Text="Delete" Width="82px" />
                </td>
            </tr>
            <tr>
                <td style="width: 401px; background-color: #66CCFF;" class="modal-sm">
                    <strong>
                    <asp:Label ID="Label5" runat="server" Text="Address"></asp:Label>
                    </strong>
                </td>
                <td style="width: 64px">&nbsp;</td>
                <td style="width: 66px">
                    <asp:TextBox ID="AddressTextbox" runat="server" Width="231px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 401px; height: 22px; background-color: #66CCFF;">
                    <strong>
                    <asp:Label ID="Label6" runat="server" Text="Order Details"></asp:Label>
                    </strong>
                </td>
                <td style="width: 64px; height: 22px"></td>
                <td style="width: 66px; height: 22px">
                    <asp:TextBox ID="OrderDetailsTextBox" runat="server" Width="231px"></asp:TextBox>
                </td>
                <td style="height: 22px"></td>
            </tr>
            <tr>
                <td style="height: 126px; width: 401px">
                    <div class="text-center">
                    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="background-color: #FFCC00">
                    </asp:GridView>
                    </div>
                </td>
                <td style="height: 126px; width: 64px"></td>
                <td style="height: 126px; width: 66px">
                    <asp:Button ID="FirstButton" runat="server" OnClick="FirstButtonClick" Text="First" Width="82px" />
                    <asp:Button ID="LastButton" runat="server" OnClick="LastButtonClick" Text="Last" Width="82px" />
                    <asp:Button ID="NextButton" runat="server" OnClick="NextButtonClick" Text="Next" Width="82px" />
                    <asp:Button ID="PreviousButton" runat="server" OnClick="PreviousButtonClick" Text="Previous" Width="82px" />
                </td>
                <td style="height: 126px"></td>
            </tr>
            <tr>
                <td style="width: 401px; height: 20px;"></td>
                <td style="width: 64px; height: 20px;"></td>
                <td style="width: 66px; height: 20px;"></td>
                <td style="height: 20px"></td>
            </tr>
        </table>
        <table>
            </table>

    </div>

 
</asp:Content>

