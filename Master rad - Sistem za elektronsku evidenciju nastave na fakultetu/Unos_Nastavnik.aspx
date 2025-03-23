
<%@ Page Title="Unos_Nastavnik" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Unos_Nastavnik.aspx.cs" Inherits="MilanKrstic.Unos_Nastavnik"  %> 


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EDnevnikVranje %>" SelectCommand="SELECT * FROM [Nastavnik]" UpdateCommand="UPDATE Nastavnik set ime=@ime,srednjeSlovo=@srednjeSlovo,prezime=@prezime,katedra=@katedra,zvanje=@zvanje,tipAngazovanja=@tipAngazovanja,status=@status where id=@id"></asp:SqlDataSource>



    
    
    <asp:GridView ID="EDnevnikVranje" runat="server" AutoGenerateColumns="False" ShowFooter="True" 
        ShowHeaderWhenEmpty="True"
        
        
               OnRowCommand="EDnevnikVranje_RowCommand" OnRowEditing="EDnevnikVranje_RowEditing" OnRowCancelingEdit="EDnevnikVranje_RowCancelingEdit" Font-Size="Small"
                OnRowUpdating="EDnevnikVranje_RowUpdating" OnRowDeleting="EDnevnikVranje_RowDeleting"   OnPageIndexChanging="EDnevnikVranje_PageIndexChanging" 
        
        CellPadding="4"  Height="100%" Width="100%" Word-Wrap="break-word" Table-Layout= "fixed" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="id,ime,srednjeSlovo,prezime,katedra,zvanje,tipAngazovanja,status" AllowPaging="True">

       

        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    

        <EditRowStyle BackColor="#2461BF"></EditRowStyle>

        <FooterStyle BackColor="#507CD1" ForeColor="Black" Font-Bold="True" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
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
                    <asp:TextBox ID="txtIdFooter" runat="server" Enabled="false" />
                </FooterTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Ime">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("ime") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtIme" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtImeFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Srednje Slovo">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("srednjeSlovo") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSrednjeSlovo" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtSrednjeSlovoFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Prezime">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("prezime") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPrezime" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtPrezimeFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Katedra">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("katedra") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtKatedra" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtKatedraFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>


             <asp:TemplateField HeaderText="Zvanje"  >
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("zvanje") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtZvanje" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtZvanjeFooter" runat="server"   />
                </FooterTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Tip Angazovanja">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("tipAngazovanja") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtTipAngazovanja" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtTipAngazovanjaFooter" runat="server" />
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