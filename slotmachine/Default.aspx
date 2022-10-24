<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="slotmachine._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="padding: 20px;">
        <section>
            <div class="row">
                <div class="col" style="text-align: center;">
                    <img class="pulse animated infinite" src="assets/img/logo.png" style="width: 300px;">
                </div>
            </div>
            <h4>(test/test)Welcome:
                <asp:Label ID="Welcome" runat="server" Text=""></asp:Label>
            </h4>
            <div class="row" style="padding-top: 25px;">
                <div class="col d-sm-flex d-xxl-flex align-items-sm-center justify-content-md-end justify-content-xxl-end align-items-xxl-center" style="text-align: right;">

                    <div class="input-group zindextexts" style="padding-left: 0px; max-width: 300px;">
                        <span class="input-group-text">Username</span>
                        <asp:TextBox CssClass="form-control" ID="Username" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="input-group zindextexts" style="max-width: 300px;">
                        <span class="input-group-text">Password</span>
                        <asp:TextBox CssClass="form-control" TextMode="Password" ID="Password" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="d-sm-flex justify-content-sm-center align-items-sm-center zindextexts" style="text-align: center;">
                        <asp:Button CssClass="btn btn-dark buttonMargin zindextexts" ID="login" runat="server" Text="Login" OnClick="login_Click" />
                        <asp:Button CssClass="btn btn-secondary buttonMargin zindextexts" ID="clear" runat="server" Text="Clear" />
                        <asp:Button CssClass="btn btn-dark buttonMargin zindextexts" disabled ID="exit" runat="server" Text="Logout" OnClick="exit_Click" />
                        <div style="position: absolute; width: 162px; height: 225px; z-index: 2; background: red; margin-left: 0px;"></div>
                        <div style="position: absolute; width: 162px; height: 225px; z-index: 2; background: black; margin-left: 820px;"></div>
                        <div style="position: absolute; width: 162px; height: 225px; z-index: 2; background: blue; margin-left: -820px;"></div>
                        <div class="d-xxl-flex justify-content-xxl-center" style="text-align: center; z-index: 3;">
                            <asp:Button CssClass="btn btn-info zindextexts" ID="addcredit" runat="server" Text="+5 Credit" OnClick="addcredit_Click" />
                        </div>
                    </div>
                </div>
        </section>
        <section style="padding: 30px;">
            <div class="row">
                <div class="col">
                    <div class="d-flex justify-content-around zindextexts" style="padding: 10px;">
                        <div class="zindextexts">
                            <label class="form-label" style="font-size: 25px;">Credit:&nbsp;</label>
                            <span class="badge bg-warning" style="font-size: 25px;">
                                <asp:Label ID="Credit" runat="server" Text="0"></asp:Label>
                            </span>
                        </div>
                        <div class="zindextexts">
                            <label class="form-label" style="font-size: 25px;">Bet:&nbsp;</label>
                            <span class="badge bg-danger" style="font-size: 25px;">
                                <asp:Label ID="Bet" runat="server" Text="2$"></asp:Label>
                            </span>
                        </div>
                        <div class="zindextexts">
                            <label class="form-label" style="font-size: 25px;">Win:&nbsp;</label>
                            <span class="badge bg-success" style="font-size: 25px;">
                                <asp:Label ID="Win" runat="server" Text="0"></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="slotdiv" CssClass="row" runat="server">
                <div class="col" style="text-align: center;">
                    <asp:Image ID="image3" CssClass="img-fluid rounded-circle" Height="200px" runat="server" ImageUrl="assets/img/0.jpg" />
                </div>
                <div class="col" style="text-align: center;">
                    <asp:Image ID="image2" CssClass="img-fluid rounded-circle" Height="200px" runat="server" ImageUrl="assets/img/0.jpg" />
                </div>
                <div class="col" style="text-align: center;">
                    <asp:Image ID="image1" CssClass="img-fluid rounded-circle" Height="200px" runat="server" ImageUrl="assets/img/0.jpg" />
                </div>
            </asp:Panel>
            <div class="row">
                <div class="col" style="text-align: center;">
                    <asp:Button CssClass="btn btn-danger" ID="Spin" runat="server" Text="Spin" OnClick="spin_Click" Width="300px" />
                </div>
                <h5><a href="assets/img/wintable.png" target="_blank">How can i win ?</a></h5>
            </div>
        </section>
    </div>
</asp:Content>
