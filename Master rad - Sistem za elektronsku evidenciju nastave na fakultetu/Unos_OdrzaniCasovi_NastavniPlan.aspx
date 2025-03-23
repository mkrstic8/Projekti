



    

<%@ Page Title="Unos_OdrzaniCasovi_NastavniPlan" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Unos_OdrzaniCasovi_NastavniPlan.aspx.cs" Inherits="MilanKrstic.Unos_OdrzaniCasovi_NastavniPlan"  %> 


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EDnevnikVranje %>" SelectCommand="SELECT * FROM [OdrzaniCasovi_NastavniPlan]" UpdateCommand="UPDATE OdrzaniCasovi_NastavniPlan set nastavniPlan_id=@nastavniPlan_id,datum=@datum,nastavnaJedinica=@nastavnaJedinica,metodeRada=@metodeRada,casoviPredavanja=@casoviPredavanja,casoviVezbe=@casoviVezbe,casoviDON=@casoviDON,casoviPraksa=@casoviPraksa,napomena=@napomena where id=@id"></asp:SqlDataSource>



    
    
    <asp:GridView ID="EDnevnikVranje" runat="server"  AutoGenerateColumns="False" ShowFooter="True"  
        ShowHeaderWhenEmpty="True" 
        
        
               OnRowCommand="EDnevnikVranje_RowCommand" OnRowEditing="EDnevnikVranje_RowEditing" OnRowCancelingEdit="EDnevnikVranje_RowCancelingEdit" Font-Size="Small"
                OnRowUpdating="EDnevnikVranje_RowUpdating" OnRowDeleting="EDnevnikVranje_RowDeleting"   OnPageIndexChanging="EDnevnikVranje_PageIndexChanging"
        
        CellPadding="4" Height="100%" Width="100%" Word-Wrap="break-word" Table-Layout= "fixed"   ForeColor="#333333" GridLines="Horizontal" DataKeyNames="id,nastavniPlan_id,datum,nastavnaJedinica,metodeRada,casoviPredavanja,casoviVezbe,casoviDON,casoviPraksa,napomena"  AllowPaging="True"   >

       
        <RowStyle Font-Size="16px"  BackColor="#EFF3FB" />
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    

        <EditRowStyle BackColor="#2461BF"></EditRowStyle>

        <FooterStyle BackColor="#507CD1" ForeColor="Black" Font-Bold="True" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        
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
                    <asp:TextBox ID="txtId" runat="server"  Enabled="false" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtIdFooter" runat="server"  Enabled="false"  />
                </FooterTemplate>
                </asp:TemplateField>


            <asp:TemplateField HeaderText="NastavniPlan_id ">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("nastavniPlan_id") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNastavniPlan_id" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtNastavniPlan_idFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Datum" >
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("datum", "{0:dd. MM. yyyy}") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDatum"    runat="server" Text='<%# Bind("datum", "{0:dd. MM. yyyy}") %>'  />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtDatumFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Nastavna Jedinica">
    <ItemTemplate>
        <asp:Label Text='<%# Eval("nastavnaJedinica") %>' runat="server" Style="word-wrap: break-word" />
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtNastavnaJedinica" runat="server" TextMode="MultiLine" Rows="4" Columns="20"></asp:TextBox>
    </EditItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtNastavnaJedinicaFooter" runat="server" TextMode="MultiLine" Rows="4" Columns="20"></asp:TextBox>
    </FooterTemplate>
</asp:TemplateField>

            <asp:TemplateField HeaderText="Metode Rada">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("metodeRada") %>' runat="server" Style="word-wrap: break-word" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtMetodeRada" runat="server" TextMode="MultiLine" Rows="4" Columns="20" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtMetodeRadaFooter" runat="server" TextMode="MultiLine" Rows="4" Columns="20" />
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

               <asp:TemplateField HeaderText="Casovi DON">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("casoviDON") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCasoviDON" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtCasoviDONFooter" runat="server" />
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


             <asp:TemplateField HeaderText="Napomena">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("napomena") %>' runat="server" Style="word-wrap: break-word" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNapomena" runat="server" TextMode="MultiLine" Rows="4" Columns="20" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtNapomenaFooter" runat="server" TextMode="MultiLine" Rows="4" Columns="20" />
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
    <address>
    <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />

   
    </address>

   
</asp:Content>