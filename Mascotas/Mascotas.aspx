<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Mascotas.aspx.cs" Inherits="Mascotas.Mascotas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label2" runat="server" Text="Id Cliente"></asp:Label>
            <asp:TextBox ID="txtIdCliente" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Nombre Cliente"></asp:Label>            
            <asp:TextBox ID="txtNombreCliente" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Nombre Mascota"></asp:Label>            
            <asp:TextBox ID="txtMascota" runat="server"></asp:TextBox>                      
            <asp:Label ID="Label6" runat="server" Text="Especie"></asp:Label>            
            <asp:DropDownList ID="DropDownEspecie" runat="server" OnSelectedIndexChanged="DropDownEspecie_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="Label5" runat="server" Text="Raza"></asp:Label>  
            <asp:DropDownList ID="DropDownRaza" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
        </div>
        <hr />
        <div>
            <asp:Label ID="Label12" runat="server" Text="Id Mascota"></asp:Label>
            <asp:Label ID="Label13" runat="server" Text=" "></asp:Label>
            <asp:Label ID="Label7" runat="server" Text="Id Cliente"></asp:Label>
            <asp:TextBox ID="tbIdCliente" runat="server"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="Nombre Cliente"></asp:Label>            
            <asp:TextBox ID="tbNombreCliente" runat="server"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" Text="Nombre Mascota"></asp:Label>            
            <asp:TextBox ID="tbNombreMascota" runat="server"></asp:TextBox>                                         
            <asp:Label ID="Label10" runat="server" Text="Raza"></asp:Label>  
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        </div>
        <hr />
        <div>
            <p></p>
            <asp:Label ID="Label1" runat="server" Text="Buscar"></asp:Label>
            <asp:TextBox ID="tbBuscar" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            <p></p>
            <asp:GridView ID="gvMascotas" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="gvMascotas_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Cliente.IdentCliente" HeaderText="id Cliente" />
                    <asp:BoundField DataField="Cliente.NombreCliente" HeaderText="Nombre Cliente" />
                    <asp:BoundField DataField="NombreMascota" HeaderText="Mascota" />
                    <asp:BoundField DataField="Raza.NombreRaza" HeaderText="Raza" />
                    <asp:BoundField DataField="Especie.NombreEspecie" HeaderText="Especie" />                                        
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:Button CommandArgument='<%# Eval("IdentMascota") %>' ID="Button3" runat="server" OnClick="Button3_Click" Text="Borrar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actualizar">
                        <ItemTemplate>
                            <asp:Button CommandArgument='<%# Eval("IdentMascota") %>' ID="Button4" runat="server" Text="Actualizar" OnClick="Button4_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
