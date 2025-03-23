




<%@ Page Title="Unos_KartonPredmeta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Unos_KartonPredmeta.aspx.cs" Inherits="MilanKrstic.Unos_KartonPredmeta"  %> 


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EDnevnikVranje %>" SelectCommand="SELECT * FROM [KartonPredmeta]" UpdateCommand="UPDATE KartonPredmeta set tipStudija_id=@tipStudija_id,name=@name,tip=@tip,casoviPredavanja=@casoviPredavanja,casoviVezbe=@casoviVezbe,casoviDon=@casoviDon,casoviPraksa=@casoviPraksa,status=@status where id=@id"> </asp:SqlDataSource>



    
    
    <asp:GridView ID="EDnevnikVranje" runat="server" AutoGenerateColumns="False" ShowFooter="True" 
        ShowHeaderWhenEmpty="True"
        
         
               OnRowCommand="EDnevnikVranje_RowCommand" OnRowEditing="EDnevnikVranje_RowEditing" OnRowCancelingEdit="EDnevnikVranje_RowCancelingEdit" Font-Size="Small"
                OnRowUpdating="EDnevnikVranje_RowUpdating" OnRowDeleting="EDnevnikVranje_RowDeleting"   OnPageIndexChanging="EDnevnikVranje_PageIndexChanging"
        
        CellPadding="4" Height="100%" Width="100%" Word-Wrap="break-word" Table-Layout= "fixed" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="id,tipStudija_id,name,tip,casoviPredavanja,casoviVezbe,casoviDon,casoviPraksa,status" AllowPaging="True">

        

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
                    <asp:TextBox ID="txtIdFooter" runat="server" Enabled="false"  />
                </FooterTemplate>
                </asp:TemplateField> 

            <asp:TemplateField HeaderText="TipStudija_id">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("tipStudija_id") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtTipStudija_id" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtTipStudija_idFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Naziv predmeta">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("name") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtNameFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tip">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("tip") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtTip" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtTipFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Casovi Predavanja">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("casoviPredavanja") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCasoviPredavanja" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtCasoviPredavanjaFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Casovi Vezbe">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("casoviVezbe") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCasoviVezbe" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtCasoviVezbeFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Casovi Don">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("casoviDon") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCasoviDon" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtCasoviDonFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Casovi Praksa">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("casoviPraksa") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCasoviPraksa" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtCasoviPraksaFooter" runat="server" />
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
