<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProWeb.WebForm1" %>

<asp:Content ContentPlaceHolderID="cph1" ID="form" runat="server" style="text-align: center;
                                                                         text-justify: auto;">
    <h1>Products management</h1>
    <div style="padding:5px;">
        <p>
            Code    
            <asp:TextBox ContentPlaceHolderID="cph1" ID="TB_Code" runat="server">
            </asp:TextBox>
        </p>
        <p>
            Name    
            <asp:TextBox ContentPlaceHolderID="cph1" ID="TB_Name" runat="server">
            </asp:TextBox>
        </p>
        <p>
            Amount  
            <asp:TextBox ContentPlaceHolderID="cph1" ID="TB_Amount" runat="server">
            </asp:TextBox>
        </p>
        <p>
            Category
            <asp:DropDownList id="DDL_Category" 
                              runat="server">
                <asp:ListItem Selected="True" Value=0> Computing </asp:ListItem>
                <asp:ListItem Value=1> Telephony </asp:ListItem>
                <asp:ListItem Value=2> Gaming </asp:ListItem>
                <asp:ListItem Value=3> Home appliances </asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            Price 
            <asp:TextBox ContentPlaceHolderID="cph1" ID="TB_Price" runat="server">
            </asp:TextBox>
        </p>
        <p>
            Creation date  
            <asp:TextBox ContentPlaceHolderID="cph1" ID="TextBox2" runat="server">
            </asp:TextBox>
        </p>
    </div>
    <div style="width:100%;
                padding:10px;">
        <asp:Button ContentPlaceHolderID="buttons" Text="Create" Width="13%" runat="server" />
        <asp:Button ContentPlaceHolderID="buttons" Text="Update" Width="13%" runat="server" />
        <asp:Button ContentPlaceHolderID="buttons" Text="Delete" Width="13%" runat="server" />
        <asp:Button ContentPlaceHolderID="buttons" Text="Read" Width="13%" runat="server" />
        <asp:Button ContentPlaceHolderID="buttons" Text="Read First" Width="13%" runat="server" />
        <asp:Button ContentPlaceHolderID="buttons" Text="Read Prev" Width="13%" runat="server" />
        <asp:Button ContentPlaceHolderID="buttons" Text="Read Next" Width="13%" runat="server" />
    </div>
</asp:Content>