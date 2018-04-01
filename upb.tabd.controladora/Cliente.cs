using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN = upb.tabd.entidades;
using BR = upb.tabd.broker;

namespace upb.tabd.controladora
{
    public class Cliente
    {
        private BR.BDMascotasEntities db = new BR.BDMascotasEntities();

        public bool CrearCliente(EN.Cliente objCliente)
        {
            bool resultado = false;

            try
            {
                BR.Cliente cliente = new BR.Cliente();
                cliente.IdentCliente = objCliente.IdentCliente;
                cliente.NombreCliente = objCliente.NombreCliente;
                db.Clientes.Add(cliente);
                db.SaveChanges();

                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }
    }
}
