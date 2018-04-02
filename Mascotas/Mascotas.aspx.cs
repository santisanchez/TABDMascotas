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
                DropDownRaza.DataValueField = "IdRaza";
                DropDownRaza.DataTextField = "NombreRaza";
                DropDownRaza.DataSource = controladoraRaza.ConsultarRaza(int.Parse(DropDownEspecie.SelectedValue));
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
            EN.Cliente cliente = new EN.Cliente();
            cliente.IdentCliente = Double.Parse(txtIdCliente.Text);
            cliente.NombreCliente = txtNombreCliente.Text;
            EN.Raza raza = new EN.Raza();
            raza.NombreRaza = DropDownRaza.SelectedValue;
            EN.Especie especie = new EN.Especie();             
            especie.IdEspecie = int.Parse(DropDownEspecie.SelectedValue);

            EN.Mascota mascota = new EN.Mascota();
            mascota.IdentMascota = generarIdMascota();
            mascota.NombreMascota = nombreMascota;
            mascota.Raza = raza;
            mascota.Especie = especie;
            mascota.Cliente = cliente;            


            CT.Mascota ctMascota = new CT.Mascota();
            ctMascota.CrearMascota(mascota);

            txtIdCliente.Text = string.Empty;
            txtNombreCliente.Text = string.Empty;
            txtMascota.Text = string.Empty;
        }

        private long generarIdMascota()
        {
            String idMascota;
            Random rnd = new Random();

            idMascota = rnd.Next(0, 9999999).ToString("D7");

            return long.Parse(idMascota);
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

        protected void DropDownEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}