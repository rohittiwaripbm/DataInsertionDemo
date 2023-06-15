<%@ Page Title="Input Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InputForm.aspx.cs" Inherits="DemoDataCode.HtmlWebForms.InputForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Cssfiles/StyleSheet1.css" rel="stylesheet" />
    <style>
    
</style>

    <div class="Class1">
        <h2>Insert Data</h2>
        <div id="Name">
            <h4>Name  </h4>
            <input runat="server" type="text" id="Inputname" name="email" required>
        </div>
        <div id="Email">
            <h4>Email  </h4>
            <input runat="server" type="email" id="Inputemail" name="email" required>
            <%--<asp:TextBox AutoCompleteType="Email" runat="server"></asp:TextBox>--%>
        </div>
        <div id="Mobno">
            <h4>Mobile no.   </h4>
            <input runat="server" type="tel" id="Inputmob" name="email" required>
        </div>

        <div class="Buttons">
            <asp:Button runat="server" OnClick="Save" Text="Submit" />

        </div>
    </div>

    <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False"
        CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="grid1_RowDataBound" >  
     <AlternatingRowStyle BackColor="White"  />  
        <columns>  
         <asp:TemplateField HeaderText="Id" ItemStyle-CssClass="grid-column">  
             <ItemTemplate >  
                 <asp:Label class="grid-column" ID="DecrytedId" runat="server" Text='<%#Bind("Id") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="grid-column">  
             <ItemTemplate>  
                 <asp:Label class="grid-column" ID="DecryptedName" runat="server" Text='<%#Bind("Uname") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Email" ItemStyle-CssClass="grid-column">  
             <ItemTemplate>  
                 <asp:Label class="grid-column" ID="DecryptedEmail" runat="server"  Text='<%#Bind("Uemail") %>'></asp:Label>  
                 <%--<asp:Label ID="Decrypted" runat="server" Text=''></asp:Label>--%> 
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Phone" ItemStyle-CssClass="grid-column">  
             <ItemTemplate>  
                 <asp:Label class="grid-column" ID="DecryptedMobno" runat="server" Text='<%#Bind("Mob_no") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Is Active" ItemStyle-CssClass="grid-column" >  
             <ItemTemplate>  
                 <asp:Label class="grid-column" ID="DecryptedIsActive" runat="server" Text='<%#Bind("Isactive") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
     </columns>
         <EditRowStyle BackColor="#2461BF" />  
     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
     <%--<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />--%>  
     <RowStyle BackColor="#EFF3FB" />  
     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />  
     <SortedAscendingCellStyle BackColor="#F5F7FB" />  
     <SortedAscendingHeaderStyle BackColor="#6D95E1" />  
     <SortedDescendingCellStyle BackColor="#E9EBEF" />  
     <SortedDescendingHeaderStyle BackColor="#4870BE" /> 
    </asp:GridView>

   

</asp:Content>
