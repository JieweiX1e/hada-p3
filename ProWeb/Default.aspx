<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProWeb.WebForm1" %>

<asp:Content ContentPlaceHolderID="cph1" ID="form" runat="server" style="text-align: center;
                                                                         text-justify: auto;">
    <h1>Products management</h1>
    <div style="padding:5px;">
        <p>
            Code    
            <asp:TextBox ContentPlaceHolderID="cph1" ID="TB_Code" runat="server">
            </asp:TextBox>
            <asp:RegularExpressionValidator ID="CodeValidator" 
                                            runat="server" 
                                            ControlToValidate="TB_Code" 
                                            ErrorMessage="Enter a valid code"
                                            ForeColor="Red"
                                            Display="Static"
                                            ValidationGroup="formGroup"
                                            ValidationExpression="^([\S\s]{1,16})" />
        </p>
        <p>
            Name    
            <asp:TextBox ContentPlaceHolderID="cph1" ID="TB_Name" runat="server">
            </asp:TextBox>
            <asp:RegularExpressionValidator ID="RequiredFieldValidator1" 
                            runat="server" 
                            ControlToValidate="TB_Name" 
                            ErrorMessage="Enter a valid name"
                            Display="Static"
                            ForeColor="Red"
                            ValidationGroup="formGroup"
                            ValidationExpression="^([\S\s]{0,32})"/>
        </p>
        <p>
            Amount  
            <asp:TextBox ContentPlaceHolderID="cph1" ID="TB_Amount" runat="server">
            </asp:TextBox>
            <asp:RangeValidator id="Range1"
                                ControlToValidate="TB_Amount"
                                MinimumValue="0"
                                MaximumValue="9999"
                                Type="Integer"
                                ForeColor="Red"
                                EnableClientScript="false"
                                Text="The value must be from 0 to 9999"
                                runat="server"/>
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
            <asp:RangeValidator id="RangeValidator1"
                    ControlToValidate="TB_Price"
                    MinimumValue="0"
                    MaximumValue="9999,99"
                    Type="Currency"
                    EnableClientScript="false"
                    ForeColor="Red"
                    Text="The value must be from 0.00 to 9999.99"
                    runat="server"/>
        </p>
        <p>
            Creation date  
            <asp:TextBox ContentPlaceHolderID="cph1" ID="Date" runat="server">
            </asp:TextBox>
            <asp:CustomValidator ID="DateValidator"
                                 ControlToValidate="Date"
                                 runat="server"/>
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