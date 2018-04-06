using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EN = upb.tabd.entidades;
using CT = upb.tabd.controladora;

namespace Mascotas
{    
    public partial class Mascotas : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultarMascotas(-1);
            if (!this.IsPostBack)
            {
                CT.Especie controladoraEspecie = new CT.Especie();               
                DropDownEspecie.DataValueField = "IdEspecie";
                DropDownEspecie.DataTextField = "NombreEspecie";
                DropDownEspecie.DataSource = controladoraEspecie.ConsultarEspecies();
                DropDownEspecie.DataBind();
                CT.Raza controladoraRaza = new CT.Raza();
                DropDownList2.DataValueField = "IdRaza";
                DropDownList2.DataTextField = "NombreRaza";
                DropDownList2.DataSource = controladoraRaza.ConsultarRaza(int.Parse(DropDownEspecie.SelectedValue));
                DropDownList2.DataBind();
                DropDownRaza.DataValueField = "IdEspecie";
                DropDownRaza.DataTextField = "NombreEspecie";
                DropDownRaza.DataSource = controladoraEspecie.ConsultarEspecies();
                DropDownRaza.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string idMascota = tbBuscar.Text;
            if (idMascota.Trim().Length == 0)
            {
                idMascota = "-1";
            }
            ConsultarMascotas(int.Parse(idMascota));
        }

        private void ConsultarMascotas(int idMascota)
        {
            CT.Mascota mascota = new CT.Mascota();
            List<EN.Mascota> listado = mascota.ConsultarMascotas(idMascota);
            gvMascotas.DataSource = listado;
            gvMascotas.DataBind();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CrearMascotaNueva();
        }

        private void CrearMascotaNueva()
        {            
            string nombreMascota = txtMascota.Text;
            double idCliente = Double.Parse(txtIdCliente.Text);
            string nombreCliente = txtNombreCliente.Text;
            long idRaza = long.Parse(DropDownRaza.SelectedValue.ToString());

            EN.Cliente cliente = new EN.Cliente();
            cliente.IdentCliente = idCliente;
            cliente.NombreCliente = nombreCliente;

            EN.Especie especie = new EN.Especie();
            especie.IdEspecie = int.Parse(DropDownEspecie.SelectedValue);
            especie.NombreEspecie = DropDownEspecie.SelectedItem.ToString();

            EN.Raza raza = new EN.Raza();
            raza.IdRaza = raza.IdRaza = int.Parse(DropDownRaza.SelectedValue.ToString());
            raza.NombreRaza = DropDownRaza.SelectedItem.ToString();
            raza.Especie = especie;

            EN.Mascota mascota = new EN.Mascota();
            mascota.NombreMascota = nombreMascota;          
            mascota.Cliente = cliente;
            mascota.Raza = raza;

            CT.Mascota ctMascota = new CT.Mascota();
            ctMascota.CrearMascota(mascota);

            txtIdCliente.Text = string.Empty;
            txtNombreCliente.Text = string.Empty;
            txtMascota.Text = string.Empty;
            ConsultarMascotas(-1);
        }   

        protected void Button3_Click(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            BorrarMascota(argument);
        }
       

        private void BorrarMascota(string id)
        {
            string idMascota = id;
            try
            {
                CT.Mascota controladora = new CT.Mascota();                
                bool confirmacion = controladora.BorrarMascota(long.Parse(idMascota));
                ConsultarMascotas(-1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarMascota();
        }

        private void ActualizarMascota()
        {            
            string idMascota = Label13.Text;
            string nombreMascota = tbNombreMascota.Text;
            double idCliente = Double.Parse(tbIdCliente.Text);
            string nombreCliente = tbNombreCliente.Text;
            long idRaza = long.Parse(DropDownList2.SelectedValue.ToString());

            EN.Cliente cliente = new EN.Cliente();
            cliente.IdentCliente = idCliente;
            cliente.NombreCliente = nombreCliente;
            

            EN.Raza raza = new EN.Raza();
            raza.IdRaza = raza.IdRaza = int.Parse(DropDownList2.SelectedValue.ToString());
            raza.NombreRaza = DropDownList2.SelectedItem.ToString();            

            EN.Mascota mascota = new EN.Mascota();
            mascota.IdentMascota = long.Parse(idMascota);
            mascota.NombreMascota = nombreMascota;
            mascota.Cliente = cliente;
            mascota.Raza = raza;            

            CT.Mascota ctMascota = new CT.Mascota();
            ctMascota.ActualizarMascota(mascota);

            tbIdCliente.Text = string.Empty;
            tbNombreCliente.Text = string.Empty;
            tbNombreMascota.Text = string.Empty;
            ConsultarMascotas(-1);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            SeleccionarMascota(argument);
            
        }

        private void SeleccionarMascota(string id)
        {
            string idMascota = id;
            try
            {
                List<EN.Mascota> mascota = new List<EN.Mascota>();
                CT.Mascota controladora = new CT.Mascota();                
                mascota = controladora.ConsultarMascotas(int.Parse(idMascota));               
                Label13.Text = mascota[0].IdentMascota.ToString();
                tbIdCliente.Text = mascota[0].Cliente.IdentCliente.ToString();
                tbNombreCliente.Text = mascota[0].Cliente.NombreCliente;
                tbNombreMascota.Text = mascota[0].NombreMascota;                           
                DropDownList2.SelectedValue = mascota[0].Raza.IdRaza.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DropDownEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}