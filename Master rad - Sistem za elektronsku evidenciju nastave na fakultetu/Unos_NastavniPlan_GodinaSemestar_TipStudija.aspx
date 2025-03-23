


<%@ Page Title="Unos_NastavniPlan_GodinaSemestar_TipStudija" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Unos_NastavniPlan_GodinaSemestar_TipStudija.aspx.cs" Inherits="MilanKrstic.Unos_NastavniPlan_GodinaSemestar_TipStudija"  %> 


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EDnevnikVranje %>" SelectCommand="SELECT * FROM [NastavniPlan_GodinaSemestar_TipStudija]" UpdateCommand="UPDATE NastavniPlan_GodinaSemestar_TipStudija set tipStudija_id=@tipStudija_id,godinaSemestra_id=@godinaSemestra_id,kartonPredmeta_id=@kartonPredmeta_id,nastavnik_id=@nastavnik_id,casoviPredavanja=@casoviPredavanja,casoviVezbe=@casoviVezbe,casoviDON=@casoviDON,casoviPraksa=@casoviPraksa,status=@status where id=@id"></asp:SqlDataSource>
 <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:EDnevnikVranje %>" SelectCommand="SELECT id FROM [KartonPredmeta]"></asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:EDnevnikVranje %>" SelectCommand="SELECT id FROM [Nastavnik]"></asp:SqlDataSource>


    
    
    <asp:GridView ID="EDnevnikVranje" runat="server" AutoGenerateColumns="False" ShowFooter="True" 
        ShowHeaderWhenEmpty="True"
        
        
               OnRowCommand="EDnevnikVranje_RowCommand" OnRowEditing="EDnevnikVranje_RowEditing" OnRowCancelingEdit="EDnevnikVranje_RowCancelingEdit" Font-Size= "Small"
                OnRowUpdating="EDnevnikVranje_RowUpdating" OnRowDeleting="EDnevnikVranje_RowDeleting"   OnPageIndexChanging="EDnevnikVranje_PageIndexChanging" 
        
        CellPadding="4"  Height="100%" Width="100%" Word-Wrap="break-word" Table-Layout= "fixed"  ForeColor="#333333" GridLines="Horizontal" DataKeyNames="id,tipStudija_id,godinaSemestra_id,kartonPredmeta_id,nastavnik_id,casoviPredavanja,casoviVezbe,casoviDON,casoviPraksa,status" AllowPaging="True">

       

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
            <asp:TemplateField HeaderText="Id">
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


            <asp:TemplateField HeaderText="TipStudija_id ">
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


            <asp:TemplateField HeaderText="GodinaSemestar_id">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("godinaSemestra_id") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtGodinaSemestra_id" runat="server"  DataSourceID="SqlDataSource1" >
                    </asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtGodinaSemestra_idFooter" runat="server"   DataSourceID="SqlDataSource1">
                    </asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>


           <%-- <asp:TemplateField HeaderText="KartonPredmeta_id">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("kartonPredmeta_id") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtKartonPredmeta_id" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtKartonPredmeta_idFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>--%>


       <%--     ovo iznad je staro, kad nije bio kombo, dobro radi--%>

      <asp:TemplateField HeaderText="KartonPredmeta_id"  >

                <ItemTemplate>
                    <asp:Label Text='<%# Eval("kartonPredmeta_id") %>' runat="server" Width="150px"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlKartonPredmeta_id" runat="server" DataSourceID="SqlDataSource2"  DataTextField="id" DataValueField="id" Width="150px">
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlKartonPredmeta_id" runat="server" DataSourceID="SqlDataSource2" DataTextField="id" DataValueField="id" Width="150px">
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>

           <%-- ovo iznad je probno--%>



            <asp:TemplateField HeaderText="Nastavnik_id">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("nastavnik_id") %>' runat="server" Width="150px"/>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:DropDownList ID="ddlNastavnik_id" runat="server" DataSourceID="SqlDataSource3"  DataTextField="id" DataValueField="id" Width="150px">
                           </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                   <asp:DropDownList ID="ddlNastavnik_id" runat="server" DataSourceID="SqlDataSource3"  DataTextField="id" DataValueField="id" Width="150px">
                         </asp:DropDownList>
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