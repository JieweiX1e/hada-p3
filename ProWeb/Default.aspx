<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProWeb.WebForm1" %>

<asp:Content ContentPlaceHolderID="cph1" ID="form" runat="server" style="text-align: center;
                                                                         text-justify: auto;">
    <h1>Products management</h1>
    <div style="padding:5px;">
        <p>
            Code    
            <asp:TextBox ContentPlaceHolderID="cph1" ID="TB_Code" runat="server">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="CodeValidator1"
                                        runat="server"
                                        ControlToValidate="TB_Code"
                                        ErrorMessage="Enter a code"
                                        ForeColor="Red"
                                        ValidationGroup="Ess"
                                        Display="Static"/>
            <asp:RegularExpressionValidator ID="CodeValidator2" 
                                            runat="server" 
                                            ControlToValidate="TB_Code" 
                                            ErrorMessage="Enter a valid code"
                                            ForeColor="Red"
                                            Display="Static"
                                            ValidationGroup="Essential"
                                            ValidationExpression="^([\S\s]{1,16})" />
        </p>
        <p>
            Name    
            <asp:TextBox ContentPlaceHolderID="cph1" ID="TB_Name" runat="server">
            </asp:TextBox>
            <asp:RegularExpressionValidator ID="RegExValidator1" 
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
            <asp:TextBox ContentPlaceHolderID="cph1" ID="TB_Date" runat="server">
            </asp:TextBox>
            <asp:CustomValidator ID="DateValidator"
                                 ControlToValidate="TB_Date"
                                 OnServerValidate="Date_ServerValidate"
                                 ErrorMessage="Incorrect date"
                                 ForeColor="Red"
                                 runat="server"/>
        </p>
    </div>
    <div style="width:100%;
                padding:10px;">
        <asp:Button ContentPlaceHolderID="buttons" Width="13%" runat="server" ID="Create" Text="Create" onClick="CreateButton_onClick" />
        <asp:Button ContentPlaceHolderID="buttons" Width="13%" runat="server" ID="Update" Text="Update" onClick="UpdateButton_onClick" />
        <asp:Button ContentPlaceHolderID="buttons" Width="13%" runat="server" ID="Delete" Text="Delete" onClick="DeleteButton_onClick" />
        <asp:Button ContentPlaceHolderID="buttons" Width="13%" runat="server" ID="Read" Text="Read" onClick="ReadButton_onClick" />
        <asp:Button ContentPlaceHolderID="buttons" Width="13%" runat="server" ID="Read1" Text="Read First" onClick="ReadFirstButton_onClick" />
        <asp:Button ContentPlaceHolderID="buttons" Width="13%" runat="server" ID="ReadP" Text="Read Prev" onClick="ReadPrevButton_onClick" />
        <asp:Button ContentPlaceHolderID="buttons" Width="13%" runat="server" ID="ReadN" Text="Read Next" onClick="ReadNextButton_onClick" />
    </div>
</asp:Content>