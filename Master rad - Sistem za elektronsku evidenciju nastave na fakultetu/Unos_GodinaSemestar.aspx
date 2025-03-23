

<%@ Page Title="Unos_GodinaSemestar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Unos_GodinaSemestar.aspx.cs" Inherits="MilanKrstic.Unos_GodinaSemestar"  %> 


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EDnevnikVranje %>" SelectCommand="SELECT * FROM [GodinaSemestar]" UpdateCommand="UPDATE GodinaSemestar set akademskaGodina = @akademskaGodina ,godina=@godina,semestar=@semestar,status=@status where id=@id"></asp:SqlDataSource>



    
    
    <asp:GridView ID="EDnevnikVranje" runat="server" AutoGenerateColumns="False" ShowFooter="True"  BorderStyle="Solid" BorderWidth="1px" 
        ShowHeaderWhenEmpty="True"
        
        
               OnRowCommand="EDnevnikVranje_RowCommand" OnRowEditing="EDnevnikVranje_RowEditing" OnRowCancelingEdit="EDnevnikVranje_RowCancelingEdit" Font-Size="Small"
                OnRowUpdating="EDnevnikVranje_RowUpdating" OnRowDeleting="EDnevnikVranje_RowDeleting"   OnPageIndexChanging="EDnevnikVranje_PageIndexChanging"
        
       CellPadding="4"  Height="100%" Width="100%" Word-Wrap="break-word" Table-Layout= "fixed"  ForeColor="#333333" GridLines="Horizontal" DataKeyNames="id,akademskaGodina,godina,semestar,status" AllowPaging="True" >
        
       

        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    

        <EditRowStyle BackColor="#2461BF"></EditRowStyle>

        <FooterStyle BackColor="#507CD1" ForeColor="Black" Font-Bold="True" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" BorderStyle="None" />
        <RowStyle Font-Size="16px"  BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#000000" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />







        <Columns>
            <asp:TemplateField HeaderText="Id"  >
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("id") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtId" runat="server" Enabled="false" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtIdFooter" runat="server" Enabled="false"  />
                </FooterTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Akademska godina">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("akademskaGodina") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAkademskaGodina" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtAkademskaGodinaFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Godina">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("godina") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtGodina" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtGodinaFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Semestar">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("semestar") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSemestar" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtSemestarFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("status") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="txtStatus" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:CheckBox ID="txtStatusFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"  />
                    <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                    <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>









    </asp:GridView>
    <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />

   
</asp:Content>